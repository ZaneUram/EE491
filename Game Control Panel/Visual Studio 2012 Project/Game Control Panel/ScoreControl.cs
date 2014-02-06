using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Control_Panel
{
    public partial class ScoreControl : UserControl
    {
        private int numberOfLives=6;
        private int Player1ScoreValue=0;
        private int Player2ScoreValue=0;
        private int Player3ScoreValue=0;
        private int Player4ScoreValue=0;
        private int NumberOfTeams = 0;
        public ScoreControl()
        {
            InitializeComponent();
        }
        public void setNumberOfLives(int lives)
        {
            if (lives >= 0 && lives <= 6)
            {
                numberOfLives = lives;
            }
            else
            {
                Console.WriteLine("Attempt to set numberOfLives equal to {0} stopped because {0} is not in the valid range.", lives);
            }
        }
        public int getNumberOfLives()
        {
            return numberOfLives;
        }
        public void setNumberOfTeams(int teams)
        {
            if (teams >= 0 && teams <= 4)
            {
                NumberOfTeams = teams;
            }
            else
            {
                Console.WriteLine("Attempt to set NumberOfTeams equal to {0} stopped because {0} is not in the valid range.", teams);
            }

            switch (NumberOfTeams)
            {
                case 2:
                    //Players 1 and 2 are not forced to a visible state because they are never hidden
                    Player3Label.Visible=false;
                    Player3Lives.Visible=false;
                    Player3Score.Visible=false;
                    Player4Label.Visible=false;
                    Player4Lives.Visible=false;
                    Player4Score.Visible=false;
                    Player1Label.Text = "Team 1";
                    Player2Label.Text = "Team 2";
                    Player3Label.Text = "Team 3";
                    Player4Label.Text = "Team 4";
                    break;
                case 3:
                    //Players 1 and 2 are not forced to a visible state because they are never hidden
                    Player3Label.Visible = true;
                    Player3Lives.Visible = true;
                    Player3Score.Visible = true;
                    Player4Label.Visible = false;
                    Player4Lives.Visible = false;
                    Player4Score.Visible = false;
                    Player1Label.Text = "Team 1";
                    Player2Label.Text = "Team 2";
                    Player3Label.Text = "Team 3";
                    Player4Label.Text = "Team 4";
                    break;
                case 4:
                    //Players 1 and 2 are not forced to a visible state because they are never hidden
                    Player3Label.Visible = true;
                    Player3Lives.Visible = true;
                    Player3Score.Visible = true;
                    Player4Label.Visible = true;
                    Player4Lives.Visible = true;
                    Player4Score.Visible = true;
                    Player1Label.Text = "Team 1";
                    Player2Label.Text = "Team 2";
                    Player3Label.Text = "Team 3";
                    Player4Label.Text = "Team 4";
                    break;
                default:
                case 0:
                    //Players 1 and 2 are not forced to a visible state because they are never hidden
                    Player3Label.Visible = true;
                    Player3Lives.Visible = true;
                    Player3Score.Visible = true;
                    Player4Label.Visible = true;
                    Player4Lives.Visible = true;
                    Player4Score.Visible = true;
                    Player1Label.Text = "Player 1";
                    Player2Label.Text = "Player 2";
                    Player3Label.Text = "Player 3";
                    Player4Label.Text = "Player 4";
                    break;
            }
        }
        public int getNumberOfTeams()
        {
            return NumberOfTeams;
        }
        public void StartGame(int lives)
        {
            setNumberOfLives(lives);
            //Begins code to set all life indicators
            Player1Lives.Value = 100;
            Player2Lives.Value = 100;
            Player3Lives.Value = 100;
            Player4Lives.Value = 100;
            //Ends code to set all life indicators
        }
        public void ResetGame() //Called to clear all game data
        {
            Player1Lives.Value = 0;
            Player2Lives.Value = 0;
            Player3Lives.Value = 0;
            Player4Lives.Value = 0;
            Player1Lives.Value = 0;
            Player2Lives.Value = 0;
            Player3Lives.Value = 0;
            Player4Lives.Value = 0;
            GameScores.Text = "";
        }
    }
}
