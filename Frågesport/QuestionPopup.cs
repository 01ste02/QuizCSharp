using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WMPLib;

namespace Frågesport
{
    public partial class QuestionPopup : Form
    {
        private int clickIndex = 0;
        private int score = -1;

        private FontHelper fontHelper = new FontHelper();

        private Team[] teams;
        private string questionType;
        private string filePath;
        private string fileName;

        public QuestionPopup (string Question, string Answer, int score, Team[] teams, string questionType, string filePath, string fileName)
        {
            InitializeComponent();
            lblQuestion.Text = Question;
            lblAnswer.Text = Answer;
            this.score = score;
            this.teams = teams;
            this.questionType = questionType;
            this.filePath = filePath;
            this.fileName = fileName;
        }

        private void QuestionPopup_Load (object sender, EventArgs e)
        {
            Invalidate();
            string fontName = "Palatino Linotype";

            if (questionType == "Text")
            {
                lblQuestion.Height = this.Height;
            }
            else if (questionType == "Video")
            {
                lblQuestion.Height = (int)(this.Height * 0.2);
                mediaPlayer1.Visible = true;
                mediaPlayer1.Width = this.Width;
                mediaPlayer1.Height = (int)(this.Height * 0.8);
                mediaPlayer1.Location = new Point(0, lblQuestion.Height);

                try
                {
                    mediaPlayer1.URL = (Path.Combine(filePath, fileName));
                }
                catch
                {
                    lblQuestion.Height = (int)(this.Height * 0.2);
                    lblMedia.Height = (int)(this.Height * 0.8);
                    lblMedia.Visible = true;
                    lblMedia.Text = "Det skedde ett fel då filen skulle laddas";
                    int fontSize3 = fontHelper.FontSizeString(lblMedia.Text, fontName, (int)(lblMedia.Width / 2), lblMedia.Height, this.CreateGraphics());
                    lblMedia.Font = new Font(fontName, fontSize3);
                }

                mediaPlayer1.uiMode = "none";
                mediaPlayer1.stretchToFit = true;
            }
            else if (questionType == "Audio")
            {
                lblQuestion.Height = (int)(this.Height * 0.2);
                mediaPlayer1.Visible = true;
                mediaPlayer1.Width = this.Width;
                mediaPlayer1.Height = (int)(this.Height * 0.8);
                mediaPlayer1.Location = new Point(0, lblQuestion.Height);

                try
                {
                    mediaPlayer1.URL = (Path.Combine(filePath, fileName));
                }
                catch
                {
                    lblQuestion.Height = (int)(this.Height * 0.2);
                    lblMedia.Height = (int)(this.Height * 0.8);
                    lblMedia.Visible = true;
                    lblMedia.Text = "Det skedde ett fel då filen skulle laddas";
                    int fontSize3 = fontHelper.FontSizeString(lblMedia.Text, fontName, (int)(lblMedia.Width / 2), lblMedia.Height, this.CreateGraphics());
                    lblMedia.Font = new Font(fontName, fontSize3);
                }

                mediaPlayer1.uiMode = "none";
                mediaPlayer1.stretchToFit = true;
            }
            else
            {
                lblQuestion.Height = (int)(this.Height * 0.2);
                lblMedia.Height = (int)(this.Height * 0.8);
                lblMedia.Visible = true;
                try
                {
                    lblMedia.Image = Image.FromFile(Path.Combine(filePath, fileName));
                }
                catch
                {
                    lblQuestion.Height = (int)(this.Height * 0.2);
                    lblMedia.Height = (int)(this.Height * 0.8);
                    lblMedia.Visible = true;
                    lblMedia.Text = "Det skedde ett fel då filen skulle laddas";
                    int fontSize3 = fontHelper.FontSizeString(lblMedia.Text, fontName, (int)(lblMedia.Width / 2), lblMedia.Height, this.CreateGraphics());
                    lblMedia.Font = new Font(fontName, fontSize3);
                }

                lblMedia.ImageAlign = ContentAlignment.TopCenter;
            }
            lblQuestion.Width = this.Width;
            lblMedia.Width = this.Width;
            lblAnswer.Width = this.Width;

            lblAnswer.Visible = false;

            int fontSize1 = fontHelper.FontSizeString(lblQuestion.Text, fontName, lblQuestion.Width, lblQuestion.Height, this.CreateGraphics());
            lblQuestion.Font = new Font(fontName, fontSize1);
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

            int fontSize2 = fontHelper.FontSizeString(lblAnswer.Text, fontName, (int)(lblAnswer.Width / 2), lblAnswer.Height, this.CreateGraphics());
            lblAnswer.Font = new Font(fontName, fontSize2);
        }

