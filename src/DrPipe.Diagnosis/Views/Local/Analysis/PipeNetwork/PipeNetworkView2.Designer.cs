namespace DrPipe.Diagnosis.Views.Local.Analysis.PipeNetwork
{
    partial class PipeNetworkView2
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnClose = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSaveDb = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSaveRpt = new Syncfusion.WinForms.Controls.SfButton();
            this.btnRunEpanet = new Syncfusion.WinForms.Controls.SfButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadInp = new Syncfusion.WinForms.Controls.SfButton();
            this.btnSaveInp = new Syncfusion.WinForms.Controls.SfButton();
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.percentTextBox1 = new Syncfusion.Windows.Forms.Tools.PercentTextBox();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.integerTextBox1 = new Syncfusion.Windows.Forms.Tools.IntegerTextBox();
            this.autoLabel3 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.doubleTextBox1 = new Syncfusion.Windows.Forms.Tools.DoubleTextBox();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.splitContainerAdv2 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.elementHost = new System.Windows.Forms.Integration.ElementHost();
            this.tabControlAdv1 = new Syncfusion.Windows.Forms.Tools.TabControlAdv();
            this.tabPageAdv1 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.dgPipe = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.tabPageAdv2 = new Syncfusion.Windows.Forms.Tools.TabPageAdv();
            this.dgJunction = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.txtEpanetRpt = new Syncfusion.Windows.Forms.Tools.TextBoxExt();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv2)).BeginInit();
            this.splitContainerAdv2.Panel1.SuspendLayout();
            this.splitContainerAdv2.Panel2.SuspendLayout();
            this.splitContainerAdv2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).BeginInit();
            this.tabControlAdv1.SuspendLayout();
            this.tabPageAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPipe)).BeginInit();
            this.tabPageAdv2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgJunction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEpanetRpt)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.55116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.44884F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.splitContainerAdv1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1212, 677);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnClose);
            this.flowLayoutPanel2.Controls.Add(this.btnSaveDb);
            this.flowLayoutPanel2.Controls.Add(this.btnSaveRpt);
            this.flowLayoutPanel2.Controls.Add(this.btnRunEpanet);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(749, 635);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(460, 39);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.AccessibleName = "Button";
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnClose.Location = new System.Drawing.Point(357, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "닫기";
            this.btnClose.ThemeName = "";
            // 
            // btnSaveDb
            // 
            this.btnSaveDb.AccessibleName = "Button";
            this.btnSaveDb.AutoSize = true;
            this.btnSaveDb.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnSaveDb.Location = new System.Drawing.Point(251, 3);
            this.btnSaveDb.Name = "btnSaveDb";
            this.btnSaveDb.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSaveDb.Size = new System.Drawing.Size(100, 28);
            this.btnSaveDb.TabIndex = 8;
            this.btnSaveDb.Text = "DB 저장";
            this.btnSaveDb.ThemeName = "";
            // 
            // btnSaveRpt
            // 
            this.btnSaveRpt.AccessibleName = "Button";
            this.btnSaveRpt.AutoSize = true;
            this.btnSaveRpt.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnSaveRpt.Location = new System.Drawing.Point(145, 3);
            this.btnSaveRpt.Name = "btnSaveRpt";
            this.btnSaveRpt.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSaveRpt.Size = new System.Drawing.Size(100, 28);
            this.btnSaveRpt.TabIndex = 9;
            this.btnSaveRpt.Text = "레포트 저장";
            this.btnSaveRpt.ThemeName = "";
            // 
            // btnRunEpanet
            // 
            this.btnRunEpanet.AccessibleName = "Button";
            this.btnRunEpanet.AutoSize = true;
            this.btnRunEpanet.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnRunEpanet.Location = new System.Drawing.Point(39, 3);
            this.btnRunEpanet.Name = "btnRunEpanet";
            this.btnRunEpanet.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnRunEpanet.Size = new System.Drawing.Size(100, 28);
            this.btnRunEpanet.TabIndex = 10;
            this.btnRunEpanet.Text = "관망해석";
            this.btnRunEpanet.ThemeName = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLoadInp);
            this.flowLayoutPanel1.Controls.Add(this.btnSaveInp);
            this.flowLayoutPanel1.Controls.Add(this.autoLabel1);
            this.flowLayoutPanel1.Controls.Add(this.percentTextBox1);
            this.flowLayoutPanel1.Controls.Add(this.autoLabel2);
            this.flowLayoutPanel1.Controls.Add(this.integerTextBox1);
            this.flowLayoutPanel1.Controls.Add(this.autoLabel3);
            this.flowLayoutPanel1.Controls.Add(this.doubleTextBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 635);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(740, 39);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnLoadInp
            // 
            this.btnLoadInp.AccessibleName = "Button";
            this.btnLoadInp.AutoSize = true;
            this.btnLoadInp.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnLoadInp.Location = new System.Drawing.Point(3, 3);
            this.btnLoadInp.Name = "btnLoadInp";
            this.btnLoadInp.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnLoadInp.Size = new System.Drawing.Size(100, 30);
            this.btnLoadInp.TabIndex = 3;
            this.btnLoadInp.Text = "INP 열기";
            this.btnLoadInp.ThemeName = "";
            // 
            // btnSaveInp
            // 
            this.btnSaveInp.AccessibleName = "Button";
            this.btnSaveInp.AutoSize = true;
            this.btnSaveInp.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.btnSaveInp.Location = new System.Drawing.Point(109, 3);
            this.btnSaveInp.Name = "btnSaveInp";
            this.btnSaveInp.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.btnSaveInp.Size = new System.Drawing.Size(100, 28);
            this.btnSaveInp.TabIndex = 4;
            this.btnSaveInp.Text = "INP 저장";
            this.btnSaveInp.ThemeName = "";
            // 
            // autoLabel1
            // 
            this.autoLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autoLabel1.AutoSize = false;
            this.autoLabel1.Location = new System.Drawing.Point(215, 0);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(70, 36);
            this.autoLabel1.TabIndex = 5;
            this.autoLabel1.Text = "무수율(%)";
            this.autoLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // percentTextBox1
            // 
            this.percentTextBox1.BeforeTouchSize = new System.Drawing.Size(1206, 158);
            this.percentTextBox1.Location = new System.Drawing.Point(291, 8);
            this.percentTextBox1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.percentTextBox1.Name = "percentTextBox1";
            this.percentTextBox1.Size = new System.Drawing.Size(57, 21);
            this.percentTextBox1.TabIndex = 6;
            this.percentTextBox1.Text = "0.00%";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autoLabel2.AutoSize = false;
            this.autoLabel2.Location = new System.Drawing.Point(354, 0);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(38, 36);
            this.autoLabel2.TabIndex = 7;
            this.autoLabel2.Text = "N1";
            this.autoLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // integerTextBox1
            // 
            this.integerTextBox1.BeforeTouchSize = new System.Drawing.Size(1206, 158);
            this.integerTextBox1.IntegerValue = ((long)(1));
            this.integerTextBox1.Location = new System.Drawing.Point(398, 8);
            this.integerTextBox1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.integerTextBox1.Name = "integerTextBox1";
            this.integerTextBox1.Size = new System.Drawing.Size(57, 21);
            this.integerTextBox1.TabIndex = 8;
            this.integerTextBox1.Text = "1";
            // 
            // autoLabel3
            // 
            this.autoLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.autoLabel3.AutoSize = false;
            this.autoLabel3.Location = new System.Drawing.Point(461, 0);
            this.autoLabel3.Name = "autoLabel3";
            this.autoLabel3.Size = new System.Drawing.Size(130, 36);
            this.autoLabel3.TabIndex = 9;
            this.autoLabel3.Text = "일평균누수량(m³/일)";
            this.autoLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // doubleTextBox1
            // 
            this.doubleTextBox1.BeforeTouchSize = new System.Drawing.Size(1206, 158);
            this.doubleTextBox1.DoubleValue = 1D;
            this.doubleTextBox1.Location = new System.Drawing.Point(597, 8);
            this.doubleTextBox1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.doubleTextBox1.Name = "doubleTextBox1";
            this.doubleTextBox1.NumberDecimalDigits = 2;
            this.doubleTextBox1.ReadOnly = true;
            this.doubleTextBox1.Size = new System.Drawing.Size(57, 21);
            this.doubleTextBox1.TabIndex = 10;
            this.doubleTextBox1.Text = "1.00";
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 7;
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainerAdv1, 2);
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.Location = new System.Drawing.Point(3, 11);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            this.splitContainerAdv1.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.Controls.Add(this.splitContainerAdv2);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.Controls.Add(this.txtEpanetRpt);
            this.splitContainerAdv1.Size = new System.Drawing.Size(1206, 618);
            this.splitContainerAdv1.SplitterDistance = 453;
            this.splitContainerAdv1.TabIndex = 0;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            this.splitContainerAdv1.ThemeName = "None";
            // 
            // splitContainerAdv2
            // 
            this.splitContainerAdv2.BeforeTouchSize = 7;
            this.splitContainerAdv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAdv2.Name = "splitContainerAdv2";
            // 
            // splitContainerAdv2.Panel1
            // 
            this.splitContainerAdv2.Panel1.Controls.Add(this.elementHost);
            // 
            // splitContainerAdv2.Panel2
            // 
            this.splitContainerAdv2.Panel2.Controls.Add(this.tabControlAdv1);
            this.splitContainerAdv2.Size = new System.Drawing.Size(1206, 453);
            this.splitContainerAdv2.SplitterDistance = 600;
            this.splitContainerAdv2.TabIndex = 0;
            this.splitContainerAdv2.Text = "splitContainerAdv2";
            this.splitContainerAdv2.ThemeName = "None";
            // 
            // elementHost
            // 
            this.elementHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementHost.Location = new System.Drawing.Point(0, 0);
            this.elementHost.Name = "elementHost";
            this.elementHost.Size = new System.Drawing.Size(600, 453);
            this.elementHost.TabIndex = 0;
            this.elementHost.Text = "elementHost1";
            this.elementHost.Child = null;
            // 
            // tabControlAdv1
            // 
            this.tabControlAdv1.ActiveTabFont = new System.Drawing.Font("굴림", 9F);
            this.tabControlAdv1.ActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.BeforeTouchSize = new System.Drawing.Size(599, 453);
            this.tabControlAdv1.CloseButtonForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.CloseButtonHoverForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.CloseButtonPressedForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.CloseTabOnMiddleClick = false;
            this.tabControlAdv1.Controls.Add(this.tabPageAdv1);
            this.tabControlAdv1.Controls.Add(this.tabPageAdv2);
            this.tabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAdv1.InActiveTabForeColor = System.Drawing.Color.Empty;
            this.tabControlAdv1.Location = new System.Drawing.Point(0, 0);
            this.tabControlAdv1.Name = "tabControlAdv1";
            this.tabControlAdv1.SeparatorColor = System.Drawing.SystemColors.ControlDark;
            this.tabControlAdv1.ShowSeparator = false;
            this.tabControlAdv1.Size = new System.Drawing.Size(599, 453);
            this.tabControlAdv1.TabIndex = 0;
            this.tabControlAdv1.TabStyle = typeof(Syncfusion.Windows.Forms.Tools.TabRendererOffice2016White);
            this.tabControlAdv1.ThemeName = "TabRendererOffice2016White";
            // 
            // tabPageAdv1
            // 
            this.tabPageAdv1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPageAdv1.Controls.Add(this.dgPipe);
            this.tabPageAdv1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.tabPageAdv1.Image = null;
            this.tabPageAdv1.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv1.Location = new System.Drawing.Point(1, 21);
            this.tabPageAdv1.Name = "tabPageAdv1";
            this.tabPageAdv1.ShowCloseButton = true;
            this.tabPageAdv1.Size = new System.Drawing.Size(596, 430);
            this.tabPageAdv1.TabIndex = 1;
            this.tabPageAdv1.Text = "관로";
            this.tabPageAdv1.ThemesEnabled = false;
            // 
            // dgPipe
            // 
            this.dgPipe.AccessibleName = "Table";
            this.dgPipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPipe.Location = new System.Drawing.Point(0, 0);
            this.dgPipe.Name = "dgPipe";
            this.dgPipe.Size = new System.Drawing.Size(596, 430);
            this.dgPipe.TabIndex = 0;
            this.dgPipe.Text = "sfDataGrid1";
            // 
            // tabPageAdv2
            // 
            this.tabPageAdv2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tabPageAdv2.Controls.Add(this.dgJunction);
            this.tabPageAdv2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.tabPageAdv2.Image = null;
            this.tabPageAdv2.ImageSize = new System.Drawing.Size(16, 16);
            this.tabPageAdv2.Location = new System.Drawing.Point(1, 21);
            this.tabPageAdv2.Name = "tabPageAdv2";
            this.tabPageAdv2.ShowCloseButton = true;
            this.tabPageAdv2.Size = new System.Drawing.Size(596, 430);
            this.tabPageAdv2.TabIndex = 2;
            this.tabPageAdv2.Text = "절점";
            this.tabPageAdv2.ThemesEnabled = false;
            // 
            // dgJunction
            // 
            this.dgJunction.AccessibleName = "Table";
            this.dgJunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgJunction.Location = new System.Drawing.Point(0, 0);
            this.dgJunction.Name = "dgJunction";
            this.dgJunction.Size = new System.Drawing.Size(596, 430);
            this.dgJunction.TabIndex = 0;
            this.dgJunction.Text = "sfDataGrid2";
            // 
            // txtEpanetRpt
            // 
            this.txtEpanetRpt.BeforeTouchSize = new System.Drawing.Size(1206, 158);
            this.txtEpanetRpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEpanetRpt.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEpanetRpt.Location = new System.Drawing.Point(0, 0);
            this.txtEpanetRpt.Multiline = true;
            this.txtEpanetRpt.Name = "txtEpanetRpt";
            this.txtEpanetRpt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtEpanetRpt.Size = new System.Drawing.Size(1206, 158);
            this.txtEpanetRpt.TabIndex = 1;
            this.txtEpanetRpt.Text = "txtEpanetRpt";
            // 
            // PipeNetworkView2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PipeNetworkView2";
            this.Size = new System.Drawing.Size(1212, 677);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.integerTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doubleTextBox1)).EndInit();
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            this.splitContainerAdv2.Panel1.ResumeLayout(false);
            this.splitContainerAdv2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv2)).EndInit();
            this.splitContainerAdv2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControlAdv1)).EndInit();
            this.tabControlAdv1.ResumeLayout(false);
            this.tabPageAdv1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPipe)).EndInit();
            this.tabPageAdv2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgJunction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEpanetRpt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv2;
        private Syncfusion.Windows.Forms.Tools.TabControlAdv tabControlAdv1;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgPipe;
        private Syncfusion.Windows.Forms.Tools.TabPageAdv tabPageAdv2;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgJunction;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel3;
        private System.Windows.Forms.Integration.ElementHost elementHost;
        public Syncfusion.WinForms.Controls.SfButton btnLoadInp;
        public Syncfusion.WinForms.Controls.SfButton btnSaveInp;
        public Syncfusion.WinForms.Controls.SfButton btnClose;
        public Syncfusion.WinForms.Controls.SfButton btnSaveDb;
        public Syncfusion.WinForms.Controls.SfButton btnSaveRpt;
        public Syncfusion.WinForms.Controls.SfButton btnRunEpanet;
        public Syncfusion.Windows.Forms.Tools.PercentTextBox percentTextBox1;
        public Syncfusion.Windows.Forms.Tools.IntegerTextBox integerTextBox1;
        public Syncfusion.Windows.Forms.Tools.DoubleTextBox doubleTextBox1;
        public Syncfusion.Windows.Forms.Tools.TextBoxExt txtEpanetRpt;
    }
}
