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
using System.Diagnostics; //For Debug statement

//This class will read from the score file and keep track of score. The directories and files are defined by constant
//strings. The file interpreter is designed to look for line where the string PlayerX occurs twice. The X is a number.
//The first PlayerX is the player who fired their lazer blaster and the second is the player who recieved the hit.

namespace Game_Control_Panel
{
    public partial class ScoreControl : UserControl
    {
        private int numberOfLives = 6; //Number of lives in the game. Game default 6, but changed when the game starts Valid values 1-6 inclusive
        private int Player1ScoreValue = 0;
        private int Player2ScoreValue = 0;
        private int Player3ScoreValue = 0;
        private int Player4ScoreValue = 0;
        private int Player1LivesCount = 6; //Game default 6, but changed to numberOfLives value in updateGame()
        private int Player2LivesCount = 6; //Game default 6, but changed to numberOfLives value in updateGame()
        private int Player3LivesCount = 6; //Game default 6, but changed to numberOfLives value in updateGame()
        private int Player4LivesCount = 6; //Game default 6, but changed to numberOfLives value in updateGame()
        private const int HITBONUS = 100; //The number of points gained from a successful shot
        private const int DEATHDEDUCTION = 25; //The number of points lost from a player's death
        private int NumberOfTeams = 0; //Defualt value 0, but changed as user changes form settings Valid values are 0, 2, 3, and 4
        public const string SCOREFILEDIRECTORY = "c://Robotag";
        public const string SCOREFILENAME = "GameScores.txt";
        public const string ARCHIVEDIRECTORY = "Archives";
        StreamReader Stream = null;
        Regex expression = new Regex("Player\\d"); //Keyword scanning for is PlayerX where X is a number
        String fileText; //Used to store the contents of the file after reading in updating game or appending text to the file.
        //The next set of variables are used to append the output showing how many times each player has been shot each of their opponents.
        private int Player1ShotsFromPlayer2 = 0;
        private int Player1ShotsFromPlayer3 = 0;
        private int Player1ShotsFromPlayer4 = 0;
        private int Player2ShotsFromPlayer1 = 0;
        private int Player2ShotsFromPlayer3 = 0;
        private int Player2ShotsFromPlayer4 = 0;
        private int Player3ShotsFromPlayer1 = 0;
        private int Player3ShotsFromPlayer2 = 0;
        private int Player3ShotsFromPlayer4 = 0;
        private int Player4ShotsFromPlayer1 = 0;
        private int Player4ShotsFromPlayer2 = 0;
        private int Player4ShotsFromPlayer3 = 0;
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
            Debug.WriteLineIf(!(teams >= 0 && teams <= 4), "Attempt to set NumberOfTeams stopped because it is not in the valid range.");
            
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
                    for (int i = 0; i < MessageLines.Length; i++)
                    {
                        WriteAccess.WriteLine(MessageLines[i]); //Outputs game start header
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
            if (!Directory.Exists(SCOREFILEDIRECTORY))
            {
                Directory.CreateDirectory(SCOREFILEDIRECTORY);
            }
            if (!File.Exists(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
            {
                File.CreateText(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME).Close();
                StreamWriter WriteAccess = null;
                try
                {
                    using (WriteAccess = new StreamWriter(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
                    {
                        WriteAccess.WriteLine("{0}\tERROR: {1} was not found and was replaced by a blank {1}", DateTime.Now.ToLongTimeString(), SCOREFILENAME);
                        WriteAccess.Close();
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error writing to file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            string[] fileLines = fileText.Split('\n'); //Used for looking at each line individually
            Match hitData;
            int shootingPlayer;
            int playerHit;
            //Starts reading with the full values of the scores and lives
            Player1ScoreValue = 0;
            Player2ScoreValue = 0;
            Player3ScoreValue = 0;
            Player4ScoreValue = 0;
            Player1LivesCount = numberOfLives;
            Player2LivesCount = numberOfLives;
            Player3LivesCount = numberOfLives;
            Player4LivesCount = numberOfLives;
            Player1ShotsFromPlayer2 = 0;
            Player1ShotsFromPlayer3 = 0;
            Player1ShotsFromPlayer4 = 0;
            Player2ShotsFromPlayer1 = 0;
            Player2ShotsFromPlayer3 = 0;
            Player2ShotsFromPlayer4 = 0;
            Player3ShotsFromPlayer1 = 0;
            Player3ShotsFromPlayer2 = 0;
            Player3ShotsFromPlayer4 = 0;
            Player4ShotsFromPlayer1 = 0;
            Player4ShotsFromPlayer2 = 0;
            Player4ShotsFromPlayer3 = 0;
            for (int i = 0; i < fileLines.Length; i++)
			{
                if (expression.Matches(fileLines[i]).Count==2) //Each line with a hit should have two epressions of PlayerX
                {
                    hitData = expression.Match(fileLines[i]);
                    shootingPlayer = Convert.ToInt32(Regex.Match(hitData.ToString(), @"\d").ToString()); //Get the int form of the shooting player's Player number
                    hitData=hitData.NextMatch(); //The next match is the player who was hit
                    playerHit = Convert.ToInt32(Regex.Match(hitData.ToString(), @"\d").ToString());//Get the int form of the recieving player's Player number
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

            //Begins code to set all life indicators
            //This is mathimatically equivalent to (Player1LivesCount/numberOfLives)*100, but does not result in remainders
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
            //These switches and comparisons are made to adjust the score and lives as each hit is made.
            //These cases are made to ignore inaccurate records like:
            //      A player or team can not shoot another player if they are dead.
            //      A player or team can to be shot if they are dead.
            //      A player or team can not shoot themselves.
            //      A player or team can not have negative points.
            //      A player or team can not have negative lives.
            //A successful hit will increase the player's score by a constant HITBONUS
            //A death will result in a deduction of points based on a constant DEATHDEDUCTION, but the score can not go
            //negative.
            //
            //Warning! This function will only respond to valid values of player ID numbers (1-4 inclusive). Check the
            //validity of the numbers before calling this function.
            if (shootingPlayer != playerHit) //Ignore if a player hits themselves
            {
                switch (playerHit)
                {
                    case 1:
                        if (Player1ScoreValue > 0 + DEATHDEDUCTION && Player1LivesCount > 0) //If player is alive and has points to lose, deduct points
                        {
                            switch (shootingPlayer)
                            {
                                case 2:
                                    if (Player2LivesCount > 0) //Shooting player must be alive for the hit to count
                                    {
                                        Player1ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 3:
                                    if (Player3LivesCount > 0)
                                    {
                                        Player1ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 4:
                                    if (Player4LivesCount > 0)
                                    {
                                        Player1ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            //If the player has less points than DEATHDEDUCTION, then the score will go to zero to
                            //prevent negative scores.
                            switch (shootingPlayer)
                            {
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
                        if (Player1LivesCount > 0) //If shooting player is alive and player shot is alive, award points and deduct a life.
                        {
                            switch (shootingPlayer)
                            {
                                case 2:
                                    if (Player2LivesCount > 0)
                                    {
                                        Player1LivesCount--;
                                        Player2ScoreValue += HITBONUS;
                                        Player1ShotsFromPlayer2++;
                                    }
                                    break;
                                case 3:
                                    if (Player3LivesCount > 0)
                                    {
                                        Player1LivesCount--;
                                        Player3ScoreValue += HITBONUS;
                                        Player1ShotsFromPlayer3++;
                                    }
                                    break;
                                case 4:
                                    if (Player4LivesCount > 0)
                                    {
                                        Player1LivesCount--;
                                        Player4ScoreValue += HITBONUS;
                                        Player1ShotsFromPlayer4++;
                                    }
                                    break;
                            }
                        }
                        else
                        {
                            Player1LivesCount = 0; //If the number of lives is not greater than 0, it must be equal to 0.
                        }
                        break;
                    case 2:
                        if (Player2ScoreValue > 0 + DEATHDEDUCTION && Player2LivesCount > 0)
                        {
                            switch (shootingPlayer)
                            {
                                case 1:
                                    if (Player1LivesCount > 0)
                                    {
                                        Player2ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 3:
                                    if (Player3LivesCount > 0)
                                    {
                                        Player2ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 4:
                                    if (Player4LivesCount > 0)
                                    {
                                        Player2ScoreValue -= DEATHDEDUCTION;
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
                                        Player1ScoreValue += HITBONUS;
                                        Player2LivesCount--;
                                        Player2ShotsFromPlayer1++;
                                    }
                                    break;
                                case 3:
                                    if (Player3LivesCount > 0)
                                    {
                                        Player3ScoreValue += HITBONUS;
                                        Player2LivesCount--;
                                        Player2ShotsFromPlayer3++;
                                    }
                                    break;
                                case 4:
                                    if (Player4LivesCount > 0)
                                    {
                                        Player4ScoreValue += HITBONUS;
                                        Player2LivesCount--;
                                        Player2ShotsFromPlayer4++;
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
                        if (Player3ScoreValue > 0 + DEATHDEDUCTION && Player3LivesCount > 0)
                        {
                            switch (shootingPlayer)
                            {
                                case 1:
                                    if (Player1LivesCount > 0)
                                    {
                                        Player3ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 2:
                                    if (Player2LivesCount > 0)
                                    {
                                        Player3ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 4:
                                    if (Player4LivesCount > 0)
                                    {
                                        Player3ScoreValue -= DEATHDEDUCTION;
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
                                        Player1ScoreValue += HITBONUS;
                                        Player3LivesCount--;
                                        Player3ShotsFromPlayer1++;
                                    }
                                    break;
                                case 2:
                                    if (Player2LivesCount > 0)
                                    {
                                        Player2ScoreValue += HITBONUS;
                                        Player3LivesCount--;
                                        Player3ShotsFromPlayer2++;
                                    }
                                    break;
                                case 4:
                                    if (Player4LivesCount > 0)
                                    {
                                        Player4ScoreValue += HITBONUS;
                                        Player3LivesCount--;
                                        Player3ShotsFromPlayer4++;
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
                        if (Player4ScoreValue > 0 + DEATHDEDUCTION && Player4LivesCount > 0)
                        {
                            switch (shootingPlayer)
                            {
                                case 1:
                                    if (Player1LivesCount > 0)
                                    {
                                        Player4ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 2:
                                    if (Player2LivesCount > 0)
                                    {
                                        Player4ScoreValue -= DEATHDEDUCTION;
                                    }
                                    break;
                                case 3:
                                    if (Player3LivesCount > 0)
                                    {
                                        Player4ScoreValue -= DEATHDEDUCTION;
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
                            }
                        }
                        if (Player4LivesCount > 0)
                        {
                            switch (shootingPlayer)
                            {
                                case 1:
                                    if (Player1LivesCount > 0)
                                    {
                                        Player1ScoreValue += HITBONUS;
                                        Player4LivesCount--;
                                        Player4ShotsFromPlayer1++;
                                    }
                                    break;
                                case 2:
                                    if (Player2LivesCount > 0)
                                    {
                                        Player2ScoreValue += HITBONUS;
                                        Player4LivesCount--;
                                        Player4ShotsFromPlayer2++;
                                    }
                                    break;
                                case 3:
                                    if (Player3LivesCount > 0)
                                    {
                                        Player3ScoreValue += HITBONUS;
                                        Player4LivesCount--;
                                        Player4ShotsFromPlayer3++;
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
        }
        public void AppendResults() //Appends the game scores to the file
        {
            if (File.Exists(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
            {
                StreamWriter WriteAccess = null;
                StreamReader ReadAccess = null;
                try
                {
                    using (ReadAccess = new StreamReader(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME))
                    {
                        fileText = ReadAccess.ReadToEnd();
                        ReadAccess.Close();
                    }
                }
                catch (IOException)
                {
                    MessageBox.Show("Error reading from file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                try
                {
                    using (WriteAccess = new StreamWriter(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME))
                    {
                        WriteAccess.Write(fileText);
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
                        if (Player1ShotsFromPlayer2 > 0)
                        {
                            if (Player1ShotsFromPlayer2 == 1)
                            {
                                WriteAccess.WriteLine("\tShot by " + Player2Label.Text + " Once");
                            }
                            else
                            {
                                WriteAccess.WriteLine("\tShot by " + Player2Label.Text + ": " + Player1ShotsFromPlayer2 + " Times");
                            }
                        }
                        if (Player1ShotsFromPlayer3 > 0)
                        {
                            if (Player1ShotsFromPlayer3 == 1)
                            {
                                WriteAccess.WriteLine("\tShot by " + Player3Label.Text + " Once");
                            }
                            else
                            {
                                WriteAccess.WriteLine("\tShot by " + Player3Label.Text + ": " + Player1ShotsFromPlayer3 + " Times");
                            }
                        }
                        if (Player1ShotsFromPlayer4 > 0)
                        {
                            if (Player1ShotsFromPlayer4 == 1)
                            {
                                WriteAccess.WriteLine("\tShot by " + Player4Label.Text + " Once");
                            }
                            else
                            {
                                WriteAccess.WriteLine("\tShot by " + Player4Label.Text + ": " + Player1ShotsFromPlayer4 + " Times");
                            }
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
                        if (Player2ShotsFromPlayer1 > 0)
                        {
                            if (Player2ShotsFromPlayer1 == 1)
                            {
                                WriteAccess.WriteLine("\tShot by " + Player1Label.Text + " Once");
                            }
                            else
                            {
                                WriteAccess.WriteLine("\tShot by " + Player1Label.Text + ": " + Player2ShotsFromPlayer1 + " Times");
                            }
                        }
                        if (Player2ShotsFromPlayer3 > 0)
                        {
                            if (Player2ShotsFromPlayer3 == 1)
                            {
                                WriteAccess.WriteLine("\tShot by " + Player3Label.Text + " Once");
                            }
                            else
                            {
                                WriteAccess.WriteLine("\tShot by " + Player3Label.Text + ": " + Player2ShotsFromPlayer3 + " Times");
                            }
                        }
                        if (Player2ShotsFromPlayer4 > 0)
                        {
                            if (Player2ShotsFromPlayer4 == 1)
                            {
                                WriteAccess.WriteLine("\tShot by " + Player4Label.Text + " Once");
                            }
                            else
                            {
                                WriteAccess.WriteLine("\tShot by " + Player4Label.Text + ": " + Player2ShotsFromPlayer4 + " Times");
                            }
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
                            if (Player3ShotsFromPlayer1 > 0)
                            {
                                if (Player3ShotsFromPlayer1 == 1)
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player1Label.Text + " Once");
                                }
                                else
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player1Label.Text + ": " + Player3ShotsFromPlayer1 + " Times");
                                }
                            }
                            if (Player3ShotsFromPlayer2 > 0)
                            {
                                if (Player3ShotsFromPlayer2 == 1)
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player2Label.Text + " Once");
                                }
                                else
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player2Label.Text + ": " + Player3ShotsFromPlayer2 + " Times");
                                }
                            }
                            if (Player3ShotsFromPlayer4 > 0)
                            {
                                if (Player3ShotsFromPlayer4 == 1)
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player4Label.Text + " Once");
                                }
                                else
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player4Label.Text + ": " + Player3ShotsFromPlayer4 + " Times");
                                }
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
                            if (Player4ShotsFromPlayer1 > 0)
                            {
                                if (Player4ShotsFromPlayer1 == 1)
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player1Label.Text + " Once");
                                }
                                else
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player1Label.Text + ": " + Player4ShotsFromPlayer1 + " Times");
                                }
                            }
                            if (Player4ShotsFromPlayer2 > 0)
                            {
                                if (Player4ShotsFromPlayer2 == 1)
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player2Label.Text + " Once");
                                }
                                else
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player2Label.Text + ": " + Player4ShotsFromPlayer2 + " Times");
                                }
                            }
                            if (Player4ShotsFromPlayer3 > 0)
                            {
                                if (Player4ShotsFromPlayer3 == 1)
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player3Label.Text + " Once");
                                }
                                else
                                {
                                    WriteAccess.WriteLine("\tShot by " + Player3Label.Text + ": " + Player4ShotsFromPlayer3 + " Times");
                                }
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
            }
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
                {//If this filename is already in use, try appending a number to the end.
                    GameStartTimeString = GameStartTimeString.TrimEnd(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' });
                    GameStartTimeString += duplicateFileNameCounter.ToString();
                    duplicateFileNameCounter++;
                }
                File.Move(SCOREFILEDIRECTORY + "\\" + SCOREFILENAME, SCOREFILEDIRECTORY + "\\" + ARCHIVEDIRECTORY + "\\Robotag Game " + GameStartTimeString + ".txt");
            }
            //Reset to all default values
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
            Player1ShotsFromPlayer2 = 0;
            Player1ShotsFromPlayer3 = 0;
            Player1ShotsFromPlayer4 = 0;
            Player2ShotsFromPlayer1 = 0;
            Player2ShotsFromPlayer3 = 0;
            Player2ShotsFromPlayer4 = 0;
            Player3ShotsFromPlayer1 = 0;
            Player3ShotsFromPlayer2 = 0;
            Player3ShotsFromPlayer4 = 0;
            Player4ShotsFromPlayer1 = 0;
            Player4ShotsFromPlayer2 = 0;
            Player4ShotsFromPlayer3 = 0;
            GameScores.Text = "";
        }
    }
}
