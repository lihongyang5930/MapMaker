namespace MMaker.Diagnosis.Views
{
    partial class ModelCreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new Syncfusion.Windows.Forms.ButtonAdv();
            this.btnGenerator = new Syncfusion.Windows.Forms.ButtonAdv();
            this.rtLog = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BeforeTouchSize = new System.Drawing.Size(80, 23);
            this.btnClose.IsBackStageButton = false;
            this.btnClose.Location = new System.Drawing.Point(351, 299);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "닫기";
            // 
            // btnGenerator
            // 
            this.btnGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerator.BeforeTouchSize = new System.Drawing.Size(109, 23);
            this.btnGenerator.IsBackStageButton = false;
            this.btnGenerator.Location = new System.Drawing.Point(227, 299);
            this.btnGenerator.Name = "btnGenerator";
            this.btnGenerator.Size = new System.Drawing.Size(109, 23);
            this.btnGenerator.TabIndex = 1;
            this.btnGenerator.Text = "관망도 생성";
            // 
            // rtLog
            // 
            this.rtLog.Location = new System.Drawing.Point(12, 12);
            this.rtLog.Name = "rtLog";
            this.rtLog.Size = new System.Drawing.Size(428, 273);
            this.rtLog.TabIndex = 2;
            this.rtLog.Text = "";
            // 
            // ModelCreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 334);
            this.Controls.Add(this.rtLog);
            this.Controls.Add(this.btnGenerator);
            this.Controls.Add(this.btnClose);
            this.Name = "ModelCreationForm";
            this.Text = "관망도(수리모델) 생성";
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.ButtonAdv btnClose;
        private Syncfusion.Windows.Forms.ButtonAdv btnGenerator;
        private System.Windows.Forms.RichTextBox rtLog;
    }
}