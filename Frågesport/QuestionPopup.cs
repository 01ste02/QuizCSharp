using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Frågesport
{
    public partial class QuestionPopup : Form
    {
        private int clickIndex = 0;
        private int score = -1;

        private FontHelper fontHelper = new FontHelper();

        private Team[] teams;

        public QuestionPopup (string Question, string Answer, int score, Team[] teams)
        {
            InitializeComponent();
            lblQuestion.Text = Question;
            lblAnswer.Text = Answer;
            this.score = score;
            this.teams = teams;
        }

        private void QuestionPopup_Load (object sender, EventArgs e)
        {
            Invalidate();
            lblQuestion.Height = this.Height;
            lblQuestion.Width = this.Width;
            lblAnswer.Width = this.Width;

            lblAnswer.Visible = false;

            string fontName = "Stencil";

            int fontSize1 = fontHelper.FontSizeString(lblQuestion.Text, fontName, lblQuestion.Width, lblQuestion.Height, this.CreateGraphics());
            lblQuestion.Font = new Font(fontName, fontSize1);
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;

            int fontSize2 = fontHelper.FontSizeString(lblAnswer.Text, fontName, lblAnswer.Width, lblAnswer.Height, this.CreateGraphics());
            lblAnswer.Font = new Font(fontName, fontSize2);
        }

        private void lblQuestion_Click (object sender, EventArgs e)
        {
            if (clickIndex == 0)
            {
                lblQuestion.Height = (int)(0.6 * this.Height);
                lblAnswer.Visible = true;
                lblAnswer.Location = new Point(0, lblQuestion.Height);
                lblAnswer.Height = (int)(0.4 * this.Height);
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
                lblQuestion.Height = (int)(0.6 * this.Height);
                lblAnswer.Visible = true;
                lblAnswer.Location = new Point(0, lblQuestion.Height);
                lblAnswer.Height = (int)(0.4 * this.Height);
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
