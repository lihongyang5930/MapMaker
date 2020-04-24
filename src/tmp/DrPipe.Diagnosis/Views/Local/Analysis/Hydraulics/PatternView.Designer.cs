namespace DrPipe.Diagnosis.Views.Local.Analysis.Hydraulics
{
    partial class PatternView
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new Syncfusion.Windows.Forms.ButtonAdv();
            this.splitContainerAdv1 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.splitContainerAdv2 = new Syncfusion.Windows.Forms.Tools.SplitContainerAdv();
            this.dgPattern = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.dgPatternValue = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.chtPattern = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnImport = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnExport = new Syncfusion.Windows.Forms.ButtonAdv();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).BeginInit();
            this.splitContainerAdv1.Panel1.SuspendLayout();
            this.splitContainerAdv1.Panel2.SuspendLayout();
            this.splitContainerAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv2)).BeginInit();
            this.splitContainerAdv2.Panel1.SuspendLayout();
            this.splitContainerAdv2.Panel2.SuspendLayout();
            this.splitContainerAdv2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPattern)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatternValue)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.20635F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.79365F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.splitContainerAdv1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.073395F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.92661F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(845, 545);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnSave);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(627, 0);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel2.Size = new System.Drawing.Size(218, 43);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.AutoSize = true;
            this.btnSave.BeforeTouchSize = new System.Drawing.Size(95, 35);
            this.btnSave.Location = new System.Drawing.Point(120, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 35);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "저장";
            // 
            // splitContainerAdv1
            // 
            this.splitContainerAdv1.BeforeTouchSize = 13;
            this.tableLayoutPanel1.SetColumnSpan(this.splitContainerAdv1, 2);
            this.splitContainerAdv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv1.HotExpandLine = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.splitContainerAdv1.Location = new System.Drawing.Point(3, 46);
            this.splitContainerAdv1.Name = "splitContainerAdv1";
            // 
            // splitContainerAdv1.Panel1
            // 
            this.splitContainerAdv1.Panel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            this.splitContainerAdv1.Panel1.Controls.Add(this.splitContainerAdv2);
            // 
            // splitContainerAdv1.Panel2
            // 
            this.splitContainerAdv1.Panel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))));
            this.splitContainerAdv1.Panel2.Controls.Add(this.chtPattern);
            this.splitContainerAdv1.Size = new System.Drawing.Size(839, 496);
            this.splitContainerAdv1.SplitterDistance = 216;
            this.splitContainerAdv1.SplitterWidth = 13;
            this.splitContainerAdv1.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Office2016Colorful;
            this.splitContainerAdv1.TabIndex = 2;
            this.splitContainerAdv1.Text = "splitContainerAdv1";
            this.splitContainerAdv1.ThemeName = "Office2016Colorful";
            // 
            // splitContainerAdv2
            // 
            this.splitContainerAdv2.BeforeTouchSize = 13;
            this.splitContainerAdv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerAdv2.HotExpandLine = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.splitContainerAdv2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerAdv2.Name = "splitContainerAdv2";
            this.splitContainerAdv2.Orientation = System.Windows.Forms.Orientation.Vertical;
            // 
            // splitContainerAdv2.Panel1
            // 
            this.splitContainerAdv2.Panel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243))))));
            this.splitContainerAdv2.Panel1.Controls.Add(this.dgPattern);
            // 
            // splitContainerAdv2.Panel2
            // 
            this.splitContainerAdv2.Panel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243))))));
            this.splitContainerAdv2.Panel2.Controls.Add(this.dgPatternValue);
            this.splitContainerAdv2.Size = new System.Drawing.Size(216, 496);
            this.splitContainerAdv2.SplitterDistance = 122;
            this.splitContainerAdv2.SplitterWidth = 13;
            this.splitContainerAdv2.Style = Syncfusion.Windows.Forms.Tools.Enums.Style.Office2016Colorful;
            this.splitContainerAdv2.TabIndex = 0;
            this.splitContainerAdv2.Text = "splitContainerAdv2";
            this.splitContainerAdv2.ThemeName = "";
            // 
            // dgPattern
            // 
            this.dgPattern.AccessibleName = "Table";
            this.dgPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPattern.Location = new System.Drawing.Point(0, 0);
            this.dgPattern.Name = "dgPattern";
            this.dgPattern.Size = new System.Drawing.Size(216, 122);
            this.dgPattern.TabIndex = 0;
            this.dgPattern.Text = "sfDataGrid1";
            // 
            // dgPatternValue
            // 
            this.dgPatternValue.AccessibleName = "Table";
            this.dgPatternValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatternValue.Location = new System.Drawing.Point(0, 0);
            this.dgPatternValue.Name = "dgPatternValue";
            this.dgPatternValue.Size = new System.Drawing.Size(216, 361);
            this.dgPatternValue.TabIndex = 1;
            this.dgPatternValue.Text = "sfDataGrid2";
            // 
            // chtPattern
            // 
            this.chtPattern.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chtPattern.ChartArea.CursorReDraw = false;
            this.chtPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chtPattern.IsWindowLess = false;
            // 
            // 
            // 
            this.chtPattern.Legend.Location = new System.Drawing.Point(675, 75);
            this.chtPattern.Legend.Visible = false;
            this.chtPattern.Localize = null;
            this.chtPattern.Location = new System.Drawing.Point(0, 0);
            this.chtPattern.Name = "chtPattern";
            this.chtPattern.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chtPattern.PrimaryXAxis.Margin = true;
            this.chtPattern.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chtPattern.PrimaryYAxis.Margin = true;
            this.chtPattern.Size = new System.Drawing.Size(610, 496);
            this.chtPattern.TabIndex = 0;
            // 
            // 
            // 
            this.chtPattern.Title.Name = "Default";
            this.chtPattern.VisualTheme = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnImport);
            this.flowLayoutPanel1.Controls.Add(this.btnExport);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(627, 43);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImport.AutoSize = true;
            this.btnImport.BeforeTouchSize = new System.Drawing.Size(95, 35);
            this.btnImport.Location = new System.Drawing.Point(3, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(95, 35);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "불러오기";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExport.AutoSize = true;
            this.btnExport.BeforeTouchSize = new System.Drawing.Size(95, 35);
            this.btnExport.Location = new System.Drawing.Point(104, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(95, 35);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "내보내기";
            // 
            // PatternView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PatternView";
            this.Size = new System.Drawing.Size(845, 545);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.splitContainerAdv1.Panel1.ResumeLayout(false);
            this.splitContainerAdv1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv1)).EndInit();
            this.splitContainerAdv1.ResumeLayout(false);
            this.splitContainerAdv2.Panel1.ResumeLayout(false);
            this.splitContainerAdv2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerAdv2)).EndInit();
            this.splitContainerAdv2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPattern)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatternValue)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv1;
        private Syncfusion.Windows.Forms.Tools.SplitContainerAdv splitContainerAdv2;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgPattern;
        private Syncfusion.WinForms.DataGrid.SfDataGrid dgPatternValue;
        private Syncfusion.Windows.Forms.Chart.ChartControl chtPattern;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public Syncfusion.Windows.Forms.ButtonAdv btnSave;
        public Syncfusion.Windows.Forms.ButtonAdv btnImport;
        public Syncfusion.Windows.Forms.ButtonAdv btnExport;
    }
}
