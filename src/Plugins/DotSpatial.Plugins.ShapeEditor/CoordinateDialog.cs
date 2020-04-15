// Copyright (c) DotSpatial Team. All rights reserved.
// Licensed under the MIT license. See License.txt file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using GeoAPI.Geometries;

namespace DotSpatial.Plugins.ShapeEditor
{
    /// <summary>
    /// 도형을 그리는 동안 좌표를 표시하는 대화 상자
    /// </summary>
    public partial class CoordinateDialog : Form
    {
        #region Fields
        private bool _showM;
        private bool _showZ;
        private ToolTip _ttHelp;
        #endregion

        #region  Constructors

        /// <summary>
        /// <see cref = "CoordinateDialog"/> 클래스의 새 인스턴스를 초기화
        /// </summary>
        public CoordinateDialog()
        {
            InitializeComponent();
            _showM = true;
            _showZ = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// 확인 버튼을 클릭하면 발생합니다.
        /// </summary>
        public event EventHandler CoordinateAdded;

        #endregion

        #region Properties

        /// <summary>
        /// Gets 현재의 값에 근거한 좌표
        /// </summary>
        public Coordinate Coordinate
        {
            get
            {
                Coordinate c = _showZ ? new Coordinate(_dbxX.Value, _dbxY.Value, _dbxZ.Value) : new Coordinate(_dbxX.Value, _dbxY.Value);
                if (_showM)
                {
                    c.M = _dbxM.Value;
                }

                return c;
            }
        }

        /// <summary>
        /// Gets or sets the M vlaue.
        /// </summary>
        public double M
        {
            get
            {
                return _dbxM.Value;
            }

            set
            {
                _dbxM.Text = value.ToString(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets or sets M 값을 표시할지를 나타내는 값
        /// </summary>
        public bool ShowMValues
        {
            get
            {
                return _showM;
            }

            set
            {
                if (_showM != value)
                {
                    if (value == false)
                    {
                        _dbxM.Visible = false;
                        Height -= 20;
                    }
                    else
                    {
                        _dbxM.Visible = true;
                        Height += 20;
                    }
                }

                _showM = value;
            }
        }

        /// <summary>
        /// Gets or sets Z 값을 표시할지를 나타내는 값
        /// </summary>
        public bool ShowZValues
        {
            get
            {
                return _showZ;
            }

            set
            {
                if (_showZ != value)
                {
                    if (value == false)
                    {
                        _dbxZ.Visible = false;
                        _dbxM.Top -= 20;
                        Height -= 20;
                    }
                    else
                    {
                        _dbxZ.Visible = true;
                        _dbxM.Top += 20;
                        Height += 20;
                    }
                }

                _showZ = value;
            }
        }

        /// <summary>
        /// Gets or sets the X value.
        /// </summary>
        public double X
        {
            get
            {
                return _dbxX.Value;
            }

            set
            {
                _dbxX.Text = value.ToString(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets or sets the Y value.
        /// </summary>
        public double Y
        {
            get
            {
                return _dbxY.Value;
            }

            set
            {
                _dbxY.Text = value.ToString(CultureInfo.CurrentCulture);
            }
        }

        /// <summary>
        /// Gets or sets the Z value.
        /// </summary>
        public double Z
        {
            get
            {
                return _dbxZ.Value;
            }

            set
            {
                _dbxZ.Text = value.ToString(CultureInfo.CurrentCulture);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// 사용자가 양식을 닫을 때이 양식을 폐기하지 않고 숨긴다.
        /// </summary>
        /// <param name="e">CancelEventArgs 매개 변수를 사용하면이 대화 상자를 완전히 닫을 수 있습니다.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
            Hide();
            e.Cancel = true;
            base.OnClosing(e);
        }

        private void CloseButtonClick(object sender, EventArgs e)
        {
            Hide();
        }

        private void CoordinateValidChanged(object sender, EventArgs e)
        {
            UpdateOk();
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            CoordinateAdded?.Invoke(this, EventArgs.Empty);

            Hide();
        }

        private void UpdateOk()
        {
            bool isValid = _dbxX.IsValid && _dbxY.IsValid;

            if (_showZ && !_dbxZ.IsValid)
            {
                isValid = false;
            }

            if (_showM && !_dbxM.IsValid)
            {
                isValid = false;
            }

            _btnOk.Enabled = isValid;
        }

        #endregion
    }
}