// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using DotSpatial.Symbology;

namespace DotSpatial.Plugins.ShapeEditor
{
    /// <summary>
    /// datagridview를 통해 스냅 가능한 속성을 제어하는 클래스입니다.
    /// </summary>
    public class SnapLayer
    {
        #region Fields

        /// <summary>
        /// 스냅 가능한 속성을 변경할 수있는 레이어입니다.
        /// </summary>
        private readonly IFeatureLayer _layer;

        #endregion

        #region Constructors

        /// <summary>
        /// <see cref = "SnapLayer"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="pLayer">SnapLayer 객체가 생성되는 레이어입니다.</param>
        public SnapLayer(IFeatureLayer pLayer)
        {
            _layer = pLayer;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets 레이어 이름으로 DataGridView에 표시 할 수 있습니다.
        /// </summary>
        public string LayerName => _layer.LegendText;

        /// <summary>
        /// Gets or sets 레이어 피처의 좌표에 스냅이 허용되는지 여부를 나타내는 값.
        /// </summary>
        public bool Snappable
        {
            get
            {
                return _layer.Snappable;
            }

            set
            {
                _layer.Snappable = value;
            }
        }

        #endregion
    }
}