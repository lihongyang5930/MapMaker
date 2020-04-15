// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.NTSExtension;
using DotSpatial.Serialization;
using DotSpatial.Symbology;
using GeoAPI.Geometries;

namespace DotSpatial.Plugins.ShapeEditor
{
    /// <summary>
    /// MoveVertexFunction�� ���ʿ��� Ȱ������ ���õ� ���̾ ������� �۵��մϴ�.
    /// MoveVertex�� ���� �۾� �� ������ �����ϱ� ���� ������ Ŭ���ؾ��մϴ�.
    /// ���콺�� �����̸� ���� ��尡 �ƴ� ��� ���� �� ���ִ� ����� ���� ǥ�õ˴ϴ�.
    /// ������ Ŭ���ϸ� �ش� ������ ���� "���� ���"�� �����˴ϴ�.
    /// ������ �ٰ����� ��� ������ �Ķ������� ǥ���մϴ�.
    /// �������� ���콺�� �巡���Ͽ� ������ �����մϴ�.
    /// �巡���ϴ� ���� ���콺 ������ ��ư�� Ŭ���ϸ� �̵��� ��ҵ˴ϴ�.
    /// ���콺 ������ ��ư�� Ŭ���ϸ� ���� �� ����� ���� ��ҵ˴ϴ�.
    /// </summary>
    public class MoveVertexFunction : SnappableMapFunction
    {
        #region Fields

        private IFeatureCategory _activeCategory;
        private IFeature _activeFeature; // not yet selected
        private Coordinate _activeVertex;
        private Coordinate _closedCircleCoord;
        private Coordinate _dragCoord;
        private bool _dragging;
        private IFeatureSet _featureSet;
        private Rectangle _imageRect;
        private IFeatureLayer _layer;
        private Point _mousePosition;
        private Coordinate _nextPoint;
        private IFeatureCategory _oldCategory;
        private Coordinate _previousPoint;
        private IFeatureCategory _selectedCategory;
        private IFeature _selectedFeature;

        #endregion

        #region  Constructors

        /// <summary>
        /// ������ ���� �� <see cref = "MoveVertexFunction"/> Ŭ������ �� �ν��Ͻ��� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="map">IMap �������̽��� �����ϴ� �� ��Ʈ���Դϴ�.</param>
        public MoveVertexFunction(IMap map)
            : base(map)
        {
            Configure();
        }

        #endregion

        #region Events

