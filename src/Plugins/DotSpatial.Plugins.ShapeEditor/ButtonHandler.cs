// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Controls.Header;
using DotSpatial.Data;
using DotSpatial.Symbology;

namespace DotSpatial.Plugins.ShapeEditor
{
    /// <summary>
    /// 버튼 표시 방법과 버튼을 누를 때 발생하는 동작을 구성합니다.
    /// </summary>
    public class ButtonHandler : IDisposable
    {
        #region Fields

        private readonly IHeaderControl _header;
        private IFeatureLayer _activeLayer;
        private SimpleActionItem _newLayerBtn;
        private SimpleActionItem _addShapeBtn;
        private SimpleActionItem _moveVertexBtn;
        private SimpleActionItem _snapTargetBtn;
        private AddShapeFunction _addShapeFunction;
        private MoveVertexFunction _moveVertexFunction;
        private bool _disposed;

        private bool _doSnapping = true;

        private IMap _geoMap;

        #endregion

        #region  Constructors

        /// <summary>
        /// <see cref = "ButtonHandler"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="manager">The app manager.</param>
        public ButtonHandler(AppManager manager)
        {
            if (manager.HeaderControl == null)
                throw new ArgumentNullException(nameof(manager), MessageStrings.HeaderControlMustBeAvailable);

            _header = manager.HeaderControl;

            AddButtons();
        }

