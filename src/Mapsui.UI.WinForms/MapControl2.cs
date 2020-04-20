using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mapsui.Fetcher;
using Mapsui.Utilities;
using Mapsui.Rendering.Skia;

namespace Mapsui.UI.WinForms
{
    public class MapControl2 : Control
    {
        private Map _map;
        private string _errorMessage;
        private Bitmap _buffer;
        private Graphics _bufferGraphics;
        private readonly Brush _whiteBrush = new SolidBrush(Color.White);
        private Geometries.Point _mousePosition;
        //Indicates that a redraw is needed. This often coincides with 
        //manipulation but not in the case of new data arriving.
        private bool _viewInitialized;
        private readonly MapRenderer _renderer = new MapRenderer();
        public event EventHandler ErrorMessageChanged;

        public IViewport Transform
        {
            get { return _map.Viewport; }
        }

        public Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                var temp = _map;
                _map = null;

                if (temp != null)
                {
                    temp.DataChanged -= MapDataChanged;
                    temp.Dispose();
                }

                _map = value;
                _map.DataChanged += MapDataChanged;

                ViewChanged(true);
                Invalidate();
            }
        }

        void MapDataChanged(object sender, DataChangedEventArgs e)
        {
            //ViewChanged should not be called here. This would cause a loop
            BeginInvoke((Action)(() => DataChanged(sender, e)));
        }


        public MapControl2()
        {
            Map = new Map();
            Resize += MapControl_Resize;
            MouseDown += MapControl_MouseDown;
            MouseMove += MapControl_MouseMove;
            MouseUp += MapControl_MouseUp;
            Disposed += MapControl_Disposed;
        }

        public void ZoomIn()
        {
            Map.Viewport.Resolution = ZoomHelper.ZoomIn(_map.Resolutions, Map.Viewport.Resolution);
            ViewChanged(true);
            Invalidate();
        }

        public void ZoomIn(PointF mapPosition)
        {
            // When zooming in we want the mouse position to stay above the same world coordinate.
            // We do that in 3 steps.

            // 1) Temporarily center on where the mouse is
            Map.Viewport.Center = Map.Viewport.ScreenToWorld(mapPosition.X, mapPosition.Y);

            // 2) Then zoom 
            Map.Viewport.Resolution = ZoomHelper.ZoomIn(_map.Resolutions, Map.Viewport.Resolution);

            // 3) Then move the temporary center back to the mouse position
            Map.Viewport.Center = Map.Viewport.ScreenToWorld(
              Map.Viewport.Width - mapPosition.X,
              Map.Viewport.Height - mapPosition.Y);

            ViewChanged(true);
            Invalidate();
        }

        public void ZoomOut()
        {
            Map.Viewport.Resolution = ZoomHelper.ZoomOut(_map.Resolutions, Map.Viewport.Resolution);
            ViewChanged(true);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!_viewInitialized) InitializeView();
            if (!_viewInitialized) return; //initialize in the line above failed. 

            base.OnPaint(e);

            //Reset background
            _bufferGraphics.FillRectangle(_whiteBrush, 0, 0, _buffer.Width, _buffer.Height);

            //Render to the buffer
            _renderer.Graphics = _bufferGraphics;
            _renderer.Render(Map.Viewport, _map.Layers);

            //Render the buffer to the control
            e.Graphics.DrawImage(_buffer, 0, 0);
        }

        private void ViewChanged(bool changeEnd)
        {
            if (_map != null)
            {
                _map.ViewChanged(changeEnd);
            }
        }

        private void DataChanged(object sender, DataChangedEventArgs e)
        {
            if (e.Error == null && e.Cancelled == false)
            {
                Invalidate();
            }
            else if (e.Cancelled)
            {
                _errorMessage = "Cancelled";
                OnErrorMessageChanged();
            }
            else if (e.Error is System.Net.WebException)
            {
                _errorMessage = "WebException: " + e.Error.Message;
                OnErrorMessageChanged();
            }
            else if (e.Error == null)
            {
                _errorMessage = "Unknown Exception";
                OnErrorMessageChanged();
            }
            else
            {
                _errorMessage = "Exception: " + e.Error.Message;
                OnErrorMessageChanged();
            }
        }

        private void MapControl_MouseDown(object sender, MouseEventArgs e)
        {
            _mousePosition = new Geometries.Point(e.X, e.Y);
        }

        private void MapControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_mousePosition == null) return;
                var newMousePosition = new Geometries.Point(e.X, e.Y);
                MapTransformHelpers.Pan(Map.Viewport, newMousePosition, _mousePosition);
                _mousePosition = newMousePosition;

                ViewChanged(false);
                Invalidate();
            }
        }

        private void MapControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_mousePosition == null) return;
                var newMousePosition = new Geometries.Point(e.X, e.Y);
                MapTransformHelpers.Pan(Map.Viewport, newMousePosition, _mousePosition);
                _mousePosition = newMousePosition;

                ViewChanged(true);
                Invalidate();
            }
        }

        private void MapControl_Resize(object sender, EventArgs e)
        {
            if (Width == 0) return;
            if (Height == 0) return;

            Map.Viewport.Width = Width;
            Map.Viewport.Height = Height;

            if (_buffer == null || _buffer.Width != Width || _buffer.Height != Height)
            {
                _buffer = new Bitmap(Width, Height);
                _bufferGraphics = Graphics.FromImage(_buffer);
            }

            ViewChanged(true);
            Invalidate();
        }

        private void InitializeView()
        {
            if (double.IsNaN(Width) || Width == 0) return;
            if (_map == null || _map.Envelope == null || double.IsNaN(_map.Envelope.Width) || _map.Envelope.Width <= 0) return;
            if (_map.Envelope.GetCentroid() == null) return;

            Map.Viewport.Center = _map.Envelope.GetCentroid();
            Map.Viewport.Resolution = _map.Envelope.Width / Width;
            _viewInitialized = true;
            ViewChanged(true);
        }

        protected override void Dispose(bool disposing)
        {
            Map.Dispose();
            base.Dispose(disposing);
        }

        private void MapControl_Disposed(object sender, EventArgs e)
        {
            Map.Dispose();
        }

        protected void OnErrorMessageChanged()
        {
            if (ErrorMessageChanged != null) ErrorMessageChanged(this, null);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (DesignMode) base.OnPaintBackground(e);
            //by overriding this method and not calling the base class implementation 
            //we prevent flickering.
        }
    }
}