        /// <summary>
        /// ������ �̵� �� �� �߻��մϴ�.
        /// </summary>
        public event EventHandler<VertexMovedEventArgs> VertextMoved;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets ������� ���̾�
        /// </summary>
        public IFeatureLayer Layer
        {
            get
            {
                return _layer;
            }

            set
            {
                _layer = value;
                _featureSet = _layer.DataSet;
                InitializeSnapLayers();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// ������ ������ ���� ����ϰ� ���� ǥ�õ� ��ɿ��� ���� ǥ�ø� �����մϴ�.
        /// </summary>
        public void ClearSelection()
        {
            DeselectFeature();
            RemoveHighlightFromFeature();
            _oldCategory = null;
        }

        /// <summary>
        /// � ������ ���̾ ���õ��� �ʰų� ���� �׸��� ���� �����ϴ� ��� ȣ���ؾ��մϴ�.
        /// </summary>
        public void DeselectFeature()
        {
            if (_selectedFeature != null)
            {
                _layer.SetCategory(_selectedFeature, _oldCategory);
            }

            _selectedFeature = null;

            Map.MapFrame.Initialize();
            Map.Invalidate();
        }

        /// <summary>
        /// ���� ���� ǥ�õ� ��ɿ��� ���� ǥ�ø� �����մϴ�.
        /// </summary>
        public void RemoveHighlightFromFeature()
        {
            if (_activeFeature != null)
            {
                _layer.SetCategory(_activeFeature, _oldCategory);
            }

            _activeFeature = null;
        }

        /// <inheritdoc />
        protected override void OnDeactivate()
        {
            ClearSelection();
            base.OnDeactivate();
        }

        /// <inheritdoc />
        protected override void OnDraw(MapDrawArgs e)
        {
            Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
            if (_selectedFeature != null)
            {
                foreach (Coordinate c in _selectedFeature.Geometry.Coordinates)
                {
                    Point pt = e.GeoGraphics.ProjToPixel(c);
                    if (e.GeoGraphics.ImageRectangle.Contains(pt))
                    {
                        e.Graphics.FillRectangle(Brushes.Blue, pt.X - 2, pt.Y - 2, 4, 4);
                    }

                    if (mouseRect.Contains(pt))
                    {
                        e.Graphics.FillRectangle(Brushes.Red, mouseRect);
                    }
                }
            }

            if (_dragging)
            {
                if (_featureSet.FeatureType == FeatureType.Point || _featureSet.FeatureType == FeatureType.MultiPoint)
                {
                    Rectangle r = new Rectangle(_mousePosition.X - (_imageRect.Width / 2), _mousePosition.Y - (_imageRect.Height / 2), _imageRect.Width, _imageRect.Height);
                    _selectedCategory.Symbolizer.Draw(e.Graphics, r);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Red, _mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
                    Point b = _mousePosition;
                    Pen p = new Pen(Color.Blue)
                    {
                        DashStyle = DashStyle.Dash
                    };
                    if (_previousPoint != null)
                    {
                        Point a = e.GeoGraphics.ProjToPixel(_previousPoint);
                        e.Graphics.DrawLine(p, a, b);
                    }

                    if (_nextPoint != null)
                    {
                        Point c = e.GeoGraphics.ProjToPixel(_nextPoint);
                        e.Graphics.DrawLine(p, b, c);
                    }

                    p.Dispose();
                }
            }
        }

        /// <inheritdoc />
        protected override void OnMouseDown(GeoMouseArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                _mousePosition = e.Location;
                if (_dragging)
                {
                    if (e.Button == MouseButtons.Right)
                    {
                        _dragging = false;
                        Map.Invalidate();
                        Map.IsBusy = false;
                    }
                }
                else
                {
                    // ������ ������ ���õǾ� ������, ������ ������ �����մϴ�.
                    if (_selectedFeature != null)
                    {
                        // ���� ������ ���� ������ �����մϴ�.
                        Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
                        Envelope env = Map.PixelToProj(mouseRect).ToEnvelope();

                        // ������ ���õǾ����ϴ�.
                        if (CheckForVertexDrag(e))
                        {
                            return;
                        }

                        // ���� ������ �߻����� �ʾҽ��ϴ�.
                        if (!_selectedFeature.Geometry.Intersects(env.ToPolygon()))
                        {
                            // ������ ����մϴ�.
                            DeselectFeature();
                            return;
                        }
                    }

                    if (_activeFeature != null)
                    {
                        // �ٰ����� ���� ������ �ٷ� �巡������ ���ʽÿ�. ���� ������ ǥ���ϴ� �ٰ����� ������ ���� �̵��� �� �ֽ��ϴ�.
                        if (_featureSet.FeatureType == FeatureType.Polygon) // ��
                        {
                            _selectedFeature = _activeFeature;
                            _activeFeature = null;
                            if (!(_selectedCategory is IPolygonCategory sc))
                            {
                                _selectedCategory = new PolygonCategory(Color.FromArgb(55, 0, 255, 255), Color.Blue, 1)
                                {
                                    LegendItemVisible = false
                                };
                            }

                            _layer.SetCategory(_selectedFeature, _selectedCategory);
                        }
                        else if (_featureSet.FeatureType == FeatureType.Line) // ��
                        {
                            _selectedFeature = _activeFeature;
                            _activeFeature = null;
                            if (!(_selectedCategory is ILineCategory sc))
                            {
                                _selectedCategory = new LineCategory(Color.Cyan, 1)
                                {
                                    LegendItemVisible = false
                                };
                            }

                            _layer.SetCategory(_selectedFeature, _selectedCategory);
                        }
                        else // ��
                        {
                            _dragging = true;
                            Map.IsBusy = true;
                            _dragCoord = _activeFeature.Geometry.Coordinates[0];
                            MapPointLayer mpl = _layer as MapPointLayer;
                            mpl?.SetVisible(_activeFeature, false);

                            if (!(_selectedCategory is IPointCategory sc))
                            {
                                if (_layer.GetCategory(_activeFeature).Symbolizer.Copy() is IPointSymbolizer ps)
                                {
                                    ps.SetFillColor(Color.Cyan);
                                    _selectedCategory = new PointCategory(ps);
                                }
                            }
                        }
                    }

                    Map.MapFrame.Initialize();
                    Map.Invalidate();
                }
            }

            base.OnMouseDown(e);
        }

        /// <inheritdoc />
        protected override void OnMouseMove(GeoMouseArgs e)
        {
            _mousePosition = e.Location;

            if (_dragging)
            {
                // ���� ����
                Coordinate snappedCoord = e.GeographicLocation;
                if (ComputeSnappedLocation(e, ref snappedCoord))
                {
                    _mousePosition = Map.ProjToPixel(snappedCoord);
                }

                // ���� ���� ����
                UpdateDragCoordinate(snappedCoord); // Snapping changes
            }
            else
            {
                if (_selectedFeature != null)
                {
                    VertexHighlight();
                }
                else
                {
                    // ������ �����ϱ� ���� ������ ���� ǥ�� �� �� �־���մϴ�. ��� ���� �����ؾ��ϴ��� ��Ÿ���ϴ�.
                    bool requiresInvalidate = false;
                    if (_activeFeature != null)
                    {
                        if (ShapeRemoveHighlight(e))
                        {
                            requiresInvalidate = true;
                        }
                    }

                    if (_activeFeature == null)
                    {
                        if (ShapeHighlight(e))
                        {
                            requiresInvalidate = true;
                        }
                    }

                    if (requiresInvalidate)
                    {
                        Map.MapFrame.Initialize();
                        Map.Invalidate();
                    }
                }
            }

            base.OnMouseMove(e);
        }

        /// <inheritdoc />
        protected override void OnMouseUp(GeoMouseArgs e)
        {
            // �̵��� ���콺�� ������ ��������(��ġ�̵�������)
            if (e.Button == MouseButtons.Left && _dragging)
            {
                // [20200414] fdragons - add user confirm
                //if (DialogResult.OK != MessageBox.Show("�� ��ġ�� �̵� �Ͻðڽ��ϱ�?", "��ǥ�̵�", MessageBoxButtons.OKCancel))
                //{
                //    // [TODO] �̵� ���ó���� �߰��Ͽ��� �Ѵ�.
                //}
                _dragging = false;
                Map.IsBusy = false;

                _featureSet.InvalidateVertices();

                // ��
                if (_featureSet.FeatureType == FeatureType.Point || _featureSet.FeatureType == FeatureType.MultiPoint)
                {
                    if (_activeFeature == null)
                    {
                        return;
                    }

                    OnVertexMoved(new VertexMovedEventArgs(_activeFeature));

                    if (_layer.GetCategory(_activeFeature) != _selectedCategory)
                    {
                        _layer.SetCategory(_activeFeature, _selectedCategory);
                        _layer.SetVisible(_activeFeature, true);
                    }
                }
                else // ��, ��
                {
                    if (_selectedFeature == null)
                    {
                        return;
                    }

                    OnVertexMoved(new VertexMovedEventArgs(_selectedFeature));

                    if (_layer.GetCategory(_selectedFeature) != _selectedCategory)
                    {
                        _layer.SetCategory(_selectedFeature, _selectedCategory);
                    }
                }
            }

            Map.MapFrame.Initialize();
            base.OnMouseUp(e);
        }


        /// <summary>
        /// �� �Լ��� ���� ���콺 ��ġ�� ��ǥ�� ���� �ִ��� Ȯ���մϴ�.
        /// </summary>
        /// <param name="e">GeoMouseArgs �Ű� ������ ���콺 ��ġ �� ������ ��ǥ�� ���� ������ �����մϴ�.</param>
        /// <returns>True, ���� ���콺 ��ġ�� ���� �����ִ� ���</returns>
        private bool CheckForVertexDrag(GeoMouseArgs e)
        {
            Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
            Envelope env = Map.PixelToProj(mouseRect).ToEnvelope();
            if (e.Button == MouseButtons.Left)
            {
                if (_layer.DataSet.FeatureType == FeatureType.Polygon)
                {
                    for (int prt = 0; prt < _selectedFeature.Geometry.NumGeometries; prt++)
                    {
                        IGeometry g = _selectedFeature.Geometry.GetGeometryN(prt);
                        IList<Coordinate> coords = g.Coordinates;
                        for (int ic = 0; ic < coords.Count; ic++)
                        {
                            Coordinate c = coords[ic];
                            if (env.Contains(c))
                            {
                                _dragging = true;
                                _dragCoord = c;
                                if (ic == 0)
                                {
                                    _closedCircleCoord = coords[coords.Count - 1];
                                    _previousPoint = coords[coords.Count - 2];
                                    _nextPoint = coords[1];
                                }
                                else if (ic == coords.Count - 1)
                                {
                                    _closedCircleCoord = coords[0];
                                    _previousPoint = coords[coords.Count - 2];
                                    _nextPoint = coords[1];
                                }
                                else
                                {
                                    _previousPoint = coords[ic - 1];
                                    _nextPoint = coords[ic + 1];
                                    _closedCircleCoord = null;
                                }

                                Map.Invalidate();
                                return true;
                            }
                        }
                    }
                }
                else if (_layer.DataSet.FeatureType == FeatureType.Line)
                {
                    for (int prt = 0; prt < _selectedFeature.Geometry.NumGeometries; prt++)
                    {
                        IGeometry g = _selectedFeature.Geometry.GetGeometryN(prt);
                        IList<Coordinate> coords = g.Coordinates;
                        for (int ic = 0; ic < coords.Count; ic++)
                        {
                            Coordinate c = coords[ic];
                            if (env.Contains(c))
                            {
                                _dragging = true;
                                _dragCoord = c;

                                if (ic == 0)
                                {
                                    _previousPoint = null;
                                    _nextPoint = coords[1];
                                }
                                else if (ic == coords.Count - 1)
                                {
                                    _previousPoint = coords[coords.Count - 2];
                                    _nextPoint = null;
                                }
                                else
                                {
                                    _previousPoint = coords[ic - 1];
                                    _nextPoint = coords[ic + 1];
                                }

                                Map.Invalidate();
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        private void Configure()
        {
            YieldStyle = YieldStyles.LeftButton | YieldStyles.RightButton;
        }

        /// <summary>
        /// VertexMoved �̺�Ʈ�� �߻���ŵ�ϴ�.
        /// </summary>
        /// <param name="e">The event args.</param>
        private void OnVertexMoved(VertexMovedEventArgs e)
        {
            VertextMoved?.Invoke(this, e);
        }

        /// <summary>
        /// ������ �����ϱ� ���� ���� ���� ���콺�� �����̸� ����� �����Ͽ� �ش� ������ ���� ǥ�õ˴ϴ�.
        /// �� ����� �׽�Ʈ�Ͽ� ���� ���� ���� �� ����� �����մϴ�.
        /// </summary>
        /// <param name="e">GeoMouseArgs �Ű� ������ ���콺 ��ġ �� ������ ��ǥ�� ���� ������ �����մϴ�.</param>
        /// <returns>������ ���������� ���� ǥ�õǾ����� ���θ� ��Ÿ���� ���Դϴ�.</returns>
        private bool ShapeHighlight(GeoMouseArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), "e is null.");

            // �˻��������� ����K  6 X 6 �簢�� �������� �����.
            Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
            Extent ext = Map.PixelToProj(mouseRect);
            IPolygon env = ext.ToEnvelope().ToPolygon();

            bool requiresInvalidate = false;
            foreach (IFeature feature in _featureSet.Features)
            {
                // �������(��) �˻�
                if (_featureSet.FeatureType == FeatureType.Point || _featureSet.FeatureType == FeatureType.MultiPoint)
                {
                    if (_layer is MapPointLayer mpl)
                    {
                        int w = 3;
                        int h = 3;
                        if (mpl.GetCategory(feature) is PointCategory pc)
                        {
                            if (pc.Symbolizer.ScaleMode != ScaleMode.Geographic)
                            {
                                Size2D size = pc.Symbolizer.GetSize();
                                w = (int)size.Width;
                                h = (int)size.Height;
                            }
                        }

                        _imageRect = new Rectangle(e.Location.X - (w / 2), e.Location.Y - (h / 2), w, h);
                        if (_imageRect.Contains(Map.ProjToPixel(feature.Geometry.Coordinates[0])))
                        {
                            _activeFeature = feature;
                            _oldCategory = mpl.GetCategory(feature);

                            if (_selectedCategory == null)
                            {
                                _selectedCategory = _oldCategory.Copy();
                                _selectedCategory.SetColor(Color.Red);
                                _selectedCategory.LegendItemVisible = false;
                            }

                            mpl.SetCategory(_activeFeature, _selectedCategory);
                        }
                    }

                    requiresInvalidate = true;
                }
                else
                {
                    // �������(��, ��) �˻�
                    if (feature.Geometry.Intersects(env))
                    {
                        _activeFeature = feature;
                        _oldCategory = _layer.GetCategory(_activeFeature);

                        // ������
                        if (_featureSet.FeatureType == FeatureType.Polygon)
                        {
                            if (!(_activeCategory is IPolygonCategory pc))
                            {
                                _activeCategory = new PolygonCategory(Color.FromArgb(55, 255, 0, 0), Color.Red, 1)
                                {
                                    LegendItemVisible = false
                                };
                            }
                        }

                        // ����
                        if (_featureSet.FeatureType == FeatureType.Line)
                        {
                            if (!(_activeCategory is ILineCategory pc))
                            {
                                _activeCategory = new LineCategory(Color.Red, 3)
                                {
                                    LegendItemVisible = false
                                };
                            }
                        }

                        _layer.SetCategory(_activeFeature, _activeCategory);
                        requiresInvalidate = true;
                    }
                }
            }

            return requiresInvalidate;
        }

        /// <summary>
        /// ���콺�� ������ ���� �� ������ �ٽ� �������� �����ϴ� ���� ó���մϴ�.
        /// </summary>
        /// <param name="e">GeoMouseArgs �Ű� ������ ���콺 ��ġ �� ������ ��ǥ�� ���� ������ �����մϴ�.</param>
        /// <returns>true,�� ������ �ٽñ׸��Ⱑ �ʿ��� ���</returns>
        private bool ShapeRemoveHighlight(GeoMouseArgs e)
        {
            // ���� ǥ�õ� ����� ������ �ǹ̰� �����ϴ�.
            if (_oldCategory == null)
            {
                return false;
            }

            Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
            Extent ext = Map.PixelToProj(mouseRect);

            bool requiresInvalidate = false;
            IPolygon env = ext.ToEnvelope().ToPolygon();
            if (_layer is MapPointLayer mpl)
            {
                int w = 3;
                int h = 3;
                if (mpl.GetCategory(_activeFeature) is PointCategory pc)
                {
                    if (pc.Symbolizer.ScaleMode != ScaleMode.Geographic)
                    {
                        w = (int)pc.Symbolizer.GetSize().Width;
                        h = (int)pc.Symbolizer.GetSize().Height;
                    }
                }

                Rectangle rect = new Rectangle(e.Location.X - (w / 2), e.Location.Y - (h / 2), w * 2, h * 2);
                if (!rect.Contains(Map.ProjToPixel(_activeFeature.Geometry.Coordinates[0])))
                {
                    mpl.SetCategory(_activeFeature, _oldCategory);

                    _activeFeature = null;
                    requiresInvalidate = true;
                }
            }
            else
            {
                if (!_activeFeature.Geometry.Intersects(env))
                {
                    _layer.SetCategory(_activeFeature, _oldCategory);

                    _activeFeature = null;
                    requiresInvalidate = true;
                }
            }

            return requiresInvalidate;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loc"></param>
        private void UpdateDragCoordinate(Coordinate loc)
        {
            // ������ �巡���ϱ� ������ ���� ������ ������ ������ �� �����ϴ�
            _dragCoord.X = loc.X;
            _dragCoord.Y = loc.Y;

            if (_closedCircleCoord != null)
            {
                _closedCircleCoord.X = loc.X;
                _closedCircleCoord.Y = loc.Y;
            }

            Map.Invalidate();
        }

        /// <summary>
        /// ���� ���콺 ��ġ�� ������ ���� ��� ��ǥ�� �����մϴ�.
        /// </summary>
        private void VertexHighlight()
        {
            Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
            Extent ext = Map.PixelToProj(mouseRect);

            if (_activeVertex != null && !ext.Contains(_activeVertex))
            {
                _activeVertex = null;
                Map.Invalidate();
            }

            foreach (Coordinate c in _selectedFeature.Geometry.Coordinates)
            {
                if (ext.Contains(c))
                {
                    _activeVertex = c;
                    Map.Invalidate();
                }
            }
        }

        #endregion
    }
}