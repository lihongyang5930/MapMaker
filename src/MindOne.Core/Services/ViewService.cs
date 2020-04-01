using MindOne.Core.Views;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MindOne.Core.Services
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
        public TView GetView<TView>() where TView : Control
        {
            if (!_views.ContainsKey(typeof(TView)))
                Register(CreateInstance<TView>());
            return (TView)_views[typeof(TView)];
        }

        public TView GetView<TView>(params object[] args) where TView : Control
        {
            if (!_views.ContainsKey(typeof(TView)))
                Register(CreateInstance<TView>(args));


            return (TView)_views[typeof(TView)];
        }

        private TView CreateInstance<TView>(params object[] args) where TView : Control
        {
            return (TView)Activator.CreateInstance(typeof(TView), args: args);
        }

        public DialogResult ShowDialog<TControl>(TControl view, string title = "MapMaker v2.0")
            where TControl : UserControl
        {
            var frm  = GetDialogForm(view, title);
            frm.ShowDialog();
            return frm.DialogResult;
        }
        public DialogResult ShowFixedDialog<TControl>(TControl view, string title = "MapMaker v2.0")
            where TControl : UserControl
        {
            var frm  = GetDialogForm(view, title);
            frm.ShowDialog();
            return frm.DialogResult;
        }
        private void ShowFixedDialog<TForm, TControl>(TForm frm, TControl view, string title = "MapMaker v2.0")
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
        private DialogForm GetDialogForm(UserControl view, string title = "MapMaker v2.0")
        {
            view.Dock = DockStyle.Fill;

            var frm             = new DialogForm();
            frm.Text            = title;
            frm.Width           = view.Width  + 20;
            frm.Height          = view.Height + 40;
            frm.ControlBox      = true;
            frm.MinimizeBox     = false;
            frm.MaximizeBox     = false;
            frm.FormBorderStyle = FormBorderStyle.Sizable;
            frm.StartPosition   = FormStartPosition.CenterParent;
            frm.Controls.Add(view);
            return frm;
        }
    }
}
