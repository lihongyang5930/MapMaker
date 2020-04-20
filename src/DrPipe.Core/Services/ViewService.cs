using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrPipe.Core.Forms;
using DrPipe.Core.Models;
using DrPipe.Core.Views;
using DrPipe.Core.Views.Common;

namespace DrPipe.Core.Services
{
    public class ViewService
    {
        Dictionary<Type, Control> _views = new Dictionary<Type, Control>();

        public Form MainForm
        {
            get
            {
                return Application.OpenForms[0];
            }
        }

        public void Register(Control view)
        {
            var type = view.GetType();
            if (_views.ContainsKey(type))
                return;
            _views.Add(type, view);
        }
        public TView GetView<TView>()
            where TView : Control
        {
            if (!_views.ContainsKey(typeof(TView)))
                Register(Activator.CreateInstance<TView>());
            return (TView)_views[typeof(TView)];
        }



        public MonthRange SelectMonth()
        {
            var view = new MonthRangeSelectorView();
            var frm  = GetDialogForm(view, "기간설정");
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
                return view.GetResult();
            return null;
        }

        public DialogResult ShowDialog<TControl>(TControl view, string title = "Dr. Pipe")
            where TControl : UserControl
        {
            var frm  = GetDialogForm(view, title);
            frm.ShowDialog();
            return frm.DialogResult;
        }
        public DialogResult ShowFixedDialog<TControl>(TControl view, string title = "Dr. Pipe")
            where TControl : UserControl
        {
            var frm  = GetDialogForm(view, title);
            frm.ShowDialog();
            return frm.DialogResult;
        }
        private void ShowFixedDialog<TForm, TControl>(TForm frm, TControl view, string title = "Dr. Pipe")
            where TForm : Form
            where TControl : UserControl
        {
            view.Dock = DockStyle.Fill;

            frm.Text = title;
            frm.Width           = view.Width  + 20;
            frm.Height          = view.Height + 40;
            frm.ControlBox      = true;
            frm.MinimizeBox     = false;
            frm.MaximizeBox     = false;
            frm.FormBorderStyle = FormBorderStyle.Fixed3D;
            frm.StartPosition   = FormStartPosition.CenterParent;
            frm.Controls.Add(view);
            frm.ShowDialog();
        }
        private DialogForm GetDialogForm(UserControl view, string title = "Dr. Pipe")
        {
            view.Dock = DockStyle.Fill;

            var frm             = new DialogForm();
            frm.Text            = title;
            frm.ThemeName       = "Office2016Colorful";
            frm.Width           = view.Width  + 20;
            frm.Height          = view.Height + 40;
            frm.ControlBox      = true;
            frm.MinimizeBox     = false;
            frm.MaximizeBox     = false;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.StartPosition   = FormStartPosition.CenterParent;
            frm.Icon            = new Icon(@"Resources\images\app\drpipe.ico");
            frm.Controls.Add(view);
            return frm;
        }
    }
}
