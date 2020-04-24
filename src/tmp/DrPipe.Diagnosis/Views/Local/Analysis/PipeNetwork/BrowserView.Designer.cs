namespace DrPipe.Diagnosis.Views.Local.Analysis.PipeNetwork
{
    partial class BrowserView
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
            Syncfusion.Windows.Forms.Chart.ChartSeries chartSeries1 = new Syncfusion.Windows.Forms.Chart.ChartSeries();
            Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo chartCustomShapeInfo1 = new Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo();
            Syncfusion.Windows.Forms.Chart.ChartLineInfo chartLineInfo1 = new Syncfusion.Windows.Forms.Chart.ChartLineInfo();
            Syncfusion.Windows.Forms.Chart.ChartToolBarSaveItem chartToolBarSaveItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarSaveItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarCopyItem chartToolBarCopyItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarCopyItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarPrintItem chartToolBarPrintItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarPrintItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarPrintPreviewItem chartToolBarPrintPreviewItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarPrintPreviewItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarSplitter chartToolBarSplitter1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarSplitter();
            Syncfusion.Windows.Forms.Chart.ChartToolBarPaletteItem chartToolBarPaletteItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarPaletteItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarStyleItem chartToolBarStyleItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarStyleItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarTypeItem chartToolBarTypeItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarTypeItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarSeries3DItem chartToolBarSeries3DItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarSeries3DItem();
            Syncfusion.Windows.Forms.Chart.ChartToolBarShowLegendItem chartToolBarShowLegendItem1 = new Syncfusion.Windows.Forms.Chart.ChartToolBarShowLegendItem();
            this.cmbNodeValues = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbLinkValues = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.cmbTimeSteps = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFirstTimeStep = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnBackTimeStep = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnStopTimeStep = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnForwardTimeStep = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnRefresh = new Syncfusion.Windows.Forms.ButtonAdv();
            this.quantityPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbIndices = new Syncfusion.Windows.Forms.Tools.ComboBoxAdv();
            this.pressurePanel = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPressure1 = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.txtPressure2 = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.velocityPanel = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtVelocity = new Syncfusion.Windows.Forms.Tools.NumericUpDownExt();
            this.chartControl = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.legendPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblCount3 = new System.Windows.Forms.Label();
            this.lblLegend3 = new System.Windows.Forms.Label();
            this.lblLegend1 = new System.Windows.Forms.Label();
            this.lblLegend2 = new System.Windows.Forms.Label();
            this.lblCount1 = new System.Windows.Forms.Label();
            this.lblCount2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cmbNodeValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLinkValues)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeSteps)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.quantityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIndices)).BeginInit();
            this.pressurePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPressure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPressure2)).BeginInit();
            this.velocityPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVelocity)).BeginInit();
            this.legendPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbNodeValues
            // 
            this.cmbNodeValues.BeforeTouchSize = new System.Drawing.Size(153, 20);
            this.cmbNodeValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNodeValues.Location = new System.Drawing.Point(3, 15);
            this.cmbNodeValues.Name = "cmbNodeValues";
            this.cmbNodeValues.Size = new System.Drawing.Size(153, 20);
            this.cmbNodeValues.TabIndex = 0;
            // 
            // cmbLinkValues
            // 
            this.cmbLinkValues.BeforeTouchSize = new System.Drawing.Size(153, 20);
            this.cmbLinkValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLinkValues.Location = new System.Drawing.Point(3, 64);
            this.cmbLinkValues.Name = "cmbLinkValues";
            this.cmbLinkValues.Size = new System.Drawing.Size(153, 20);
            this.cmbLinkValues.TabIndex = 1;
            // 
            // cmbTimeSteps
            // 
            this.cmbTimeSteps.BeforeTouchSize = new System.Drawing.Size(153, 20);
            this.cmbTimeSteps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeSteps.Location = new System.Drawing.Point(3, 113);
            this.cmbTimeSteps.Name = "cmbTimeSteps";
            this.cmbTimeSteps.Size = new System.Drawing.Size(153, 20);
            this.cmbTimeSteps.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cmbNodeValues);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cmbLinkValues);
            this.flowLayoutPanel1.Controls.Add(this.label3);
            this.flowLayoutPanel1.Controls.Add(this.cmbTimeSteps);
            this.flowLayoutPanel1.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel1.Controls.Add(this.btnRefresh);
            this.flowLayoutPanel1.Controls.Add(this.quantityPanel);
            this.flowLayoutPanel1.Controls.Add(this.pressurePanel);
            this.flowLayoutPanel1.Controls.Add(this.velocityPanel);
            this.flowLayoutPanel1.Controls.Add(this.chartControl);
            this.flowLayoutPanel1.Controls.Add(this.legendPanel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(468, 830);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nodes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Links";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnFirstTimeStep);
            this.flowLayoutPanel2.Controls.Add(this.btnBackTimeStep);
            this.flowLayoutPanel2.Controls.Add(this.btnStopTimeStep);
            this.flowLayoutPanel2.Controls.Add(this.btnForwardTimeStep);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 137);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(208, 48);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // btnFirstTimeStep
            // 
            this.btnFirstTimeStep.BeforeTouchSize = new System.Drawing.Size(40, 30);
            this.btnFirstTimeStep.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFirstTimeStep.Location = new System.Drawing.Point(3, 3);
            this.btnFirstTimeStep.Name = "btnFirstTimeStep";
            this.btnFirstTimeStep.Size = new System.Drawing.Size(40, 30);
            this.btnFirstTimeStep.TabIndex = 0;
            this.btnFirstTimeStep.Text = "◀◀";
            // 
            // btnBackTimeStep
            // 
            this.btnBackTimeStep.BeforeTouchSize = new System.Drawing.Size(40, 30);
            this.btnBackTimeStep.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBackTimeStep.Location = new System.Drawing.Point(49, 3);
            this.btnBackTimeStep.Name = "btnBackTimeStep";
            this.btnBackTimeStep.Size = new System.Drawing.Size(40, 30);
            this.btnBackTimeStep.TabIndex = 1;
            this.btnBackTimeStep.Text = "◀";
            // 
            // btnStopTimeStep
            // 
            this.btnStopTimeStep.BeforeTouchSize = new System.Drawing.Size(40, 30);
            this.btnStopTimeStep.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStopTimeStep.Location = new System.Drawing.Point(95, 3);
            this.btnStopTimeStep.Name = "btnStopTimeStep";
            this.btnStopTimeStep.Size = new System.Drawing.Size(40, 30);
            this.btnStopTimeStep.TabIndex = 2;
            this.btnStopTimeStep.Text = "❚❚";
            // 
            // btnForwardTimeStep
            // 
            this.btnForwardTimeStep.BeforeTouchSize = new System.Drawing.Size(40, 30);
            this.btnForwardTimeStep.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnForwardTimeStep.Location = new System.Drawing.Point(141, 3);
            this.btnForwardTimeStep.Name = "btnForwardTimeStep";
            this.btnForwardTimeStep.Size = new System.Drawing.Size(40, 30);
            this.btnForwardTimeStep.TabIndex = 3;
            this.btnForwardTimeStep.Text = "▶";
            // 
            // btnRefresh
            // 
            this.btnRefresh.BeforeTouchSize = new System.Drawing.Size(178, 30);
            this.btnRefresh.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRefresh.Location = new System.Drawing.Point(3, 188);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(178, 30);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "새로고침";
            // 
            // quantityPanel
            // 
            this.quantityPanel.Controls.Add(this.label4);
            this.quantityPanel.Controls.Add(this.cmbIndices);
            this.quantityPanel.Location = new System.Drawing.Point(3, 224);
            this.quantityPanel.Name = "quantityPanel";
            this.quantityPanel.Size = new System.Drawing.Size(205, 49);
            this.quantityPanel.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "수량관리 성능지표";
            // 
            // cmbIndices
            // 
            this.cmbIndices.BeforeTouchSize = new System.Drawing.Size(153, 20);
            this.cmbIndices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIndices.Location = new System.Drawing.Point(3, 21);
            this.cmbIndices.Name = "cmbIndices";
            this.cmbIndices.Size = new System.Drawing.Size(153, 20);
            this.cmbIndices.TabIndex = 6;
            // 
            // pressurePanel
            // 
            this.pressurePanel.ColumnCount = 3;
            this.pressurePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pressurePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pressurePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.pressurePanel.Controls.Add(this.label6, 2, 0);
            this.pressurePanel.Controls.Add(this.label5, 0, 0);
            this.pressurePanel.Controls.Add(this.label7, 2, 1);
            this.pressurePanel.Controls.Add(this.txtPressure1, 1, 0);
            this.pressurePanel.Controls.Add(this.txtPressure2, 1, 1);
            this.pressurePanel.Location = new System.Drawing.Point(3, 279);
            this.pressurePanel.Name = "pressurePanel";
            this.pressurePanel.RowCount = 2;
            this.pressurePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.76923F));
            this.pressurePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.23077F));
            this.pressurePanel.Size = new System.Drawing.Size(205, 52);
            this.pressurePanel.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(123, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 11);
            this.label6.TabIndex = 9;
            this.label6.Text = "kgf/cm2~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "적정수압";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(123, 29);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 11);
            this.label7.TabIndex = 10;
            this.label7.Text = "kgf/cm2 사이";
            // 
            // txtPressure1
            // 
            this.txtPressure1.BeforeTouchSize = new System.Drawing.Size(54, 21);
            this.txtPressure1.DecimalPlaces = 2;
            this.txtPressure1.Location = new System.Drawing.Point(63, 3);
            this.txtPressure1.Name = "txtPressure1";
            this.txtPressure1.Size = new System.Drawing.Size(54, 21);
            this.txtPressure1.TabIndex = 11;
            // 
            // txtPressure2
            // 
            this.txtPressure2.BeforeTouchSize = new System.Drawing.Size(54, 21);
            this.txtPressure2.DecimalPlaces = 2;
            this.txtPressure2.Location = new System.Drawing.Point(63, 29);
            this.txtPressure2.Name = "txtPressure2";
            this.txtPressure2.Size = new System.Drawing.Size(54, 21);
            this.txtPressure2.TabIndex = 12;
            // 
            // velocityPanel
            // 
            this.velocityPanel.ColumnCount = 3;
            this.velocityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.velocityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.velocityPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.velocityPanel.Controls.Add(this.label8, 2, 0);
            this.velocityPanel.Controls.Add(this.label9, 0, 0);
            this.velocityPanel.Controls.Add(this.txtVelocity, 1, 0);
            this.velocityPanel.Location = new System.Drawing.Point(3, 337);
            this.velocityPanel.Name = "velocityPanel";
            this.velocityPanel.RowCount = 1;
            this.velocityPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.76923F));
            this.velocityPanel.Size = new System.Drawing.Size(205, 30);
            this.velocityPanel.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(123, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 11);
            this.label8.TabIndex = 9;
            this.label8.Text = "m/sec 이상";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 3);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 6;
            this.label9.Text = "적정유속";
            // 
            // txtVelocity
            // 
            this.txtVelocity.BeforeTouchSize = new System.Drawing.Size(54, 21);
            this.txtVelocity.DecimalPlaces = 2;
            this.txtVelocity.Location = new System.Drawing.Point(63, 3);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(54, 21);
            this.txtVelocity.TabIndex = 11;
            // 
            // chartControl
            // 
            this.chartControl.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244))))));
            this.chartControl.BorderAppearance.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.chartControl.BorderAppearance.Interior.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(197)))), ((int)(((byte)(197)))));
            this.chartControl.ChartArea.AdjustPlotAreaMargins = Syncfusion.Windows.Forms.Chart.ChartSetMode.None;
            this.chartControl.ChartArea.AxisSpacing = new System.Drawing.SizeF(0F, 2F);
            this.chartControl.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.White);
            this.chartControl.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl.ChartArea.CursorReDraw = false;
            this.chartControl.ChartAreaMargins = new Syncfusion.Windows.Forms.Chart.ChartMargins(0, 0, 0, 0);
            this.chartControl.CustomPalette = new System.Drawing.Color[] {
        System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(55)))), ((int)(((byte)(128))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(190)))), ((int)(((byte)(82))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(153)))), ((int)(((byte)(191))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(36)))), ((int)(((byte)(126))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(63)))), ((int)(((byte)(57))))),
        System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(124)))), ((int)(((byte)(155)))))};
            this.chartControl.DataSourceName = "[none]";
            this.chartControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chartControl.IsWindowLess = false;
            // 
            // 
            // 
            this.chartControl.Legend.Alignment = Syncfusion.Windows.Forms.Chart.ChartAlignment.Center;
            this.chartControl.Legend.Location = new System.Drawing.Point(21, 230);
            this.chartControl.Legend.Orientation = Syncfusion.Windows.Forms.Chart.ChartOrientation.Horizontal;
            this.chartControl.Legend.Position = Syncfusion.Windows.Forms.Chart.ChartDock.Bottom;
            this.chartControl.Legend.Visible = false;
            this.chartControl.Localize = null;
            this.chartControl.Location = new System.Drawing.Point(3, 370);
            this.chartControl.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.chartControl.Name = "chartControl";
            this.chartControl.Palette = Syncfusion.Windows.Forms.Chart.ChartColorPalette.Office2016;
            this.chartControl.PrimaryXAxis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.chartControl.PrimaryXAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.chartControl.PrimaryXAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.chartControl.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartControl.PrimaryXAxis.Margin = true;
            this.chartControl.PrimaryXAxis.MinorGridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.chartControl.PrimaryXAxis.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.chartControl.PrimaryXAxis.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.chartControl.PrimaryYAxis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.chartControl.PrimaryYAxis.GridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.chartControl.PrimaryYAxis.LineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.chartControl.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartControl.PrimaryYAxis.Margin = true;
            this.chartControl.PrimaryYAxis.MinorGridLineType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.chartControl.PrimaryYAxis.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.chartControl.PrimaryYAxis.TitleColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            chartSeries1.FancyToolTip.ResizeInsideSymbol = true;
            chartSeries1.Name = "Default0";
            chartSeries1.Points.Add(1D, ((double)(70D)));
            chartSeries1.Points.Add(2D, ((double)(35D)));
            chartSeries1.Points.Add(3D, ((double)(65D)));
            chartSeries1.Points.Add(4D, ((double)(25D)));
            chartSeries1.Points.Add(5D, ((double)(50D)));
            chartSeries1.Resolution = 0D;
            chartSeries1.StackingGroup = "Default Group";
            chartSeries1.Style.AltTagFormat = "";
            chartSeries1.Style.Callout.Font.Facename = "굴림";
            chartSeries1.Style.DrawTextShape = false;
            chartSeries1.Style.Font.Facename = "굴림";
            chartSeries1.Style.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            chartLineInfo1.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            chartLineInfo1.Color = System.Drawing.SystemColors.ControlText;
            chartLineInfo1.DashPattern = null;
            chartLineInfo1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartLineInfo1.Width = 1F;
            chartCustomShapeInfo1.Border = chartLineInfo1;
            chartCustomShapeInfo1.Color = System.Drawing.SystemColors.HighlightText;
            chartCustomShapeInfo1.Type = Syncfusion.Windows.Forms.Chart.ChartCustomShape.Square;
            chartSeries1.Style.TextShape = chartCustomShapeInfo1;
            chartSeries1.Text = "Default0";
            chartSeries1.Type = Syncfusion.Windows.Forms.Chart.ChartSeriesType.Pie;
            this.chartControl.Series.Add(chartSeries1);
            this.chartControl.Size = new System.Drawing.Size(200, 200);
            this.chartControl.Skins = Syncfusion.Windows.Forms.Chart.Skins.Office2016Colorful;
            this.chartControl.TabIndex = 7;
            this.chartControl.TextPosition = Syncfusion.Windows.Forms.Chart.ChartTextPosition.Bottom;
            // 
            // 
            // 
            this.chartControl.Title.Name = "Default";
            this.chartControl.Title.Position = Syncfusion.Windows.Forms.Chart.ChartDock.Bottom;
            this.chartControl.ToolBar.EnableDefaultItems = false;
            this.chartControl.ToolBar.Items.Add(chartToolBarSaveItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarCopyItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarPrintItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarPrintPreviewItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarSplitter1);
            this.chartControl.ToolBar.Items.Add(chartToolBarPaletteItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarStyleItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarTypeItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarSeries3DItem1);
            this.chartControl.ToolBar.Items.Add(chartToolBarShowLegendItem1);
            this.chartControl.VisualTheme = "";
            // 
            // legendPanel
            // 
            this.legendPanel.ColumnCount = 3;
            this.legendPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.60355F));
            this.legendPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.39645F));
            this.legendPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.legendPanel.Controls.Add(this.lblCount3, 1, 2);
            this.legendPanel.Controls.Add(this.lblLegend3, 0, 2);
            this.legendPanel.Controls.Add(this.lblLegend1, 0, 0);
            this.legendPanel.Controls.Add(this.lblLegend2, 0, 1);
            this.legendPanel.Controls.Add(this.lblCount1, 1, 0);
            this.legendPanel.Controls.Add(this.lblCount2, 1, 1);
            this.legendPanel.Location = new System.Drawing.Point(3, 576);
            this.legendPanel.Name = "legendPanel";
            this.legendPanel.RowCount = 3;
            this.legendPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.legendPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.legendPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.legendPanel.Size = new System.Drawing.Size(178, 67);
            this.legendPanel.TabIndex = 12;
            // 
            // lblCount3
            // 
            this.lblCount3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lblCount3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCount3.Location = new System.Drawing.Point(72, 44);
            this.lblCount3.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.lblCount3.Name = "lblCount3";
            this.lblCount3.Size = new System.Drawing.Size(82, 23);
            this.lblCount3.TabIndex = 17;
            this.lblCount3.Text = "123";
            this.lblCount3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLegend3
            // 
            this.lblLegend3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend3.Location = new System.Drawing.Point(3, 47);
            this.lblLegend3.Margin = new System.Windows.Forms.Padding(3);
            this.lblLegend3.Name = "lblLegend3";
            this.lblLegend3.Size = new System.Drawing.Size(66, 17);
            this.lblLegend3.TabIndex = 11;
            this.lblLegend3.Text = "legend";
            this.lblLegend3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegend1
            // 
            this.lblLegend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend1.Location = new System.Drawing.Point(3, 3);
            this.lblLegend1.Margin = new System.Windows.Forms.Padding(3);
            this.lblLegend1.Name = "lblLegend1";
            this.lblLegend1.Size = new System.Drawing.Size(66, 16);
            this.lblLegend1.TabIndex = 6;
            this.lblLegend1.Text = "legend";
            this.lblLegend1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLegend2
            // 
            this.lblLegend2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLegend2.Location = new System.Drawing.Point(3, 25);
            this.lblLegend2.Margin = new System.Windows.Forms.Padding(3);
            this.lblLegend2.Name = "lblLegend2";
            this.lblLegend2.Size = new System.Drawing.Size(66, 16);
            this.lblLegend2.TabIndex = 12;
            this.lblLegend2.Text = "legend";
            this.lblLegend2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCount1
            // 
            this.lblCount1.BackColor = System.Drawing.Color.Tomato;
            this.lblCount1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCount1.Location = new System.Drawing.Point(72, 0);
            this.lblCount1.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.lblCount1.Name = "lblCount1";
            this.lblCount1.Size = new System.Drawing.Size(82, 22);
            this.lblCount1.TabIndex = 15;
            this.lblCount1.Text = "123";
            this.lblCount1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCount2
            // 
            this.lblCount2.BackColor = System.Drawing.Color.SeaGreen;
            this.lblCount2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCount2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCount2.Location = new System.Drawing.Point(72, 22);
            this.lblCount2.Margin = new System.Windows.Forms.Padding(0, 0, 15, 0);
            this.lblCount2.Name = "lblCount2";
            this.lblCount2.Size = new System.Drawing.Size(82, 22);
            this.lblCount2.TabIndex = 16;
            this.lblCount2.Text = "123";
            this.lblCount2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BrowserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BrowserView";
            this.Size = new System.Drawing.Size(468, 830);
            ((System.ComponentModel.ISupportInitialize)(this.cmbNodeValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbLinkValues)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTimeSteps)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.quantityPanel.ResumeLayout(false);
            this.quantityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbIndices)).EndInit();
            this.pressurePanel.ResumeLayout(false);
            this.pressurePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPressure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPressure2)).EndInit();
            this.velocityPanel.ResumeLayout(false);
            this.velocityPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVelocity)).EndInit();
            this.legendPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbNodeValues;
        public Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbLinkValues;
        public Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbTimeSteps;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public Syncfusion.Windows.Forms.ButtonAdv btnFirstTimeStep;
        public Syncfusion.Windows.Forms.ButtonAdv btnBackTimeStep;
        public Syncfusion.Windows.Forms.ButtonAdv btnStopTimeStep;
        public Syncfusion.Windows.Forms.ButtonAdv btnForwardTimeStep;
        private System.Windows.Forms.Label label4;
        public Syncfusion.Windows.Forms.Tools.ComboBoxAdv cmbIndices;
        public Syncfusion.Windows.Forms.Chart.ChartControl chartControl;
        public System.Windows.Forms.FlowLayoutPanel quantityPanel;
        public System.Windows.Forms.TableLayoutPanel pressurePanel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        public Syncfusion.Windows.Forms.Tools.NumericUpDownExt txtPressure1;
        public Syncfusion.Windows.Forms.Tools.NumericUpDownExt txtPressure2;
        public System.Windows.Forms.TableLayoutPanel velocityPanel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public Syncfusion.Windows.Forms.Tools.NumericUpDownExt txtVelocity;
        public Syncfusion.Windows.Forms.ButtonAdv btnRefresh;
        public System.Windows.Forms.TableLayoutPanel legendPanel;
        private System.Windows.Forms.Label lblLegend1;
        private System.Windows.Forms.Label lblLegend3;
        private System.Windows.Forms.Label lblLegend2;
        private System.Windows.Forms.Label lblCount3;
        private System.Windows.Forms.Label lblCount1;
        private System.Windows.Forms.Label lblCount2;
    }
}
