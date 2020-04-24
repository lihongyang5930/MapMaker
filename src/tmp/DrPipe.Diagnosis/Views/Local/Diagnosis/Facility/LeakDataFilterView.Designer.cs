namespace DrPipe.Diagnosis.Views.Local.Diagnosis.Facility
{
    partial class LeakDataFilterView
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
            this.autoLabel1 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.autoLabel2 = new Syncfusion.Windows.Forms.Tools.AutoLabel();
            this.sfButton1 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfButton2 = new Syncfusion.WinForms.Controls.SfButton();
            this.sfListView1 = new Syncfusion.WinForms.ListView.SfListView();
            this.sfListView2 = new Syncfusion.WinForms.ListView.SfListView();
            this.SuspendLayout();
            // 
            // autoLabel1
            // 
            this.autoLabel1.Location = new System.Drawing.Point(21, 42);
            this.autoLabel1.Name = "autoLabel1";
            this.autoLabel1.Size = new System.Drawing.Size(53, 12);
            this.autoLabel1.TabIndex = 0;
            this.autoLabel1.Text = "누수부위";
            // 
            // autoLabel2
            // 
            this.autoLabel2.Location = new System.Drawing.Point(224, 42);
            this.autoLabel2.Name = "autoLabel2";
            this.autoLabel2.Size = new System.Drawing.Size(53, 12);
            this.autoLabel2.TabIndex = 1;
            this.autoLabel2.Text = "누수원인";
            // 
            // sfButton1
            // 
            this.sfButton1.AccessibleName = "Button";
            this.sfButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton1.Location = new System.Drawing.Point(221, 285);
            this.sfButton1.Name = "sfButton1";
            this.sfButton1.Size = new System.Drawing.Size(75, 38);
            this.sfButton1.TabIndex = 2;
            this.sfButton1.Text = "확인";
            // 
            // sfButton2
            // 
            this.sfButton2.AccessibleName = "Button";
            this.sfButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F);
            this.sfButton2.Location = new System.Drawing.Point(302, 285);
            this.sfButton2.Name = "sfButton2";
            this.sfButton2.Size = new System.Drawing.Size(74, 39);
            this.sfButton2.TabIndex = 3;
            this.sfButton2.Text = "취소";
            // 
            // sfListView1
            // 
            this.sfListView1.AccessibleName = "ScrollControl";
            this.sfListView1.Location = new System.Drawing.Point(21, 66);
            this.sfListView1.Name = "sfListView1";
            this.sfListView1.Size = new System.Drawing.Size(145, 187);
            this.sfListView1.TabIndex = 4;
            this.sfListView1.Text = "sfListView1";
            // 
            // sfListView2
            // 
            this.sfListView2.AccessibleName = "ScrollControl";
            this.sfListView2.Location = new System.Drawing.Point(224, 66);
            this.sfListView2.Name = "sfListView2";
            this.sfListView2.Size = new System.Drawing.Size(152, 195);
            this.sfListView2.TabIndex = 5;
            this.sfListView2.Text = "sfListView2";
            // 
            // LeakDataFilterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sfListView2);
            this.Controls.Add(this.sfListView1);
            this.Controls.Add(this.sfButton2);
            this.Controls.Add(this.sfButton1);
            this.Controls.Add(this.autoLabel2);
            this.Controls.Add(this.autoLabel1);
            this.Name = "LeakDataFilterView";
            this.Size = new System.Drawing.Size(406, 348);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel1;
        private Syncfusion.Windows.Forms.Tools.AutoLabel autoLabel2;
        private Syncfusion.WinForms.Controls.SfButton sfButton1;
        private Syncfusion.WinForms.Controls.SfButton sfButton2;
        private Syncfusion.WinForms.ListView.SfListView sfListView1;
        private Syncfusion.WinForms.ListView.SfListView sfListView2;
    }
}
