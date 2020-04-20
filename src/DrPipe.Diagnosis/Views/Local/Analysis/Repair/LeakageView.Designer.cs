using Syncfusion.WinForms.Controls;

namespace DrPipe.Diagnosis.Views.Local.Analysis.Repair
{
    partial class LeakageView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCoeff = new Syncfusion.WinForms.Controls.SfButton();
            this.lblIcf = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.btnSetPeriod = new Syncfusion.WinForms.Controls.SfButton();
            this.txtPeriod = new Syncfusion.Windows.Forms.Tools.MaskedEditBox();
            this.label1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.buttonAdv3 = new Syncfusion.WinForms.Controls.SfButton();
            this.btnLeakageHistory = new Syncfusion.WinForms.Controls.SfButton();
            this.buttonAdv5 = new Syncfusion.WinForms.Controls.SfButton();
            this.buttonAdv6 = new Syncfusion.WinForms.Controls.SfButton();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.gradientPanel3 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).BeginInit();
            this.gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).BeginInit();
            this.gradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCoeff);
            this.groupBox1.Controls.Add(this.lblIcf);
            this.groupBox1.Controls.Add(this.btnSetPeriod);
            this.groupBox1.Controls.Add(this.txtPeriod);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "설정";
            // 
            // btnCoeff
            // 
            this.btnCoeff.AccessibleName = "Button";
            this.btnCoeff.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCoeff.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnCoeff.Location = new System.Drawing.Point(792, 19);
            this.btnCoeff.Name = "btnCoeff";
            this.btnCoeff.Size = new System.Drawing.Size(131, 21);
            this.btnCoeff.TabIndex = 4;
            this.btnCoeff.Text = "배경누수 계수설정";
            this.btnCoeff.ThemeName = "Office2016Colourful";
            // 
            // lblIcf
            // 
            this.lblIcf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIcf.Location = new System.Drawing.Point(702, 23);
            this.lblIcf.Name = "lblIcf";
            this.lblIcf.Size = new System.Drawing.Size(51, 12);
            this.lblIcf.TabIndex = 3;
            this.lblIcf.Text = "ICF : ~?";
            // 
            // btnSetPeriod
            // 
            this.btnSetPeriod.AccessibleName = "Button";
            this.btnSetPeriod.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnSetPeriod.Location = new System.Drawing.Point(239, 19);
            this.btnSetPeriod.Name = "btnSetPeriod";
            this.btnSetPeriod.Size = new System.Drawing.Size(65, 21);
            this.btnSetPeriod.TabIndex = 2;
            this.btnSetPeriod.Text = "기간설정";
            this.btnSetPeriod.ThemeName = "Office2016Colourful";
            // 
            // txtPeriod
            // 
            this.txtPeriod.BeforeTouchSize = new System.Drawing.Size(168, 21);
            this.txtPeriod.Location = new System.Drawing.Point(65, 19);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(168, 21);
            this.txtPeriod.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "분석기간";
            // 
            // buttonAdv3
            // 
            this.buttonAdv3.AccessibleName = "Button";
            this.buttonAdv3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonAdv3.Location = new System.Drawing.Point(3, 3);
            this.buttonAdv3.Name = "buttonAdv3";
            this.buttonAdv3.Size = new System.Drawing.Size(160, 26);
            this.buttonAdv3.TabIndex = 1;
            this.buttonAdv3.Text = "사용량+유입유량 입력";
            this.buttonAdv3.ThemeName = "Office2016Colourful";
            // 
            // btnLeakageHistory
            // 
            this.btnLeakageHistory.AccessibleName = "Button";
            this.btnLeakageHistory.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnLeakageHistory.Location = new System.Drawing.Point(163, 3);
            this.btnLeakageHistory.Name = "btnLeakageHistory";
            this.btnLeakageHistory.Size = new System.Drawing.Size(160, 26);
            this.btnLeakageHistory.TabIndex = 2;
            this.btnLeakageHistory.Text = "파열누수이력 정보";
            this.btnLeakageHistory.ThemeName = "Office2016Colourful";
            // 
            // buttonAdv5
            // 
            this.buttonAdv5.AccessibleName = "Button";
            this.buttonAdv5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdv5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonAdv5.Location = new System.Drawing.Point(800, 6);
            this.buttonAdv5.Name = "buttonAdv5";
            this.buttonAdv5.Size = new System.Drawing.Size(126, 26);
            this.buttonAdv5.TabIndex = 3;
            this.buttonAdv5.Text = "닫기";
            this.buttonAdv5.ThemeName = "Office2016Colourful";
            // 
            // buttonAdv6
            // 
            this.buttonAdv6.AccessibleName = "Button";
            this.buttonAdv6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAdv6.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.buttonAdv6.Location = new System.Drawing.Point(668, 6);
            this.buttonAdv6.Name = "buttonAdv6";
            this.buttonAdv6.Size = new System.Drawing.Size(126, 26);
            this.buttonAdv6.TabIndex = 4;
            this.buttonAdv6.Text = "누수분석실행";
            this.buttonAdv6.ThemeName = "Office2016Colourful";
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel1.Controls.Add(this.groupBox1);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(929, 58);
            this.gradientPanel1.TabIndex = 5;
            // 
            // gradientPanel2
            // 
            this.gradientPanel2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel2.Controls.Add(this.buttonAdv3);
            this.gradientPanel2.Controls.Add(this.btnLeakageHistory);
            this.gradientPanel2.Controls.Add(this.buttonAdv5);
            this.gradientPanel2.Controls.Add(this.buttonAdv6);
            this.gradientPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gradientPanel2.Location = new System.Drawing.Point(0, 503);
            this.gradientPanel2.Name = "gradientPanel2";
            this.gradientPanel2.Size = new System.Drawing.Size(929, 45);
            this.gradientPanel2.TabIndex = 6;
            // 
            // gradientPanel3
            // 
            this.gradientPanel3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gradientPanel3.Controls.Add(this.sfDataGrid1);
            this.gradientPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel3.Location = new System.Drawing.Point(0, 58);
            this.gradientPanel3.Name = "gradientPanel3";
            this.gradientPanel3.Size = new System.Drawing.Size(929, 445);
            this.gradientPanel3.TabIndex = 7;
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.Location = new System.Drawing.Point(3, 6);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(920, 431);
            this.sfDataGrid1.TabIndex = 0;
            this.sfDataGrid1.Text = "sfDataGrid1";
            // 
            // LeakageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gradientPanel3);
            this.Controls.Add(this.gradientPanel2);
            this.Controls.Add(this.gradientPanel1);
            this.Name = "LeakageView";
            this.Size = new System.Drawing.Size(929, 548);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel2)).EndInit();
            this.gradientPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel3)).EndInit();
            this.gradientPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel label1;
        private SfButton buttonAdv3;
        private SfButton buttonAdv5;
        private SfButton buttonAdv6;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel3;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        public SfButton btnSetPeriod;
        public Syncfusion.Windows.Forms.Tools.MaskedEditBox txtPeriod;
        public SfButton btnCoeff;
        public Syncfusion.Windows.Forms.Tools.AutoLabel lblIcf;
        public SfButton btnLeakageHistory;
    }
}