        /// <summary>
        /// <see cref = "ButtonHandler"/> 클래스의 인스턴스를 마무리합니다.
        /// </summary>
        ~ButtonHandler()
        {
            Dispose(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets "dispose"메소드가 호출되었는지 여부를 나타내는 값
        /// </summary>
        public bool IsDisposed => _disposed;

        /// <summary>
        /// Gets or sets 편집 대상 지도 속성
        /// </summary>
        public IMap Map
        {
            get
            {
                return _geoMap;
            }

            set
            {
                _geoMap = value;
                if (_geoMap?.Layers?.SelectedLayer != null)
                {
                    SetActiveLayer(_geoMap.Layers.SelectedLayer);
                }

                if (_geoMap?.Layers != null)
                {
                    _geoMap.Layers.LayerSelected += LayersLayerSelected;
                    _geoMap.MapFrame.LayerSelected += MapFrameLayerSelected;
                    _geoMap.MapFrame.LayerRemoved += MapFrameOnLayerRemoved;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 실제로 이것은 일회용품을 만들지 만 소유하지는 않습니다.
        /// 리본이 폐기되면 품목이 제거됩니다.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // This exists to prevent FX Cop from complaining.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 이 처리기를 삭제하여 추가를 담당하는 모든 단추를 제거합니다.
        /// </summary>
        /// <param name="disposeManagedResources">Disposes of the resources.</param>
        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (!_disposed)
            {
                // 추가 된 컨트롤을 제거합니다.
                RemoveControls();

                if (disposeManagedResources)
                {
                    if (_addShapeFunction != null && !_addShapeFunction.IsDisposed)
                    {
                        _addShapeFunction.Dispose();
                    }

                    _geoMap = null;
                    _activeLayer = null;
                    _moveVertexFunction = null;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// 추가된 도구 모음 버튼의 처리 핸들러를 설정합니다.
        /// </summary>
        private void AddButtons()
        {
            const string ShapeEditorMenuKey = "kShapeEditor";

            // _Header.Add(new RootItem(ShapeEditorMenuKey, "Shape Editing"));

            //[20200401] fdragons - comments out
            _newLayerBtn = new SimpleActionItem(ShapeEditorMenuKey, ShapeEditorResources.New, NewButtonClick)
            {
                GroupCaption = "Shape Editor",
                SmallImage = ShapeEditorResources.NewShapefile.ToBitmap(),
                RootKey = HeaderControl.HomeRootItemKey,
            };
            _header.Add(_newLayerBtn);

            _addShapeBtn = new SimpleActionItem(ShapeEditorMenuKey, ShapeEditorResources.Add_Shape, AddShapeButtonClick)
            {
                GroupCaption = "Shape Editor",
                SmallImage = ShapeEditorResources.NewShape.ToBitmap(),
                RootKey = HeaderControl.HomeRootItemKey,
                Enabled = false,
            };
            _header.Add(_addShapeBtn);

            _moveVertexBtn = new SimpleActionItem(ShapeEditorMenuKey, ShapeEditorResources.Move_Vertex, MoveVertexButtonClick)
            {
                GroupCaption = "Shape Editor",
                SmallImage = ShapeEditorResources.move,
                RootKey = HeaderControl.HomeRootItemKey,
                Enabled = false,
            };
            _header.Add(_moveVertexBtn);

            _snapTargetBtn = new SimpleActionItem(ShapeEditorMenuKey, ShapeEditorResources.Snapping, SnappingButtonClick)
            {
                GroupCaption = "Shape Editor",
                SmallImage = ShapeEditorResources.SnappingIcon.ToBitmap(),
                RootKey = HeaderControl.HomeRootItemKey
            };
            _header.Add(_snapTargetBtn);
        }

        /// <summary>
        /// [20200401] fdragons - 도형요소(점, 선, 면) 신규 생성 처리
        ///                     - 현재 선택된 레이어의 도형요소를 생성한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddShapeButtonClick(object sender, EventArgs e)
        {
            if (_geoMap == null)
            {
                return;
            }

            if (_geoMap.Layers.SelectedLayer != null)
            {
                _activeLayer = _geoMap.Layers.SelectedLayer as IFeatureLayer;
            }

            if (_activeLayer == null)
            {
                MessageBox.Show("편집 대상 레이어를 선택하여 주십시요.");
                return;
            }

            if (_addShapeFunction == null)
            {
                _addShapeFunction = new AddShapeFunction(_geoMap)
                {
                    Name = "AddShape"
                };
            }

            if (_geoMap.MapFunctions.Contains(_addShapeFunction) == false)
            {
                _geoMap.MapFunctions.Add(_addShapeFunction);
            }

            _geoMap.FunctionMode = FunctionMode.None;
            _geoMap.Cursor = Cursors.Hand;

            UpdateAddShapeFunctionLayer();
            _addShapeFunction.Activate();
        }

        /// <summary>
        /// 범례에서 레이어를 선택하면, 편집 레이어로 설정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LayersLayerSelected(object sender, LayerSelectedEventArgs e)
        {
            SetActiveLayer(e.Layer);
        }

        /// <summary>
        /// 맵프레임에서 레이어를 선택하면, 편집 레이어로 설정한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapFrameLayerSelected(object sender, LayerSelectedEventArgs e)
        {
            if (!e.IsSelected && e.Layer == _activeLayer)
            {
                _activeLayer = null;
                
                // 예외를 방지하기 위해 강조 표시된 상태를 재설정합니다.
                _moveVertexFunction?.ClearSelection();

                return;
            }

            _activeLayer = e.Layer as IFeatureLayer;

            if (_activeLayer == null)
            {
                _addShapeBtn.Enabled = false;
                _moveVertexBtn.Enabled = false;

                return;
            }

            // [20200409] fdragons
            _geoMap.FunctionMode = FunctionMode.Pan;
            _geoMap.Cursor = Cursors.Hand;

            // 편집중인 도형이 널이 아니기 때문에 둘 다 업데이트한다.
            if (_moveVertexFunction != null)
                UpdateMoveVertexFunctionLayer();

            if (_addShapeFunction != null) 
                UpdateAddShapeFunctionLayer();
        }

        /// <summary>
        /// 맵프레임에서 레이어가 삭제되면, 편집 레이어를 초기화한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapFrameOnLayerRemoved(object sender, LayerEventArgs e)
        {
            if (e.Layer == _activeLayer) _activeLayer = null;
        }

        /// <summary>
        /// 도형요소 구성좌표 편집하기, MoveVertexFunction을 Activate한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveVertexButtonClick(object sender, EventArgs e)
        {
            if (_geoMap == null)
            {
                return;
            }

            if (_geoMap.Layers.SelectedLayer != null)
            {
                _activeLayer = _geoMap.Layers.SelectedLayer as IFeatureLayer;
            }

            if (_activeLayer == null)
            {
                MessageBox.Show("편집 대상 레이어를 선택하여 주십시요.");
                return;
            }

            // 편집함수가 없으면 편집함수를 생성한다.
            if (_moveVertexFunction == null)
            {
                _moveVertexFunction = new MoveVertexFunction(_geoMap)
                {
                    Name = "MoveVertex"
                };
            }

            // 현재 맵 컨트롤에 편집함수를가 없으면, 생성한 편집함수를 추가한다.
            if (_geoMap.MapFunctions.Contains(_moveVertexFunction) == false)
            {
                _geoMap.MapFunctions.Add(_moveVertexFunction);
            }

            _geoMap.FunctionMode = FunctionMode.None;
            _geoMap.Cursor = Cursors.Cross;

            _moveVertexFunction.Layer = _activeLayer;

            UpdateMoveVertexFunctionLayer();
            _moveVertexFunction.Activate();
        }

        /// <summary>
        /// 신규 레이어 생성하고, 편집레이어로 설정
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewButtonClick(object sender, EventArgs e)
        {
            // 신규 레이어 명 및 도형요소 타입을 선택한다.
            FeatureTypeDialog dlg = new FeatureTypeDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            // 도형요소 생성
            FeatureSet fs = new FeatureSet(dlg.FeatureType);
            if (_geoMap.Projection != null)
            {
                fs.Projection = _geoMap.Projection;
            }

            fs.CoordinateType = dlg.CoordinateType;
            fs.IndexMode = false;

            // 레이어 생성
            IMapFeatureLayer layer;
            if (!string.IsNullOrWhiteSpace(dlg.Filename))
            {
                fs.SaveAs(dlg.Filename, true);
                layer = (IMapFeatureLayer)_geoMap.Layers.Add(dlg.Filename);
            }
            else
            {
                layer = _geoMap.Layers.Add(fs);
            }

            // 편집레이어로 설정
            layer.EditMode = true;
            _geoMap.Layers.SelectedLayer = layer;
            layer.LegendText = !string.IsNullOrEmpty(layer.DataSet.Name) ? layer.DataSet.Name : _geoMap.Layers.UnusedName("New Layer");
        }

        /// <summary>
        /// 추가 된 모든 컨트롤을 제거합니다.
        /// </summary>
        private void RemoveControls()
        {
            // Todo: restore cursor if necessary.
            if (_addShapeFunction != null && _geoMap != null)
            {
                if (_geoMap.MapFunctions.Contains(_addShapeFunction))
                {
                    _geoMap.MapFunctions.Remove(_addShapeFunction);
                }
            }

            if (_moveVertexFunction != null && _geoMap != null)
            {
                if (_geoMap.MapFunctions.Contains(_moveVertexFunction))
                {
                    _geoMap.MapFunctions.Remove(_moveVertexFunction);
                }
            }
        }

        private void SetActiveLayer(ILayer layer)
        {
            if (!(layer is IFeatureLayer fl))
            {
                _addShapeBtn.Enabled = false;
                _moveVertexBtn.Enabled = false;
            }
            else
            {
                _activeLayer = fl;
                _addShapeBtn.Enabled = true;
                _moveVertexBtn.Enabled = true;
            }
        }

        /// <summary>
        /// 스냅 대상 레이어를 설정합니다.
        /// </summary>
        /// <param name="func"></param>
        private void SetSnapLayers(SnappableMapFunction func)
        {
            func.DoSnapping = _doSnapping;
            if (!_doSnapping)
                return;

            // 모든 레이어를 스냅 할 수 있도록 합니다.
            foreach (var fl in _geoMap.GetFeatureLayers())
            {
                func.AddLayerToSnap(fl);
            }
        }

        /// <summary>
        /// 스냅 대상 레이어 선택 다이얼로그를 처리합니다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnappingButtonClick(object sender, EventArgs e)
        {
            using (SnapSettingsDialog dlg = new SnapSettingsDialog(_geoMap)
            {
                DoSnapping = _doSnapping
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _doSnapping = dlg.DoSnapping;
                    if (_moveVertexFunction != null)
                    {
                        // 편집을 중단하지 않고 스냅 설정을 업데이트 합니다.
                        _moveVertexFunction.DoSnapping = _doSnapping;
                        if (_doSnapping)
                        {
                            SetSnapLayers(_moveVertexFunction);
                        }
                    }

                    if (_addShapeFunction != null)
                    {
                        _addShapeFunction.DoSnapping = _doSnapping;
                        if (_doSnapping)
                        {
                            SetSnapLayers(_addShapeFunction);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 활성 편집레이어를 설정하고, 스냅 레이어에 추가합니다.
        /// </summary>
        private void UpdateAddShapeFunctionLayer()
        {
            _addShapeFunction.Layer = _activeLayer;
            SetSnapLayers(_addShapeFunction);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateMoveVertexFunctionLayer()
        {
            // 예외를 방지하기 위해 강조 표시된 도형요소도 재설정해야합니다
            _moveVertexFunction.ClearSelection();
            _moveVertexFunction.Layer = _activeLayer;
            SetSnapLayers(_moveVertexFunction);
        }

        #endregion
    }
}