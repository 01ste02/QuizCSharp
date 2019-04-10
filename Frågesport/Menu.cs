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
    public partial class Menu : Form
    {
        private int numTeams = 0;
        List<TextBox> teamNames = new List<TextBox>();
        private int xPos = 10;
        private int yPos = 40;
        private int tbxWidth;
        private int height = 40;

        public Menu ()
        {
            InitializeComponent();
            
        }

        private void btnAdd_Click (object sender, EventArgs e)
        {
            if (numTeams < 9)
            {
                TextBox textBox = new TextBox();
                textBox.Name = "tbxTeam" + numTeams++;
                textBox.Text = "";
                textBox.Font = new Font("Microsoft Sans Serif", 16);
                textBox.Width = tbxWidth;
                textBox.TextAlign = HorizontalAlignment.Center;

                textBox.Location = new Point(xPos, yPos);
                yPos += height + 10;

                teamNames.Add(textBox);
                this.Controls.Add(teamNames[numTeams - 1]);
                this.Height = this.Height + textBox.Height + 18;
            }
        }

        private void Menu_Load (object sender, EventArgs e)
        {
            Invalidate();

            tbxWidth = this.Width - 40;
            int max = numTeams;
            for (int i = 0; i < max + 1; i++)
            {
                TextBox textBox = new TextBox();
                textBox.Name = "tbxTeam" + numTeams++;
                textBox.Text = "";
                textBox.Font = new Font("Microsoft Sans Serif", 16);
                textBox.Height = height;
                textBox.Width = tbxWidth;
                textBox.TextAlign = HorizontalAlignment.Center;

                textBox.Location = new Point(xPos, yPos);
                yPos += height + 10;

                teamNames.Add(textBox);
                this.Controls.Add(teamNames[i]);
                
            }
        }

        private void btnRemove_Click (object sender, EventArgs e)
        {
            if (numTeams > 1)
            {
                this.Height = this.Height - teamNames[numTeams - 1].Height - 18;
                yPos -= height + 10;
                Controls.Remove(teamNames[numTeams - 1]);
                teamNames.Remove(teamNames[numTeams - 1]);
                numTeams--;
            }
        }

        private void btnStart_Click (object sender, EventArgs e)
        {
            bool allSet = true;
            for (int i = 0; i < teamNames.Count; i++)
            {
                if (teamNames[i].Text == "" || teamNames[i].Text == " ")
                {
                    allSet = false;
                }
            }

            if (allSet)
            {
                Team[] teams = new Team[teamNames.Count];
                for (int i = 0; i < teamNames.Count; i++)
                {
                    teams[i] = new Team(teamNames[i].Text);
                }

                QuizForm quiz = new QuizForm(teams);
                quiz.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(this, "Alla lagnamn blev ej ifyllda. Var god fyll i alla lagnamn!", "Fel i lagnamn", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
