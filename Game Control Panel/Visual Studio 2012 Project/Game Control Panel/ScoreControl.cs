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
        public const string SCOREFILEDIRECTORY = "c://Robotag";
        public const string SCOREFILENAME = "GameScores.txt";
        public const string ARCHIVEDIRECTORY = "Archives";
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
            if (!Directory.Exists(SCOREFILEDIRECTORY))
            {
                Directory.CreateDirectory(SCOREFILEDIRECTORY);
            }
            if (!File.Exists(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
            {
                File.CreateText(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME).Close();
            }
            try
            {
                using (WriteAccess = new StreamWriter(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
                {
                    string[] MessageLines = message.Split('\n');
                    foreach (var line in MessageLines)
                    {
                        WriteAccess.WriteLine(line);
                    }
                    WriteAccess.WriteLine(); //adds blank line for readability
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
                using (Stream = new StreamReader(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
                {
                    fileText = Stream.ReadToEnd();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error reading from file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Stream.Close();
            GameScores.Text = fileText;
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
        public bool OnePlayerRemaining() //Returns true if there is only one player alvie so that the game can end
        {
            switch (NumberOfTeams)
            {
                case 2:
                    Player3LivesCount = 0;
                    Player4LivesCount = 0;
                    break;
                case 3:
                    Player4LivesCount = 0;
                    break;
                case 4:
                case 0:
                default:
                    break;
            }
            if ((Player1LivesCount == 0 && Player2LivesCount == 0 && Player3LivesCount == 0 && Player4LivesCount != 0) || (Player1LivesCount == 0 && Player2LivesCount == 0 && Player3LivesCount != 0 && Player4LivesCount == 0) || (Player1LivesCount == 0 && Player2LivesCount != 0 && Player3LivesCount == 0 && Player4LivesCount == 0) || (Player1LivesCount != 0 && Player2LivesCount == 0 && Player3LivesCount == 0 && Player4LivesCount == 0))
            {
                return true;
            }
            else
            {
                return false;
            }
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
        public void AppendResults() //Appends the game scores to the file
        {
            if (!Directory.Exists(SCOREFILEDIRECTORY))
            {
                Directory.CreateDirectory(SCOREFILEDIRECTORY);
            }
            if (!File.Exists(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
            {
                File.CreateText(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME).Close();
            }
            StreamWriter WriteAccess = null;
            try
            {
                using (WriteAccess = new StreamWriter(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
                {
                    string[] fileData = GameScores.Text.Split('\n');
                    foreach (var line in fileData)
                    {
                        WriteAccess.WriteLine(line);
                    }
                    WriteAccess.WriteLine();
                    WriteAccess.WriteLine();
                    WriteAccess.WriteLine("Final Game Scores:");
                    WriteAccess.WriteLine();
                    WriteAccess.WriteLine(Player1Label.Text);
                    WriteAccess.WriteLine("\t" + Player1Score.Text);
                    if (Player1LivesCount != 1)
                    {
                        WriteAccess.WriteLine("\t" + Player1LivesCount + " Lives");
                    }
                    else
                    {
                        WriteAccess.WriteLine("\t" + Player1LivesCount + " Life");
                    }
                    WriteAccess.WriteLine();
                    WriteAccess.WriteLine(Player2Label.Text);
                    WriteAccess.WriteLine("\t" + Player2Score.Text);
                    if (Player2LivesCount != 1)
                    {
                        WriteAccess.WriteLine("\t" + Player2LivesCount + " Lives");
                    }
                    else
                    {
                        WriteAccess.WriteLine("\t" + Player2LivesCount + " Life");
                    }
                    WriteAccess.WriteLine();
                    if (NumberOfTeams == 3 || NumberOfTeams == 4 || NumberOfTeams == 0)
                    {
                        WriteAccess.WriteLine(Player3Label.Text);
                        WriteAccess.WriteLine("\t" + Player3Score.Text);
                        if (Player3LivesCount != 1)
                        {
                            WriteAccess.WriteLine("\t" + Player3LivesCount + " Lives");
                        }
                        else
                        {
                            WriteAccess.WriteLine("\t" + Player3LivesCount + " Life");
                        }
                        WriteAccess.WriteLine();
                    }
                    if (NumberOfTeams == 4 || NumberOfTeams == 0)
                    {
                        WriteAccess.WriteLine(Player4Label.Text);
                        WriteAccess.WriteLine("\t" + Player4Score.Text);
                        if (Player4LivesCount != 1)
                        {
                            WriteAccess.WriteLine("\t" + Player4LivesCount + " Lives");
                        }
                        else
                        {
                            WriteAccess.WriteLine("\t" + Player4LivesCount + " Life");
                        }
                        WriteAccess.WriteLine();
                    }
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error writing to file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            WriteAccess.Close(); //Close read access to file
            updateGame();
        }
        public void ResetGame() //Called to clear all game data
        {
            if (File.Exists(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
            {
                AppendResults();
                if (!Directory.Exists(SCOREFILEDIRECTORY + "\\" + ARCHIVEDIRECTORY))
                {
                    Directory.CreateDirectory(SCOREFILEDIRECTORY + "\\" + ARCHIVEDIRECTORY);
                }
                DateTime GameStartTime = File.GetCreationTime(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME);
                string GameStartTimeString = GameStartTime.ToString();
                GameStartTimeString = GameStartTimeString.Replace("/", ".");
                GameStartTimeString = GameStartTimeString.Replace(":", "_");
                GameStartTimeString += " ";
                int duplicateFileNameCounter = 1;
                while (File.Exists(SCOREFILEDIRECTORY + "\\" + ARCHIVEDIRECTORY + "\\Robotag Game " + GameStartTimeString + ".txt"))
                {
                    GameStartTimeString = GameStartTimeString.TrimEnd(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
                    GameStartTimeString += duplicateFileNameCounter.ToString();
                    duplicateFileNameCounter++;
                }
                File.Move(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME, SCOREFILEDIRECTORY + "\\" + ARCHIVEDIRECTORY + "\\Robotag Game " + GameStartTimeString + ".txt");
            }
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
