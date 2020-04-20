namespace DrPipe.Core.Views.Common
{
    partial class MonthRangeSelectorView
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbYear1 = new Syncfusion.WinForms.ListView.SfComboBox();
            this.cmbMonth1 = new Syncfusion.WinForms.ListView.SfComboBox();
            this.cmbYear2 = new Syncfusion.WinForms.ListView.SfComboBox();
            this.cmbMonth2 = new Syncfusion.WinForms.ListView.SfComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel4 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnOK = new Syncfusion.WinForms.Controls.SfButton();
            this.btnCancel = new Syncfusion.WinForms.Controls.SfButton();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbYear1
            // 
            this.cmbYear1.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cmbYear1.Location = new System.Drawing.Point(19, 20);
            this.cmbYear1.Name = "cmbYear1";
            this.cmbYear1.Size = new System.Drawing.Size(110, 27);
            this.cmbYear1.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbYear1.TabIndex = 6;
            // 
            // cmbMonth1
            // 
            this.cmbMonth1.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cmbMonth1.Location = new System.Drawing.Point(162, 20);
            this.cmbMonth1.Name = "cmbMonth1";
            this.cmbMonth1.Size = new System.Drawing.Size(55, 27);
            this.cmbMonth1.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbMonth1.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbMonth1.TabIndex = 7;
            // 
            // cmbYear2
            // 
            this.cmbYear2.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cmbYear2.Location = new System.Drawing.Point(19, 53);
            this.cmbYear2.Name = "cmbYear2";
            this.cmbYear2.Size = new System.Drawing.Size(110, 27);
            this.cmbYear2.Style.DropDownStyle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.cmbYear2.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbYear2.TabIndex = 8;
            // 
            // cmbMonth2
            // 
            this.cmbMonth2.DropDownStyle = Syncfusion.WinForms.ListView.Enums.DropDownStyle.DropDownList;
            this.cmbMonth2.Location = new System.Drawing.Point(162, 53);
            this.cmbMonth2.Name = "cmbMonth2";
            this.cmbMonth2.Size = new System.Drawing.Size(55, 27);
            this.cmbMonth2.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cmbMonth2.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.autoLabel3);
            this.groupBox1.Controls.Add(this.autoLabel4);
            this.groupBox1.Controls.Add(this.autoLabel2);
            this.groupBox1.Controls.Add(this.autoLabel1);
            this.groupBox1.Controls.Add(this.cmbMonth1);
            this.groupBox1.Controls.Add(this.cmbMonth2);
            this.groupBox1.Controls.Add(this.cmbYear1);
            this.groupBox1.Controls.Add(this.cmbYear2);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 92);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "기간설정";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Location = new System.Drawing.Point(135, 60);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(17, 12);
            this.autoLabel3.TabIndex = 13;
            this.autoLabel3.Text = "년";
            // 
            // autoLabel4
            // 
            this.autoLabel4.Location = new System.Drawing.Point(223, 60);
            this.autoLabel4.Name = "autoLabel4";
            this.autoLabel4.Size = new System.Drawing.Size(45, 12);
            this.autoLabel4.TabIndex = 12;
            this.autoLabel4.Text = "월 까지";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(223, 27);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(45, 12);
            this.autoLabel2.TabIndex = 11;
            this.autoLabel2.Text = "월 부터";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(135, 27);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(17, 12);
            this.autoLabel1.TabIndex = 10;
            this.autoLabel1.Text = "년";
            // 
            // btnOK
            // 
            this.btnOK.AccessibleName = "Button";
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnOK.Location = new System.Drawing.Point(120, 101);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 40);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "확인";
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Button";
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnCancel.Location = new System.Drawing.Point(205, 101);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "취소";
            // 
            // MonthRangeSelectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "MonthRangeSelectorView";
            this.Size = new System.Drawing.Size(294, 151);
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbYear2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbMonth2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.ListView.SfComboBox cmbYear1;
        private Syncfusion.WinForms.ListView.SfComboBox cmbMonth1;
        private Syncfusion.WinForms.ListView.SfComboBox cmbYear2;
        private Syncfusion.WinForms.ListView.SfComboBox cmbMonth2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel4;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.WinForms.Controls.SfButton btnOK;
        private Syncfusion.WinForms.Controls.SfButton btnCancel;
    }
}