        private void LblQuestion_Click (object sender, EventArgs e)
        {
            Clicked();
        }

        private void LblAnswer_Click (object sender, EventArgs e)
        {
            Clicked();
        }

        private void Clicked()
        {
            if (clickIndex == 0)
            {
                if (questionType == "Text")
                {
                    lblQuestion.Height = (int)(0.6 * this.Height);
                    lblAnswer.Visible = true;
                    lblAnswer.Location = new Point(0, lblQuestion.Height);
                    lblAnswer.Height = (int)(0.4 * this.Height);
                }
                else if (questionType == "Video")
                {
                    lblQuestion.Height = (int)(this.Height * 0.2);
                    mediaPlayer1.Visible = true;
                    mediaPlayer1.Width = this.Width;
                    mediaPlayer1.Height = (int)(this.Height * 0.5);
                    mediaPlayer1.Location = new Point(0, lblQuestion.Height);
                    mediaPlayer1.uiMode = "none";
                    mediaPlayer1.stretchToFit = true;
                    lblAnswer.Location = new Point(0, lblQuestion.Height + mediaPlayer1.Height);
                    lblAnswer.Height = (int)(0.3 * this.Height);
                    lblAnswer.Width = this.Width;
                    lblAnswer.Visible = true;
                }
                else if (questionType == "Audio")
                {
                    lblQuestion.Height = (int)(this.Height * 0.2);
                    mediaPlayer1.Visible = true;
                    mediaPlayer1.Width = this.Width;
                    mediaPlayer1.Height = (int)(this.Height * 0.5);
                    mediaPlayer1.Location = new Point(0, lblQuestion.Height);
                    mediaPlayer1.uiMode = "none";
                    mediaPlayer1.stretchToFit = true;
                    lblAnswer.Location = new Point(0, lblQuestion.Height + mediaPlayer1.Height);
                    lblAnswer.Height = (int)(0.3 * this.Height);
                    lblAnswer.Width = this.Width;
                    lblAnswer.Visible = true;
                }
                else
                {
                    lblQuestion.Height = (int)(0.2 * this.Height);
                    lblAnswer.Visible = true;
                    lblMedia.Height = (int)(0.5 * this.Height);
                    lblAnswer.Location = new Point(0, lblQuestion.Height + lblMedia.Height);
                    lblAnswer.Height = (int)(0.3 * this.Height);
                }
            }
            else if (clickIndex > 1)
            {
                mediaPlayer1.Ctlcontrols.pause();
                this.Close();
            }
            else if (clickIndex == 1)
            {
                AwardPoints popup = new AwardPoints(score, teams.Length, teams);
                mediaPlayer1.Ctlcontrols.pause();
                popup.ShowDialog();
            }
            clickIndex++;
        }

