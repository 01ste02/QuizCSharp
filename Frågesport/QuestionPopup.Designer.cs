namespace Frågesport
{
    partial class QuestionPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
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
        private void InitializeComponent ()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionPopup));
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.mediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQuestion.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestion.Location = new System.Drawing.Point(0, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(800, 285);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "\r\na";
            this.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblQuestion.Click += new System.EventHandler(this.LblQuestion_Click);
            // 
            // lblAnswer
            // 
            this.lblAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnswer.BackColor = System.Drawing.Color.Moccasin;
            this.lblAnswer.Location = new System.Drawing.Point(0, 285);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(800, 167);
            this.lblAnswer.TabIndex = 1;
            this.lblAnswer.Text = "label1";
            this.lblAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAnswer.Click += new System.EventHandler(this.LblAnswer_Click);
            // 
            // lblMedia
            // 
            this.lblMedia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMedia.Location = new System.Drawing.Point(0, 98);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(800, 187);
            this.lblMedia.TabIndex = 2;
            this.lblMedia.Visible = false;
            this.lblMedia.Click += new System.EventHandler(this.LblMedia_Click);
            // 
            // mediaPlayer1
            // 
            this.mediaPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaPlayer1.Enabled = true;
            this.mediaPlayer1.Location = new System.Drawing.Point(3, 58);
            this.mediaPlayer1.Name = "mediaPlayer1";
            this.mediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer1.OcxState")));
            this.mediaPlayer1.Size = new System.Drawing.Size(797, 346);
            this.mediaPlayer1.TabIndex = 3;
            this.mediaPlayer1.Visible = false;
            this.mediaPlayer1.MouseUpEvent += new AxWMPLib._WMPOCXEvents_MouseUpEventHandler(this.MediaPlayer1_MouseUpEvent);
            // 
            // QuestionPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LemonChiffon;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mediaPlayer1);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Controls.Add(this.lblMedia);
            this.MinimizeBox = false;
            this.Name = "QuestionPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fråga";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.QuestionPopup_Load);
            this.ResizeEnd += new System.EventHandler(this.QuestionPopup_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.Label lblMedia;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer1;
    }
}