// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System;
using DotSpatial.Data;

namespace DotSpatial.Plugins.ShapeEditor
{
    /// <summary>
    /// VertexMoved 이벤트에 대한 인수입니다.
    /// </summary>
    public class VertexMovedEventArgs : EventArgs
    {
        #region  Constructors

        /// <summary>
        /// <see cref = "VertexMovedEventArgs"/> 클래스의 새 인스턴스를 초기화합니다.
        /// </summary>
        /// <param name="affectedFeature">정점 이동의 영향을받는 도형요소</param>
        public VertexMovedEventArgs(IFeature affectedFeature)
        {
            AffectedFeature = affectedFeature;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets 편집 영향을받는 도형요소
        /// </summary>
        public IFeature AffectedFeature { get; set; }

        #endregion
    }
}