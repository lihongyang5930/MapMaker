using System.Windows.Forms;
using DrPipe.Core.Services;
using Syncfusion.Windows.Forms.Tools;

namespace DrPipe.Core.Extensions
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
        public static ToolStripPanelItem AddPanel(this ToolStripEx parent, int count = 3)
        {
            var item = new ToolStripPanelItem();
            item.RowCount = count;
            item.AutoSize = true;
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripPanelItem AddPanel(this ToolStripPanelItem parent, int count = 3)
        {
            var item = new ToolStripPanelItem();
            item.RowCount = count;
            item.AutoSize = true;
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
        public static ToolStripRadioButton AddRadioButton(this ToolStripPanelItem parent, string text)
        {
            var item = new ToolStripRadioButton();
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
        public static ToolStripDropDownButton AddDropDownButton(this ToolStripEx parent, string text, string imagePath)
        {
            var item = new ToolStripDropDownButton();
            Appearances.MainRibbonButton(item, text, imagePath);
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripButton AddButton(this ToolStripPanelItem parent, string text)
        {
            var item = new ToolStripButton();
            Appearances.MainRibbonButton(item, text);
            parent.Items.Add(item);
            return item;
        }
        public static ToolStripButton AddButton(this ToolStripEx parent, string text, string imagePath)
        {
            var item = new ToolStripButton();
            Appearances.MainRibbonButton(item, text, imagePath);
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
