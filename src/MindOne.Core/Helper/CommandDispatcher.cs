using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MindOne.Core.Helper
{
    public abstract class CommandDispatcher<T> where T : struct, IConvertible
    {
        public bool CommandFromName(ToolStripItem item, ref T command)
        {
            string itemName = item.Name;
            itemName = itemName.ToLower();
            var prefixes = new[] { "tool", "mnu" };
            foreach (var prefix in prefixes)
            {
                if (itemName.StartsWith(prefix) && itemName.Length > prefix.Length)
                    itemName = itemName.Substring(prefix.Length);
            }

            var dict = Enum.GetValues(typeof(T)).Cast<T>().ToDictionary(v => v.ToString().ToLower(), v => v);
            if (dict.ContainsKey(itemName))
            {
                command = dict[itemName];
                return true;
            }

            Trace.WriteLine($"Command not found: { itemName }");

            if (item is ToolStripDropDownItem menu && menu.DropDownItems.Count > 0)
                return false;

            if (item is ToolStripSeparator) return false;

            CommandNotFound(item);
            return false;
        }

        public abstract void Run(T command);

        protected abstract void CommandNotFound(ToolStripItem item);

        /// <summary>
        /// Sets event handlers for menu items
        /// </summary>
        public void InitMenu(ToolStripItemCollection items)
        {
            if (items == null)
                return;

            foreach (ToolStripItem item in items)
            {
                if (item.Tag == null)
                    item.Click += ItemClick;

                if (item is ToolStripDropDownItem menuItem)
                {
                    InitMenu(menuItem.DropDownItems);
                }
            }
        }

        /// <summary>
        /// Runs menu commands
        /// </summary>
        private void ItemClick(object sender, EventArgs e)
        {
            if (!(sender is ToolStripItem item))
                return;

            var command = Activator.CreateInstance<T>();
            if (CommandFromName(item, ref command))
                Run(command);
        }
    }
}
