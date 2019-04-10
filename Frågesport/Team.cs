using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frågesport
{
    public class Team
    {
        private string teamName = "";
        private int score = 0;

        public Team (string name)
        {
            teamName = name;
        }

        public string TeamName
        {
            get
            {
                return teamName;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                try
                {
                    score = value;
                }
                catch
                {

                }
            }
        }
    }
}
