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
    public partial class AwardPoints : Form
    {

        /* TODO:
         * Fixa autostorlek
         * Fixa namn på formulär (+loggor?)
         * Fixa frågor
         * Välj Frågefil?
         * Autofont på AwardPoints
         * AutoStorlek på QuestionPopup
         * Buggtester
         */
        private int numTeams = 0;
        private Team[] teams;
        private int maxPoints = 0;
        private Label[] pointLabels;
        private Button[,] pointButtons;
        private GroupBox[] pointGroupBoxes;

        private FontHelper fontHelper = new FontHelper();

        public AwardPoints (int maxPoint, int teamNum, Team[] teams)
        {
            InitializeComponent();
            this.teams = teams;
            numTeams = teamNum;
            maxPoints = maxPoint;

            gbxMain.BackColor = Color.LemonChiffon;
        }

        private void CreateCards ()
        {
            int numWide = 0;
            int numHigh = 0;

            if (numTeams <= 3)
            {
                numHigh = 1;
                numWide = numTeams;
            }
            else if (numTeams > 3 && numTeams <= 6)
            {
                numHigh = 2;
                numWide = 3;
            }
            else if (numTeams > 6 && numTeams <= 9)
            {
                numHigh = 3;
                numWide = 3;
            }

            int row = 0;
            int column = 0;

            pointGroupBoxes = new GroupBox[numTeams];
            pointLabels = new Label[numTeams];
            pointButtons = new Button[numTeams, 6];

            for(int i = 0; i < numTeams; i++)
            {
                GroupBox gbx = new GroupBox();
                gbx.Name = "gbxTeam" + (i + 1);
                gbx.Text = teams[i].TeamName;
                gbx.Font = new Font("Palatino Linotype", 20);
                gbx.Width = (gbxMain.Width / numWide) - 20;
                gbx.Height = (gbxMain.Height / numHigh) - 20;
                gbx.Location = new Point(10 * (column + 1) + column * gbx.Width, 10 + row * gbx.Height);
                gbx.BackColor = Color.LemonChiffon;

                pointGroupBoxes[i] = gbx;
                this.Controls[1].Controls.Add(gbx);

                Label lbl = new Label();
                lbl.Name = "lblTeam" + (i + 1);
                lbl.Text = "Poäng:";
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.BackColor = Color.Khaki;
                lbl.Location = new Point(4, 30);
                lbl.Width = gbx.Width - 8;
                lbl.Height = (gbx.Height - 30) / 2;

                pointLabels[i] = lbl;
                this.Controls[1].Controls[i].Controls.Add(lbl);

                Button btn1 = new Button();
                btn1.Name = "btnTeam" + (i + 1) + "Remove1";
                btn1.Text = "-1";
                btn1.Font = new Font("Palatino Linotype", 8);
                btn1.Width = (gbx.Width - 40) / 3;
                btn1.Height = (((gbx.Height - 40) / 2) - 20) / 2;
                btn1.Location = new Point(10, lbl.Location.Y + lbl.Height + 10);
                btn1.Click += new EventHandler(btnPointClick);

                Button btn2 = new Button();
                btn2.Name = "btnTeam" + (i + 1) + "Add1";
                btn2.Text = "+1";
                btn2.Font = new Font("Palatino Linotype", 8);
                btn2.Width = (gbx.Width - 40) / 3;
                btn2.Height = (((gbx.Height - 40) / 2) - 20) / 2;
                btn2.Location = new Point(20 + btn1.Width , lbl.Location.Y + lbl.Height + 10);
                btn2.Click += new EventHandler(btnPointClick);

                Button btn3 = new Button();
                btn3.Name = "btnTeam" + (i + 1) + "Add2";
                btn3.Text = "+2";
                btn3.Font = new Font("Palatino Linotype", 8);
                btn3.Width = (gbx.Width - 40) / 3;
                btn3.Height = (((gbx.Height - 40) / 2) - 20) / 2;
                btn3.Location = new Point(30 + btn1.Width * 2, lbl.Location.Y + lbl.Height + 10);
                btn3.Click += new EventHandler(btnPointClick);

                Button btn4 = new Button();
                btn4.Name = "btnTeam" + (i + 1) + "Add3";
                btn4.Text = "+3";
                btn4.Font = new Font("Palatino Linotype", 8);
                btn4.Width = (gbx.Width - 40) / 3;
                btn4.Height = (((gbx.Height - 40) / 2) - 20) / 2;
                btn4.Location = new Point(10, lbl.Location.Y + lbl.Height + 20 + btn1.Height);
                btn4.Click += new EventHandler(btnPointClick);

                Button btn5 = new Button();
                btn5.Name = "btnTeam" + (i + 1) + "Add4";
                btn5.Text = "+4";
                btn5.Font = new Font("Palatino Linotype", 8);
                btn5.Width = (gbx.Width - 40) / 3;
                btn5.Height = (((gbx.Height - 40) / 2) - 20) / 2;
                btn5.Location = new Point(20 + btn1.Width, lbl.Location.Y + lbl.Height + 20 + btn1.Height);
                btn5.Click += new EventHandler(btnPointClick);

                Button btn6 = new Button();
                btn6.Name = "btnTeam" + (i + 1) + "Add5";
                btn6.Text = "+5";
                btn6.Font = new Font("Palatino Linotype", 8);
                btn6.Width = (gbx.Width - 40) / 3;
                btn6.Height = (((gbx.Height - 40) / 2) - 20) / 2;
                btn6.Location = new Point(30 + btn1.Width * 2, lbl.Location.Y + lbl.Height + 20 + btn1.Height);
                btn6.Click += new EventHandler(btnPointClick);

                Button[] buttons = new Button[5];
                buttons[0] = btn2;
                buttons[1] = btn3;
                buttons[2] = btn4;
                buttons[3] = btn5;
                buttons[4] = btn6;

                for (int j = 0; j < buttons.Length; j++)
                {
                    if (buttons[j].Text.Contains(String.Concat("+", maxPoints.ToString())))
                    {
                        buttons[j].BackColor = Color.Khaki;
                    }
                }


                pointButtons[i, 0] = btn1;
                pointButtons[i, 1] = btn2;
                pointButtons[i, 2] = btn3;
                pointButtons[i, 3] = btn4;
                pointButtons[i, 4] = btn5;
                pointButtons[i, 5] = btn6;
                this.Controls[1].Controls[i].Controls.Add(btn1);
                this.Controls[1].Controls[i].Controls.Add(btn2);
                this.Controls[1].Controls[i].Controls.Add(btn3);
                this.Controls[1].Controls[i].Controls.Add(btn4);
                this.Controls[1].Controls[i].Controls.Add(btn5);
                this.Controls[1].Controls[i].Controls.Add(btn6);

                int fontSizeLbl = fontHelper.FontSizeString(lbl.Text, "Palatino Linotype", lbl.Width / 2, lbl.Height, this.CreateGraphics());
                int fontSizeBtn = fontHelper.FontSizeString(pointButtons[i, 0].Text, "Palatino Linotype", pointButtons[i, 0].Width / 2, pointButtons[i, 0].Height, this.CreateGraphics()) / 2;

                lbl.Font = new Font("Palatino Linotype", fontSizeLbl);
                pointButtons[i, 0].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 1].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 2].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 3].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 4].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 5].Font = new Font("Palatino Linotype", fontSizeBtn);

                column++;

                if (i == 2)
                {
                    row++;
                    column = 0;
                }
                if (i == 5)
                {
                    row++;
                    column = 0;
                }
            }
            Invalidate();
        }

        private void AwardPoints_Shown (object sender, EventArgs e)
        {
            Invalidate();
            CreateCards();
        }

        private void btnPointClick (object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            for (int i = 0; i < numTeams; i++)
            {
                if (btn.Name.Contains("btnTeam" + (i + 1)))
                {
                    if (btn.Name.Contains("Remove1")) //Bör ej användas då den ej implementerats än... Bara en kan klickas på åt gången. TODO
                    {
                        teams[i].Score += -1;
                        MessageBox.Show(this, "1 Poäng borttaget från lag " + teams[i].TeamName, "Poäng borttaget", MessageBoxButtons.OK);
                    }
                    else if (btn.Name.Contains("Add1"))
                    {
                        teams[i].Score += +1;
                        MessageBox.Show(this, "En poäng tillagt till lag " + teams[i].TeamName, "Poäng tillagt", MessageBoxButtons.OK);
                    }
                    else if (btn.Name.Contains("Add2"))
                    {
                        teams[i].Score += +2;
                        MessageBox.Show(this, "Två poäng tillagda till lag " + teams[i].TeamName, "Poäng tillagda", MessageBoxButtons.OK);
                    }
                    else if (btn.Name.Contains("Add3"))
                    {
                        teams[i].Score += +3;
                        MessageBox.Show(this, "Tre poäng tillagda till lag " + teams[i].TeamName, "Poäng tillagda", MessageBoxButtons.OK);
                    }
                    else if (btn.Name.Contains("Add4"))
                    {
                        teams[i].Score += +4;
                        MessageBox.Show(this, "Fyra poäng tillagda till lag " + teams[i].TeamName, "Poäng tillagda", MessageBoxButtons.OK);
                    }
                    else if (btn.Name.Contains("Add5"))
                    {
                        teams[i].Score += +5;
                        MessageBox.Show(this, "Fem poäng tillagda till lag " + teams[i].TeamName, "Poäng tillagda", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void AwardPoints_ResizeEnd (object sender, EventArgs e)
        {
            int numWide = 0;
            int numHigh = 0;

            if (numTeams <= 3)
            {
                numHigh = 1;
                numWide = numTeams;
            }
            else if (numTeams > 3 && numTeams <= 6)
            {
                numHigh = 2;
                numWide = 3;
            }
            else if (numTeams > 6 && numTeams <= 9)
            {
                numHigh = 3;
                numWide = 3;
            }

            int row = 0;
            int column = 0;
            for (int i = 0; i < numTeams; i++)
            {
                GroupBox gbx = pointGroupBoxes[i];
                gbx.Width = (gbxMain.Width / numWide) - 20;
                gbx.Height = (gbxMain.Height / numHigh) - 20;
                gbx.Location = new Point(10 * (column + 1) + column * gbx.Width, 10 + row * gbx.Height);

                Label lbl = pointLabels[i];

                lbl.Location = new Point(4, 30);
                lbl.Width = gbx.Width - 8;
                lbl.Height = (gbx.Height - 30) / 2;

                pointButtons[i, 0].Width = (gbx.Width - 40) / 3;
                pointButtons[i, 1].Width = (gbx.Width - 40) / 3;
                pointButtons[i, 2].Width = (gbx.Width - 40) / 3;
                pointButtons[i, 3].Width = (gbx.Width - 40) / 3;
                pointButtons[i, 4].Width = (gbx.Width - 40) / 3;
                pointButtons[i, 5].Width = (gbx.Width - 40) / 3;

                pointButtons[i, 0].Height = (((gbx.Height - 40) / 2) - 20) / 2;
                pointButtons[i, 1].Height = (((gbx.Height - 40) / 2) - 20) / 2;
                pointButtons[i, 2].Height = (((gbx.Height - 40) / 2) - 20) / 2;
                pointButtons[i, 3].Height = (((gbx.Height - 40) / 2) - 20) / 2;
                pointButtons[i, 4].Height = (((gbx.Height - 40) / 2) - 20) / 2;
                pointButtons[i, 5].Height = (((gbx.Height - 40) / 2) - 20) / 2;

                pointButtons[i, 0].Location = new Point(10, lbl.Location.Y + lbl.Height + 10);
                pointButtons[i, 1].Location = new Point(20 + pointButtons[i, 0].Width, lbl.Location.Y + lbl.Height + 10);
                pointButtons[i, 2].Location = new Point(30 + pointButtons[i, 0].Width * 2, lbl.Location.Y + lbl.Height + 10);
                pointButtons[i, 3].Location = new Point(10, lbl.Location.Y + lbl.Height + 20 + pointButtons[i, 0].Height);
                pointButtons[i, 4].Location = new Point(20 + pointButtons[i, 0].Width, lbl.Location.Y + lbl.Height + 20 + pointButtons[i, 0].Height);
                pointButtons[i, 5].Location = new Point(30 + pointButtons[i, 0].Width * 2, lbl.Location.Y + lbl.Height + 20 + pointButtons[i, 0].Height);

                int fontSizeLbl = fontHelper.FontSizeString(lbl.Text, "Palatino Linotype", lbl.Width, lbl.Height, this.CreateGraphics());
                int fontSizeBtn = fontHelper.FontSizeString(pointButtons[i, 0].Text, "Palatino Linotype", pointButtons[i, 0].Width, pointButtons[i, 0].Height, this.CreateGraphics()) / 2;

                lbl.Font = new Font("Palatino Linotype", fontSizeLbl);
                pointButtons[i, 0].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 1].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 2].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 3].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 4].Font = new Font("Palatino Linotype", fontSizeBtn);
                pointButtons[i, 5].Font = new Font("Palatino Linotype", fontSizeBtn);

                column++;

                if (i == 2)
                {
                    row++;
                    column = 0;
                }
                if (i == 5)
                {
                    row++;
                    column = 0;
                }
            }

            //int fontSizeBtn1 = fontHelper.FontSizeString(btnDone.Text, "Stencil", btnDone.Width, btnDone.Height, this.CreateGraphics()); //Unnessecary
            //btnDone.Font = new Font("Stencil", fontSizeBtn1);

            Invalidate();
        }

        private void btnDone_Click (object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
