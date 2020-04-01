using System.Drawing;
using System.Windows.Forms;
using MindOne.Core.Services;
using Syncfusion.Windows.Forms.Tools;

namespace MindOne.Core.Extensions
{
    public static class RibbonExtension
    {
        public static ToolStripTabItem AddTab(this RibbonControlAdv control, string text)
        {
            var item = new ToolStripTabItem();
            item.Text = text;
            item.Font = Appearances.DefaultFont;
            control.Header.AddMainItem(item);
            return item;
        }
        public static ToolStripEx AddGroup(this ToolStripTabItem parent, string text = null)
        {
            var item = new ToolStripEx();
            item.AutoSize  = true;
            item.GripStyle = ToolStripGripStyle.Hidden;
            item.CaptionFont = Appearances.DefaultFont;
            item.Font        = Appearances.DefaultFont;
            item.Text        = text;
            parent.Panel.Controls.Add(item);
            return item;
        }
        public static ToolStripSeparator AddSeparator(this ToolStripEx parent)
        {
            var item = new ToolStripSeparator();
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripPanelItem AddPanel(this ToolStripEx parent)
        {
            var item = new ToolStripPanelItem();
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripPanelItem AddPanel(this ToolStripPanelItem parent)
        {
            var item = new ToolStripPanelItem();
            parent.Items.Add(item);
            return item;
        }

        public static ToolStripRadioButton AddRadioButton(this ToolStripPanelItem parent, string name, string text)
        {
            var item = new ToolStripRadioButton() { Name = name, Text = text };
            parent.Items.Add(item);
            return item;
        }

        public static ToolStripLabel AddLabel(this ToolStripPanelItem parent, string text)
        {
            var item = new ToolStripLabel();
            item.Text = text;
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripLabel AddLabel(this ToolStripPanelItem parent, string text, int margin)
        {
            var item = AddLabel(parent, text);
            item.Margin = new Padding(margin);
            return item;
        }
        public static ToolStripLabel AddLabel(this ToolStripPanelItem parent, string text, int marginLeft, int marginTop, int marginRight, int marginBottom)
        {
            var item = AddLabel(parent, text);
            item.Margin = new Padding(marginLeft, marginTop, marginRight, marginBottom);
            return item;
        }


        public static ToolStripCheckBox AddCheckBox(this ToolStripPanelItem parent, string text)
        {
            var item = new ToolStripCheckBox();
            item.Text = text;
            parent.Items.Add(item);
            return item;
        }
     
        public static ToolStripComboBoxEx AddComboBox(this ToolStripPanelItem parent)
        {
            var item = new ToolStripComboBoxEx();
            item.Style = ToolStripExStyle.Office2016Colorful;
            parent.Items.Add(item);
            return item;
            
        }
        public static ToolStripDropDownButton AddDropDownButton(this ToolStripEx parent, string text, Image image = null)
        {
            var item = new ToolStripDropDownButton();
            Appearances.MainRibbonButton(item, text, image);
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripButton AddButton(this ToolStripPanelItem parent, string text)
        {
            return AddButton(parent, text);
        }
        public static ToolStripButton AddButton(this ToolStripEx parent, string text, Image image = null)
        {
            return AddButton(parent, "", text, image);
        }

        public static ToolStripButton AddButton(this ToolStripEx parent, string name, string text, Image image = null)
        {
            var item = new ToolStripButton() { Name = name, Text = text };
            Appearances.MainRibbonButton(item, text, image);
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripMenuItem AddDropDownItem(this ToolStripDropDownItem parent, string text)
        {
            var item = new ToolStripMenuItem();
            item.Text = text;
            parent.DropDownItems.Add(item);
            return item;
        }
    }
}
