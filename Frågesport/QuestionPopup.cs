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
            if (questionType == "Text")
            {
                lblQuestion.Height = this.Height;
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

                }

                lblMedia.ImageAlign = ContentAlignment.TopCenter;
            }
            lblQuestion.Width = this.Width;
            lblMedia.Width = this.Width;
            lblAnswer.Width = this.Width;

            lblAnswer.Visible = false;

            string fontName = "Palatino Linotype";

            int fontSize1 = fontHelper.FontSizeString(lblQuestion.Text, fontName, lblQuestion.Width, lblQuestion.Height, this.CreateGraphics());
            lblQuestion.Font = new Font(fontName, fontSize1);
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

            int fontSize2 = fontHelper.FontSizeString(lblAnswer.Text, fontName, (int)(lblAnswer.Width / 2), lblAnswer.Height, this.CreateGraphics());
            lblAnswer.Font = new Font(fontName, fontSize2);
        }

        private void lblQuestion_Click (object sender, EventArgs e)
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
                else
                {
                    lblQuestion.Height = (int)(0.2 * this.Height);
                    lblQuestion.Location = new Point(0, 0);
                    lblAnswer.Visible = true;
                    lblMedia.Height = (int)(0.5 * this.Height);
                    lblMedia.Location = new Point(0, lblQuestion.Height);
                    lblAnswer.Location = new Point(0, lblQuestion.Height + lblMedia.Height);
                    lblAnswer.Height = (int)(0.3 * this.Height);
                }
            }
            else if (clickIndex > 1)
            {
                this.Close();
            }
            else if (clickIndex == 1)
            {
                var popup = new AwardPoints(score, teams.Length, teams);
                popup.ShowDialog();
            }
            clickIndex++;
        }

        private void lblAnswer_Click (object sender, EventArgs e)
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
                this.Close();
            }
            else if (clickIndex == 1)
            {
                var popup = new AwardPoints(score, teams.Length, teams);
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

                string fontName = "Palatino Linotype";

                int fontSize1 = fontHelper.FontSizeString(lblQuestion.Text, fontName, lblQuestion.Width, lblQuestion.Height, this.CreateGraphics());
                lblQuestion.Font = new Font(fontName, fontSize1);
                lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

                int fontSize2 = fontHelper.FontSizeString(lblAnswer.Text, fontName, (int)(lblAnswer.Width / 2), lblAnswer.Height, this.CreateGraphics());
                lblAnswer.Font = new Font(fontName, fontSize2);
            }
        }

        private void lblMedia_Click (object sender, EventArgs e)
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
                this.Close();
            }
            else if (clickIndex == 1)
            {
                var popup = new AwardPoints(score, teams.Length, teams);
                popup.ShowDialog();
            }
            clickIndex++;
        }
    }
}
