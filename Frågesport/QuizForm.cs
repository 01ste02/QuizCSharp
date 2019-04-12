using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Frågesport
{
    public partial class QuizForm : Form
    {
        private Label[] categoryLabels;
        private Label[] scoreLabels;
        private Label[,] cardLabels;

        private SizeHelper sizeHelper = new SizeHelper();
        private FontHelper fontHelper = new FontHelper();

        private quiz quiz;

        public Team[] teams;
        public GroupBox[] scoreGroupBoxes;
        public Label[] teamScoreLabels;

        private string rootDirectory;
        private string questionFile;

        public QuizForm (Team[] teams, string rootDirectory, string questionFile)
        {
            this.teams = teams;
            this.rootDirectory = rootDirectory;
            this.questionFile = questionFile;
            InitializeComponent();
        }

        public void Startup()
        {
            quiz = DeserializeQuiz(Path.Combine(rootDirectory, questionFile));

            PopulateFields();
            PopulateTeams(teams);
            ResizeLabels();
        }

        public quiz DeserializeQuiz (string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(quiz));

            quiz i = null;
            Stream reader = new FileStream(filename, FileMode.Open);

            try
            {
                i = (quiz)serializer.Deserialize(reader);
            }
            catch
            {
                MessageBox.Show(this, "Det skedde ett fel då frågefilen lästes in. Var god försök igen.", "Frågefilsfel", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Environment.Exit(2);
            }
            return i;
        }

        public void ResizeLabels ()
        {
            int width = gbxQuestions.Width;
            int height = gbxQuestions.Height;
            string fontName = "Stencil";

            for (int i = 0; i < categoryLabels.Length; i++)
            {
                sizeHelper.SizeWidth(width, height, i, categoryLabels[i]);
            }

            for (int i = 0; i < scoreLabels.Length; i++)
            {
                sizeHelper.SizeHeight(width, height, i, scoreLabels[i]);
            }

            for (int i = 0; i < scoreGroupBoxes.Length; i++)
            {
                sizeHelper.SizeScoreGbx(this.Controls[0].Width, scoreGroupBoxes.Length, i, scoreGroupBoxes[i]);
                scoreGroupBoxes[i].Height = this.Controls[0].Height;
            }

            for (int i = 0; i < teamScoreLabels.Length; i++)
            {
                sizeHelper.SizeScoreLabels(this.Controls[0].Controls[0].Width, this.Controls[0].Controls[0].Height, teamScoreLabels.Length, teamScoreLabels[i]);
            }

            for (int i = 0; i < cardLabels.GetLength(0); i++)
            {
                for (int j = 0; j < cardLabels.GetLength(1); j++)
                sizeHelper.SizeCards(i, j, cardLabels[i, j]);
            }

            int fontSize = fontHelper.FontSize(categoryLabels, fontName, sizeHelper.horizontalWidth - 20, sizeHelper.horizontalHeight, this.CreateGraphics());

            for (int i = 0; i < categoryLabels.Length; i++)
            {
                fontHelper.SetFont(fontName, fontSize, categoryLabels[i]);
            }

            int fontSize2 = fontHelper.FontSizeString("25", fontName, sizeHelper.verticalWidth, sizeHelper.verticalHeight, this.CreateGraphics());

            for (int i = 0; i < scoreLabels.Length; i++)
            {
                fontHelper.SetFont(fontName, fontSize2, scoreLabels[i]);
            }

            int fontSize3 = fontHelper.FontSizeString("AAAAAAAAAAAAAAAAAAA", fontName, teamScoreLabels[0].Width, (int)(teamScoreLabels[0].Height), this.CreateGraphics());
            for (int i = 0; i < teamScoreLabels.Length; i++)
            {
                fontHelper.SetFont(fontName, fontSize3, teamScoreLabels[i]);
            }
        }

        public void PopulateFields()
        {
            for(int i = 0; i < categoryLabels.Length; i++)
            {
                categoryLabels[i].Text = quiz.category[i].name;
            }
        }

        public void PopulateTeams(Team[] teams)
        {
            scoreGroupBoxes = new GroupBox[teams.Length];
            teamScoreLabels = new Label[teams.Length];

            for (int i = 0; i < teams.Length; i++)
            {
                GroupBox gbx = new GroupBox();
                gbx.Width = (Width - 20) / teams.Length;
                gbx.Height = this.Controls[0].Height;
                gbx.Text = teams[i].TeamName;
                gbx.Name = "gbxTeam" + (i + 1);
                gbx.Location = new Point((gbx.Width) * i + 10, 0);
                gbx.Font = new Font("Stencil", 20);

                scoreGroupBoxes[i] = gbx;
                this.Controls[0].Controls.Add(gbx);

                Label lbl = new Label();
                lbl.Name = "lblTeamScore" + (i + 1);
                lbl.Width = gbx.Width - 4;
                lbl.Height = gbx.Height - 32;
                lbl.Location = new Point(2, 32);
                lbl.Text = teams[i].Score.ToString() + " Poäng";
                lbl.BackColor = Color.Khaki;
                lbl.TextAlign = ContentAlignment.MiddleCenter;

                teamScoreLabels[i] = lbl;
                this.Controls[0].Controls[i].Controls.Add(lbl);
                Invalidate();
            }
        }

        public void HitChecker (int x, int y, Label sender)
        {
            for (int i = 0; i < cardLabels.GetLength(0); i++)
            {
                for (int j = 0; j < cardLabels.GetLength(1); j++)
                {
                    if (cardLabels[i, j].Name == sender.Name)
                    {
                        Console.WriteLine("The card for point " + (i + 1) + " and category " + (j + 1) + " was hit.");
                        QuestionPopup popup = new QuestionPopup(quiz.category[j].question[i].text, quiz.category[j].question[i].answer, i + 1, teams, quiz.category[j].question[i].type, rootDirectory, quiz.category[j].question[i].mediaFile);
                        popup.ShowDialog();
                        sender.BackColor = Color.DarkOrange;
                        sender.TextAlign = ContentAlignment.MiddleCenter;
                        sender.Text = "Öppnad";
                        sender.Font = new Font("Stencil", 10);
                        UpdateScore();
                        break;
                    }
                }
            }
        }

        private void UpdateScore ()
        {
            for (int i = 0; i < teams.Length; i++)
            {
                this.Controls[0].Controls[i].Controls[0].Text = teams[i].Score.ToString() + " Poäng";
            }
        }

        private void QuizForm_Shown (object sender, EventArgs e)
        {
            Invalidate();
            categoryLabels = new Label[5];
            categoryLabels[0] = lblCat1;
            categoryLabels[1] = lblCat2;
            categoryLabels[2] = lblCat3;
            categoryLabels[3] = lblCat4;
            categoryLabels[4] = lblCat5;

            scoreLabels = new Label[5];
            scoreLabels[0] = lblScore1;
            scoreLabels[1] = lblScore2;
            scoreLabels[2] = lblScore3;
            scoreLabels[3] = lblScore4;
            scoreLabels[4] = lblScore5;

            cardLabels = new Label[5, 5];
            cardLabels[0, 0] = lblPoint1Cat1;
            cardLabels[0, 1] = lblPoint1Cat2;
            cardLabels[0, 2] = lblPoint1Cat3;
            cardLabels[0, 3] = lblPoint1Cat4;
            cardLabels[0, 4] = lblPoint1Cat5;

            cardLabels[1, 0] = lblPoint2Cat1;
            cardLabels[1, 1] = lblPoint2Cat2;
            cardLabels[1, 2] = lblPoint2Cat3;
            cardLabels[1, 3] = lblPoint2Cat4;
            cardLabels[1, 4] = lblPoint2Cat5;

            cardLabels[2, 0] = lblPoint3Cat1;
            cardLabels[2, 1] = lblPoint3Cat2;
            cardLabels[2, 2] = lblPoint3Cat3;
            cardLabels[2, 3] = lblPoint3Cat4;
            cardLabels[2, 4] = lblPoint3Cat5;

            cardLabels[3, 0] = lblPoint4Cat1;
            cardLabels[3, 1] = lblPoint4Cat2;
            cardLabels[3, 2] = lblPoint4Cat3;
            cardLabels[3, 3] = lblPoint4Cat4;
            cardLabels[3, 4] = lblPoint4Cat5;

            cardLabels[4, 0] = lblPoint5Cat1;
            cardLabels[4, 1] = lblPoint5Cat2;
            cardLabels[4, 2] = lblPoint5Cat3;
            cardLabels[4, 3] = lblPoint5Cat4;
            cardLabels[4, 4] = lblPoint5Cat5;

            for (int i = 0; i < cardLabels.GetLength(0); i++)
            {
                for (int j = 0; j < cardLabels.GetLength(1); j++)
                {
                    cardLabels[i, j].MouseUp += new System.Windows.Forms.MouseEventHandler(this.GbxQuestions_MouseUp);
                }
            }

            Startup();
        }

        private void QuizForm_ResizeEnd (object sender, EventArgs e)
        {
            ResizeLabels();
        }

        private void GbxQuestions_MouseUp (object sender, MouseEventArgs e)
        {
            HitChecker(e.X, e.Y, (Label)sender);
        }

        private void QuizForm_FormClosed (object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
