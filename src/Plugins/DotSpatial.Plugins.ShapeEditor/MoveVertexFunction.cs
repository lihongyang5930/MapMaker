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
    /// MoveVertexFunction은 범례에서 활성으로 선택된 레이어를 대상으로 작동합니다.
    /// MoveVertex는 먼저 작업 할 도형을 선택하기 위해 도형을 클릭해야합니다.
    /// 마우스를 움직이면 편집 모드가 아닌 경우 편집 할 수있는 모양이 강조 표시됩니다.
    /// 도형을 클릭하면 해당 도형에 대한 "편집 모드"가 설정됩니다.
    /// 선택한 다각형의 모든 정점을 파란색으로 표시합니다.
    /// 정점에서 마우스를 드래그하여 편집을 시작합니다.
    /// 드래그하는 동안 마우스 오른쪽 버튼을 클릭하면 이동이 취소됩니다.
    /// 마우스 오른쪽 버튼을 클릭하면 편집 할 모양이 선택 취소됩니다.
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
        /// 지도가 정의 될 <see cref = "MoveVertexFunction"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="map">IMap 인터페이스를 구현하는 맵 컨트롤입니다.</param>
        public MoveVertexFunction(IMap map)
            : base(map)
        {
            Configure();
        }

        #endregion

        #region Events

        /// <summary>
        /// 정점이 이동 된 후 발생합니다.
        /// </summary>
        public event EventHandler<VertexMovedEventArgs> VertextMoved;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets 편집대상 레이어
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
        /// 선택한 도형을 선택 취소하고 강조 표시된 기능에서 강조 표시를 제거합니다.
        /// </summary>
        public void ClearSelection()
        {
            DeselectFeature();
            RemoveHighlightFromFeature();
            _oldCategory = null;
        }

        /// <summary>
        /// 어떤 이유로 레이어가 선택되지 않거나 선택 항목이 지워 져야하는 경우 호출해야합니다.
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
        /// 현재 강조 표시된 기능에서 강조 표시를 제거합니다.
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
                    // 편집할 도형이 선택되어 있으면, 편집할 정점을 선택합니다.
                    if (_selectedFeature != null)
                    {
                        // 정점 선택을 위한 영역을 설정합니다.
                        Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
                        Envelope env = Map.PixelToProj(mouseRect).ToEnvelope();

                        // 정점이 선택되었습니다.
                        if (CheckForVertexDrag(e))
                        {
                            return;
                        }

                        // 정점 선택이 발생하지 않았습니다.
                        if (!_selectedFeature.Geometry.Intersects(env.ToPolygon()))
                        {
                            // 선택을 취소합니다.
                            DeselectFeature();
                            return;
                        }
                    }

                    if (_activeFeature != null)
                    {
                        // 다각형과 선의 정점을 바로 드래그하지 마십시오. 먼저 정점을 표시하는 다각형을 선택한 다음 이동할 수 있습니다.
                        if (_featureSet.FeatureType == FeatureType.Polygon) // 면
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
                        else if (_featureSet.FeatureType == FeatureType.Line) // 선
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
                        else // 점
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
                // 스냅 시작
                Coordinate snappedCoord = e.GeographicLocation;
                if (ComputeSnappedLocation(e, ref snappedCoord))
                {
                    _mousePosition = Map.ProjToPixel(snappedCoord);
                }

                // 스냅 변경 적용
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
                    // 도형을 선택하기 전에 도형을 강조 표시 할 수 있어야합니다. 어느 것을 선택해야하는지 나타냅니다.
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
            // 이동증 마우스를 놓았을 놓았을때(위치이동결정시)
            if (e.Button == MouseButtons.Left && _dragging)
            {
                // [20200414] fdragons - add user confirm
                //if (DialogResult.OK != MessageBox.Show("이 위치로 이동 하시겠습니까?", "좌표이동", MessageBoxButtons.OKCancel))
                //{
                //    // [TODO] 이동 취소처리를 추가하여야 한다.
                //}
                _dragging = false;
                Map.IsBusy = false;

                _featureSet.InvalidateVertices();

                // 점
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
                else // 선, 면
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
        /// 이 함수는 현재 마우스 위치가 좌표점 위에 있는지 확인합니다.
        /// </summary>
        /// <param name="e">GeoMouseArgs 매개 변수는 마우스 위치 및 지리적 좌표에 대한 정보를 포함합니다.</param>
        /// <returns>True, 현재 마우스 위치가 정점 위에있는 경우</returns>
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
        /// VertexMoved 이벤트를 발생시킵니다.
        /// </summary>
        /// <param name="e">The event args.</param>
        private void OnVertexMoved(VertexMovedEventArgs e)
        {
            VertextMoved?.Invoke(this, e);
        }

        /// <summary>
        /// 도형을 선택하기 전에 도형 위로 마우스를 움직이면 모양을 변경하여 해당 도형이 강조 표시됩니다.
        /// 이 기능을 테스트하여 가장 먼저 강조 할 기능을 결정합니다.
        /// </summary>
        /// <param name="e">GeoMouseArgs 매개 변수는 마우스 위치 및 지리적 좌표에 대한 정보를 포함합니다.</param>
        /// <returns>도형이 성공적으로 강조 표시되었는지 여부를 나타내는 값입니다.</returns>
        private bool ShapeHighlight(GeoMouseArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e), "e is null.");

            // 검색영역으로 사용핳  6 X 6 사각형 폴리곤을 만든다.
            Rectangle mouseRect = new Rectangle(_mousePosition.X - 3, _mousePosition.Y - 3, 6, 6);
            Extent ext = Map.PixelToProj(mouseRect);
            IPolygon env = ext.ToEnvelope().ToPolygon();

            bool requiresInvalidate = false;
            foreach (IFeature feature in _featureSet.Features)
            {
                // 도형요소(점) 검색
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
                    // 도형요소(선, 면) 검색
                    if (feature.Geometry.Intersects(env))
                    {
                        _activeFeature = feature;
                        _oldCategory = _layer.GetCategory(_activeFeature);

                        // 폴리곤
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

                        // 라인
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
        /// 마우스가 도형을 떠날 때 색상을 다시 정상으로 변경하는 것을 처리합니다.
        /// </summary>
        /// <param name="e">GeoMouseArgs 매개 변수는 마우스 위치 및 지리적 좌표에 대한 정보를 포함합니다.</param>
        /// <returns>true,맵 프레임 다시그리기가 필요한 경우</returns>
        private bool ShapeRemoveHighlight(GeoMouseArgs e)
        {
            // 강조 표시된 모양이 없으면 의미가 없습니다.
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
            // 정점을 드래그하기 때문에 현재 선택한 도형은 변경할 수 없습니다
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
        /// 현재 마우스 위치의 정점을 편집 대상 좌표로 설정합니다.
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