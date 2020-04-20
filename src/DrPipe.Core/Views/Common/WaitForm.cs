using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace DrPipe.Core.Views.Common
{
    public partial class WaitForm : Form
    {
        Bitmap _bitmap;

        public WaitForm(string message)
        {
            InitializeComponent();
            lblMessage.Text = message;
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    _bitmap = new Bitmap("loading.gif");
        //    ImageAnimator.Animate(_bitmap, new EventHandler(OnFrameChanged));
        //    base.OnLoad(e);
        //}
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    ImageAnimator.UpdateFrames();
        //    var g = pictureBox1.CreateGraphics();
        //    g.Clear(Color.White);
        //    g.DrawImage(_bitmap, new Point(0, 0));
        //    base.OnPaint(e);
        //}
        //private void OnFrameChanged(object sender, EventArgs e)
        //{
        //    Invalidate();
        //}
    }
}