        private void QuestionPopup_ResizeEnd (object sender, EventArgs e)
        {
            if (clickIndex > 0)
            {
                if (questionType == "Text")
                {
                    lblQuestion.Height = (int)(0.6 * this.Height);
                    lblQuestion.Width = this.Width;
                    lblAnswer.Location = new Point(0, lblQuestion.Height);
                    lblAnswer.Height = (int)(0.4 * this.Height);
                    lblAnswer.Width = this.Width;
                }
                else if (questionType == "Video")
                {
                    lblQuestion.Height = (int)(this.Height * 0.2);
                    mediaPlayer1.Visible = true;
                    mediaPlayer1.Width = this.Width;
                    mediaPlayer1.Height = (int)(this.Height * 0.5);
                    mediaPlayer1.Location = new Point(0, lblQuestion.Height);
                    mediaPlayer1.uiMode = "none";
                    mediaPlayer1.stretchToFit = true;
                    lblAnswer.Location = new Point(0, lblQuestion.Height + mediaPlayer1.Height);
                    lblAnswer.Height = (int)(0.3 * this.Height);
                    lblAnswer.Width = this.Width;
                    lblAnswer.Visible = true;
                }
                else if (questionType == "Audio")
                {
                    lblQuestion.Height = (int)(this.Height * 0.2);
                    mediaPlayer1.Visible = true;
                    mediaPlayer1.Width = this.Width;
                    mediaPlayer1.Height = (int)(this.Height * 0.5);
                    mediaPlayer1.Location = new Point(0, lblQuestion.Height);
                    mediaPlayer1.uiMode = "none";
                    mediaPlayer1.stretchToFit = true;
                    lblAnswer.Location = new Point(0, lblQuestion.Height + mediaPlayer1.Height);
                    lblAnswer.Height = (int)(0.3 * this.Height);
                    lblAnswer.Width = this.Width;
                    lblAnswer.Visible = true;
                }
                else
                {
                    lblQuestion.Height = (int)(0.2 * this.Height);
                    lblAnswer.Visible = true;
                    lblMedia.Height = (int)(0.5 * this.Height);
                    lblMedia.Location = new Point(0, lblQuestion.Height);
                    lblAnswer.Location = new Point(0, lblQuestion.Height + lblMedia.Height);
                    lblAnswer.Height = (int)(0.3 * this.Height);
                    lblAnswer.Width = this.Width;
                    lblMedia.Width = this.Width;
                }

                string fontName = "Palatino Linotype";

                int fontSize1 = fontHelper.FontSizeString(lblQuestion.Text, fontName, lblQuestion.Width, lblQuestion.Height, this.CreateGraphics());
                lblQuestion.Font = new Font(fontName, fontSize1);
                lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

                int fontSize2 = fontHelper.FontSizeString(lblAnswer.Text, fontName, (int)(lblAnswer.Width / 2), lblAnswer.Height, this.CreateGraphics());
                lblAnswer.Font = new Font(fontName, fontSize2);
            }
            else
            {
                lblQuestion.Height = this.Height;
                lblQuestion.Width = this.Width;
                lblAnswer.Width = this.Width;

                lblQuestion.Height = (int)(this.Height * 0.2);
                mediaPlayer1.Width = this.Width;
                mediaPlayer1.Height = (int)(this.Height * 0.7);
                mediaPlayer1.Location = new Point(0, lblQuestion.Height);

                string fontName = "Palatino Linotype";

                int fontSize1 = fontHelper.FontSizeString(lblQuestion.Text, fontName, lblQuestion.Width, lblQuestion.Height, this.CreateGraphics());
                lblQuestion.Font = new Font(fontName, fontSize1);
                lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

                int fontSize2 = fontHelper.FontSizeString(lblAnswer.Text, fontName, (int)(lblAnswer.Width / 2), lblAnswer.Height, this.CreateGraphics());
                lblAnswer.Font = new Font(fontName, fontSize2);
            }
        }

        private void LblMedia_Click (object sender, EventArgs e)
        {
            if (lblMedia.Visible == true)
            {
                Clicked();
            }
        }

        private void MediaPlayer1_MouseUpEvent (object sender, AxWMPLib._WMPOCXEvents_MouseUpEvent e)
        {
            if (mediaPlayer1.playState != WMPPlayState.wmppsPaused)
            {
                mediaPlayer1.Ctlcontrols.pause();
            }
            else
            {
                mediaPlayer1.Ctlcontrols.play();
            }
        }
    }
}
