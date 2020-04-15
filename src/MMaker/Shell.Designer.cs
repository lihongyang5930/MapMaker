namespace MMaker
{
    partial class MmakerShell
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MmakerShell));
            this.ribbonControlAdv1 = new Syncfusion.Windows.Forms.Tools.RibbonControlAdv();
            this.rbFile = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.rbMap = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.rbGenerator = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.rbTool = new Syncfusion.Windows.Forms.Tools.ToolStripTabItem();
            this.dockingManager = new Syncfusion.Windows.Forms.Tools.DockingManager(this.components);
            this.appManager = new DotSpatial.Controls.AppManager();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlAdv1)).BeginInit();
            this.ribbonControlAdv1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControlAdv1
            // 
            this.ribbonControlAdv1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControlAdv1.Header.AddMainItem(rbFile);
            this.ribbonControlAdv1.Header.AddMainItem(rbMap);
            this.ribbonControlAdv1.Header.AddMainItem(rbGenerator);
            this.ribbonControlAdv1.Header.AddMainItem(rbTool);
            this.ribbonControlAdv1.Location = new System.Drawing.Point(1, 0);
            this.ribbonControlAdv1.MenuButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControlAdv1.MenuButtonText = "";
            this.ribbonControlAdv1.MenuButtonWidth = 56;
            this.ribbonControlAdv1.MenuColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(198)))));
            this.ribbonControlAdv1.Name = "ribbonControlAdv1";
            this.ribbonControlAdv1.OfficeColorScheme = Syncfusion.Windows.Forms.Tools.ToolStripEx.ColorScheme.Managed;
            // 
            // ribbonControlAdv1.OfficeMenu
            // 
            this.ribbonControlAdv1.OfficeMenu.Name = "OfficeMenu";
            this.ribbonControlAdv1.OfficeMenu.ShowItemToolTips = true;
            this.ribbonControlAdv1.OfficeMenu.Size = new System.Drawing.Size(12, 65);
            this.ribbonControlAdv1.QuickPanelImageLayout = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ribbonControlAdv1.RibbonHeaderImage = Syncfusion.Windows.Forms.Tools.RibbonHeaderImage.None;
            this.ribbonControlAdv1.RibbonStyle = Syncfusion.Windows.Forms.Tools.RibbonStyle.Office2016;
            this.ribbonControlAdv1.SelectedTab = this.rbMap;
            this.ribbonControlAdv1.ShowLauncher = false;
            this.ribbonControlAdv1.ShowMinimizeButton = false;
            this.ribbonControlAdv1.ShowQuickItemsDropDownButton = false;
            this.ribbonControlAdv1.ShowRibbonDisplayOptionButton = false;
            this.ribbonControlAdv1.Size = new System.Drawing.Size(1019, 190);
            this.ribbonControlAdv1.SystemText.QuickAccessDialogDropDownName = "Start menu";
            this.ribbonControlAdv1.SystemText.RenameDisplayLabelText = "&Display Name:";
            this.ribbonControlAdv1.TabIndex = 2;
            this.ribbonControlAdv1.Text = "ribbonControlAdv1";
            this.ribbonControlAdv1.ThemeName = "Office2016";
            this.ribbonControlAdv1.TitleColor = System.Drawing.Color.Black;
            // 
            // rbFile
            // 
            this.rbFile.Name = "rbFile";
            // 
            // ribbonControlAdv1.ribbonPanel1
            // 
            this.rbFile.Panel.Name = "ribbonPanel1";
            this.rbFile.Panel.ScrollPosition = 0;
            this.rbFile.Panel.TabIndex = 2;
            this.rbFile.Panel.Text = "관리";
            this.rbFile.Position = 0;
            this.rbFile.Size = new System.Drawing.Size(45, 30);
            this.rbFile.Tag = "1";
            this.rbFile.Text = "관리";
            // 
            // rbMap
            // 
            this.rbMap.Name = "rbMap";
            // 
            // ribbonControlAdv1.ribbonPanel2
            // 
            this.rbMap.Panel.Name = "ribbonPanel2";
            this.rbMap.Panel.ScrollPosition = 0;
            this.rbMap.Panel.TabIndex = 3;
            this.rbMap.Panel.Text = "편집 및 지도제어";
            this.rbMap.Position = 1;
            this.rbMap.Size = new System.Drawing.Size(106, 30);
            this.rbMap.Tag = "2";
            this.rbMap.Text = "편집 및 지도제어";
            // 
            // rbGenerator
            // 
            this.rbGenerator.Name = "rbGenerator";
            // 
            // ribbonControlAdv1.ribbonPanel3
            // 
            this.rbGenerator.Panel.Name = "ribbonPanel3";
            this.rbGenerator.Panel.ScrollPosition = 0;
            this.rbGenerator.Panel.TabIndex = 4;
            this.rbGenerator.Panel.Text = "관망모델";
            this.rbGenerator.Position = 2;
            this.rbGenerator.Size = new System.Drawing.Size(67, 30);
            this.rbGenerator.Tag = "3";
            this.rbGenerator.Text = "관망모델";
            // 
            // rbTool
            // 
            this.rbTool.Name = "rbTool";
            // 
            // ribbonControlAdv1.ribbonPanel4
            // 
            this.rbTool.Panel.Name = "ribbonPanel4";
            this.rbTool.Panel.ScrollPosition = 0;
            this.rbTool.Panel.TabIndex = 5;
            this.rbTool.Panel.Text = "도구";
            this.rbTool.Position = 3;
            this.rbTool.Size = new System.Drawing.Size(45, 30);
            this.rbTool.Tag = "4";
            this.rbTool.Text = "도구";
            // 
            // dockingManager
            // 
            this.dockingManager.AnimateAutoHiddenWindow = true;
            this.dockingManager.AutoHideTabFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager.AutoHideTabForeColor = System.Drawing.Color.Empty;
            this.dockingManager.DockBehavior = Syncfusion.Windows.Forms.Tools.DockBehavior.VS2010;
            this.dockingManager.DockLayoutStream = ((System.IO.MemoryStream)(resources.GetObject("dockingManager.DockLayoutStream")));
            this.dockingManager.DockTabFont = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockingManager.DragProviderStyle = Syncfusion.Windows.Forms.Tools.DragProviderStyle.Office2016Colorful;
            this.dockingManager.EnableDocumentMode = true;
            this.dockingManager.HostControl = this;
            this.dockingManager.MetroButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dockingManager.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(158)))), ((int)(((byte)(218)))));
            this.dockingManager.MetroSplitterBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(159)))), ((int)(((byte)(183)))));
            this.dockingManager.ReduceFlickeringInRtl = false;
            this.dockingManager.ThemeName = "Office2016Colorful";
            this.dockingManager.VisualStyle = Syncfusion.Windows.Forms.VisualStyle.Office2016Colorful;
            this.dockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Close, "CloseButton"));
            this.dockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Pin, "PinButton"));
            this.dockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Maximize, "MaximizeButton"));
            this.dockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Restore, "RestoreButton"));
            this.dockingManager.CaptionButtons.Add(new Syncfusion.Windows.Forms.Tools.CaptionButton(Syncfusion.Windows.Forms.Tools.CaptionButtonType.Menu, "MenuButton"));
            // 
            // appManager
            // 
            this.appManager.Directories = ((System.Collections.Generic.List<string>)(resources.GetObject("appManager.Directories")));
            this.appManager.DockManager = null;
            this.appManager.HeaderControl = null;
            this.appManager.Legend = null;
            this.appManager.Map = null;
            this.appManager.ProgressHandler = null;
            // 
            // MmakerShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 694);
            this.Controls.Add(this.ribbonControlAdv1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.IsMdiContainer = true;
            this.Name = "MmakerShell";
            this.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.ShowApplicationIcon = false;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControlAdv1)).EndInit();
            this.ribbonControlAdv1.ResumeLayout(false);
            this.ribbonControlAdv1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockingManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.RibbonControlAdv ribbonControlAdv1;
        private Syncfusion.Windows.Forms.Tools.DockingManager dockingManager;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem rbFile;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem rbMap;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem rbGenerator;
        private Syncfusion.Windows.Forms.Tools.ToolStripTabItem rbTool;

        private DotSpatial.Controls.AppManager appManager;
    }
}

