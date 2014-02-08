using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace Game_Control_Panel
{
    public partial class ScoreControl : UserControl
    {
        private int numberOfLives=6;
        private int Player1ScoreValue=0;
        private int Player2ScoreValue=0;
        private int Player3ScoreValue=0;
        private int Player4ScoreValue = 0;
        private int Player1LivesCount;
        private int Player2LivesCount;
        private int Player3LivesCount;
        private int Player4LivesCount;
        private int HitBonus = 100; //The number of points gained from a successful shot
        private int deathDeduction = 25; //The number of points lost from a player's death
        private int NumberOfTeams = 0; //Valid values are 0, 2, 3, and 4
        private string ScoreFileDirectory = "c://Robotag";
        private string ScoreFileName = "GameScores.txt";
        StreamReader Stream = null;
        Regex expression = new Regex("Player\\d");
        string fileText;
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
        public void StartGame(int lives, string message)
        {
            setNumberOfLives(lives);

            StreamWriter WriteAccess = null;
            if (!Directory.Exists(ScoreFileDirectory))
            {
                Directory.CreateDirectory(ScoreFileDirectory);
            }
            if (!File.Exists(ScoreFileDirectory + "\\" + ScoreFileName))
            {
                File.CreateText(ScoreFileDirectory + "\\" + ScoreFileName);
            }
            try
            {
                using (WriteAccess = new StreamWriter(ScoreFileDirectory + "\\" + ScoreFileName))
                {
                    string[] MessageLines = message.Split('\n');
                    foreach (var line in MessageLines)
                    {
                        WriteAccess.WriteLine(line);
                    }
                    WriteAccess.WriteLine();
                    WriteAccess.WriteLine(); //adds two blank lines for readability
                    //Adding data to test program by
                    WriteAccess.WriteLine("00:00:00 Player1 shot Player1");
                    WriteAccess.WriteLine("00:00:00 Player1 shot Player2");
                    WriteAccess.WriteLine("00:00:00 Player1 shot Player3");
                    WriteAccess.WriteLine("00:00:00 Player1 shot Player4");
                    WriteAccess.WriteLine("00:00:00 Player2 shot Player1");
                    WriteAccess.WriteLine("00:00:00 Player2 shot Player2");
                    WriteAccess.WriteLine("00:00:00 Player2 shot Player3");
                    WriteAccess.WriteLine("00:00:00 Player2 shot Player4");
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error writing to file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WriteAccess.Close(); //Close read access to file
            updateGame();
        }
        public void updateGame()
        {
            try
            {
                using (Stream = new StreamReader(ScoreFileDirectory + "\\" + ScoreFileName))
                {
                    fileText = Stream.ReadToEnd();
                    GameScores.Text = fileText;
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error reading from file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Stream.Close();
            string[] fileLines = fileText.Split('\n');
            Match hitData;
            int shootingPlayer;
            int playerHit;
            Player1ScoreValue = 0;
            Player2ScoreValue = 0;
            Player3ScoreValue = 0;
            Player4ScoreValue = 0;
            Player1LivesCount = numberOfLives;
            Player2LivesCount = numberOfLives;
            Player3LivesCount = numberOfLives;
            Player4LivesCount = numberOfLives;
            for (int i = 0; i < fileLines.Length; i++)
			{
                if (expression.Matches(fileLines[i]).Count==2) //Each line with a hit should have two epressions of PlayerX
                {
                    hitData = expression.Match(fileLines[i]);
                    shootingPlayer = Convert.ToInt32(Regex.Match(hitData.ToString(), @"\d").ToString());
                    hitData=hitData.NextMatch();
                    playerHit = Convert.ToInt32(Regex.Match(hitData.ToString(), @"\d").ToString());
                    if (shootingPlayer != playerHit)
                    {
                        if (NumberOfTeams == 0)
                        {
                            if (shootingPlayer >= 1 && shootingPlayer <= 4 && playerHit >= 1 && playerHit <= 4) //Valid values for individual game
                            {
                                ScoreHit(shootingPlayer, playerHit);
                            }
                        }
                        else
                        {
                            if (shootingPlayer >= 1 && shootingPlayer <= NumberOfTeams && playerHit >= 1 && playerHit <= NumberOfTeams) //Valid values for individual game
                            {
                                ScoreHit(shootingPlayer, playerHit);
                            }
                        }
                    }
                }
			}

            //Begins code to set all life indicators
            Player1Lives.Value = (100 * Player1LivesCount) / numberOfLives;
            Player2Lives.Value = (100 * Player2LivesCount) / numberOfLives;
            Player3Lives.Value = (100 * Player3LivesCount) / numberOfLives;
            Player4Lives.Value = (100 * Player4LivesCount) / numberOfLives;
            //Ends code to set all life indicators

            //Begins code to set all score labels
            Player1Score.Text = Player1ScoreValue.ToString() + " Points";
            Player2Score.Text = Player2ScoreValue.ToString() + " Points";
            Player3Score.Text = Player3ScoreValue.ToString() + " Points";
            Player4Score.Text = Player4ScoreValue.ToString() + " Points";
            //Ends code to set all score labels
        }
        private void ScoreHit(int shootingPlayer, int playerHit)
        {
            switch (playerHit)
            {
                case 1:
                    if (Player1ScoreValue > 0 + deathDeduction)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player1ScoreValue -= deathDeduction;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player1ScoreValue -= deathDeduction;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player1ScoreValue -= deathDeduction;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player1ScoreValue -= deathDeduction;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player1ScoreValue = 0;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player1ScoreValue = 0;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player1ScoreValue = 0;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player1ScoreValue = 0;
                                }
                                break;
                        }
                    }
                    if (Player1LivesCount>0)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player1LivesCount--;
                                    Player1ScoreValue += HitBonus;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player1LivesCount--;
                                    Player2ScoreValue += HitBonus;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player1LivesCount--;
                                    Player3ScoreValue += HitBonus;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player1LivesCount--;
                                    Player4ScoreValue += HitBonus;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Player1LivesCount = 0;
                    }
                    break;
                case 2:
                    if (Player2ScoreValue > 0 + deathDeduction)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player2ScoreValue -= deathDeduction;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player2ScoreValue -= deathDeduction;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player2ScoreValue -= deathDeduction;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player2ScoreValue -= deathDeduction;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player2ScoreValue = 0;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player2ScoreValue = 0;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player2ScoreValue = 0;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player2ScoreValue = 0;
                                }
                                break;
                        }
                    }
                    if (Player2LivesCount > 0)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player1ScoreValue += HitBonus;
                                    Player2LivesCount--;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player2ScoreValue += HitBonus;
                                    Player2LivesCount--;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player3ScoreValue += HitBonus;
                                    Player2LivesCount--;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player4ScoreValue += HitBonus;
                                    Player2LivesCount--;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Player2LivesCount = 0;
                    }
                    break;
                case 3:
                    if (Player3ScoreValue > 0 + deathDeduction)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player3ScoreValue -= deathDeduction;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player3ScoreValue -= deathDeduction;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player3ScoreValue -= deathDeduction;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player3ScoreValue -= deathDeduction;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player3ScoreValue = 0;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player3ScoreValue = 0;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player3ScoreValue = 0;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player3ScoreValue = 0;
                                }
                                break;
                        }
                    }
                    if (Player3LivesCount > 0)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player1ScoreValue += HitBonus;
                                    Player3LivesCount--;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player2ScoreValue += HitBonus;
                                    Player3LivesCount--;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player3ScoreValue += HitBonus;
                                    Player3LivesCount--;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player4ScoreValue += HitBonus;
                                    Player3LivesCount--;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Player3LivesCount = 0;
                    }
                    break;
                case 4:
                    if (Player4ScoreValue > 0 + deathDeduction)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player4ScoreValue -= deathDeduction;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player4ScoreValue -= deathDeduction;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player4ScoreValue -= deathDeduction;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player4ScoreValue -= deathDeduction;
                                }
                                break;
                        }
                    }
                    else
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player4ScoreValue = 0;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player4ScoreValue = 0;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player4ScoreValue = 0;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player4ScoreValue = 0;
                                }
                                break;
                        }
                    }
                    if (Player4LivesCount > 0)
                    {
                        switch (shootingPlayer)
                        {
                            case 1:
                                if (Player1LivesCount > 0)
                                {
                                    Player1ScoreValue += HitBonus;
                                    Player4LivesCount--;
                                }
                                break;
                            case 2:
                                if (Player2LivesCount > 0)
                                {
                                    Player2ScoreValue += HitBonus;
                                    Player4LivesCount--;
                                }
                                break;
                            case 3:
                                if (Player3LivesCount > 0)
                                {
                                    Player3ScoreValue += HitBonus;
                                    Player4LivesCount--;
                                }
                                break;
                            case 4:
                                if (Player4LivesCount > 0)
                                {
                                    Player4ScoreValue += HitBonus;
                                    Player4LivesCount--;
                                }
                                break;
                        }
                    }
                    else
                    {
                        Player4LivesCount = 0;
                    }
                    break;
            }
        }
        public void ResetGame() //Called to clear all game data
        {
            Player1ScoreValue = 0;
            Player2ScoreValue = 0;
            Player3ScoreValue = 0;
            Player4ScoreValue = 0;
            Player1Score.Text = "0 Points";
            Player2Score.Text = "0 Points";
            Player3Score.Text = "0 Points";
            Player4Score.Text = "0 Points";
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
