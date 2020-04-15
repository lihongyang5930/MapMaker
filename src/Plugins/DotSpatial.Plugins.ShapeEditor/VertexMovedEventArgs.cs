// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System;
using DotSpatial.Data;

namespace DotSpatial.Plugins.ShapeEditor
{
    /// <summary>
    /// VertexMoved �̺�Ʈ�� ���� �μ��Դϴ�.
    /// </summary>
    public class VertexMovedEventArgs : EventArgs
    {
        #region  Constructors

        /// <summary>
        /// <see cref = "VertexMovedEventArgs"/> Ŭ������ �� �ν��Ͻ��� �ʱ�ȭ�մϴ�.
        /// </summary>
        /// <param name="affectedFeature">���� �̵��� �������޴� �������</param>
        public VertexMovedEventArgs(IFeature affectedFeature)
        {
            AffectedFeature = affectedFeature;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets ���� �������޴� �������
        /// </summary>
        public IFeature AffectedFeature { get; set; }

        #endregion
    }
}