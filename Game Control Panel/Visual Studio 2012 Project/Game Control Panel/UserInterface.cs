using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game_Control_Panel
{
    public partial class UserInterface : Form
    {
        private int NumberOfLives = 6;
        private int GameLength = 5; //measured in minutes
        private int NumberOfTeams = 0; //Valid values are 0, 2, 3, and 4
        private Timer gameTimer = new Timer();
        public const string STARTKEYWORD = "START GAME WITH LIVES: ";
        public const string RESUMEKEYWORD = "RESUME GAME";
        public const string ENDKEYWORD = "END GAME";
        Thread timerThread;
        Thread ScoreKeeperThread;

        public UserInterface()
        {
            InitializeComponent();
            ResetGame(); //Sets default game values
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            if (EStopButton.Enabled)//The game can be resumed when the EStop is enabled. The EStop is disabled when the game is in a fresh start
            {
                //Resume Game

                //Begin code to resume timer
                gameTimer.startTimer();
                if (timerThread.IsAlive)
                {
                    timerThread.Abort();
                }
                timerThread = new Thread(new ThreadStart(updateTimerLabel)); //Sets up a seperate thread
                timerThread.Name = "Timer Thread";
                timerThread.Start(); //Updates the timer in a sperate thread so other things can be done while the clock counts down
                //Ends code to resume timer

                //Begin code to resume scorekeeper
                if (ScoreKeeperThread.IsAlive)
                {
                    ScoreKeeperThread.Abort();
                }
                ScoreKeeperThread = new Thread(new ThreadStart(updateGameData));
                ScoreKeeperThread.Name = "ScoreKeeper Thread";
                ScoreKeeperThread.Start();
                //End code to resume scorekeeper

                //Begin changing Start/Stop button settings
                EStopButton.Enabled = true; //Enabling Emergency Stop button
                EStopButton.Text = "Emergency Stop";
                StartButton.Enabled = false; //Disabling Start button because while game is running you can not start another game.
                //End changing Start/Stop button settings

                //Starts code to write RESUMEKEYWORD
                WriteKeyword(RESUMEKEYWORD);
                //Ends code to write RESUMEKEYWORD
            }
            else
            {
                //Start New Game

                //Begins code to start timer
                gameTimer.setMinutes(GameLength);
                gameTimer.startTimer();
                timerThread = new Thread(new ThreadStart(updateTimerLabel)); //Sets up a seperate thread
                timerThread.Name = "Timer Thread";
                timerThread.Start(); //Updates the timer in a sperate thread so other things can be done while the clock counts down
                //Ends code to start timer


                //Begin disabling setting controls
                GameSettingsLabel.Enabled = false;
                NumberOfLivesLabel.Enabled = false;
                NumberOfLivesComboBox.Enabled = false;
                GameLengthLabel.Enabled = false;
                GameLengthComboBox.Enabled = false;
                IndividualGameRadioButton.Enabled = false;
                TeamGameRadioButton.Enabled = false;
                NumberOfLivesLabel.Enabled = false;
                NumberOfTeamsComboBox.Enabled = false;
                //End disabling setting controls

                //Begin changing Start/Stop button settings
                EStopButton.Enabled = true; //Enabling Emergency Stop button
                StartButton.Enabled = false; //Disabling Start button because while game is running you can not start another game.
                StartButton.Text = "Resume Game"; //Change Start button to Resume Button
                //End changing Start/Stop button settings

                //Begins code to start scorekeeper
                string message = "Robotag Game\n\n";
                message = message + "Game Started: " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString() + "\n";
                message = message + "Game settings:\n\t";
                if (NumberOfLives != 1)
                {
                    message = message + NumberOfLives + " Lives\n\t";
                }
                else
                {
                    message = message + NumberOfLives + " Life\n\t";
                }
                if (GameLength != 1) //To ensure gramatically correct output text this statement checks if the variable is singular or plural
                {
                    message = message + GameLength + " Minutes\n\t";
                }
                else
                {
                    message = message + GameLength + " Minute\n\t";
                }
                if (TeamGameRadioButton.Checked)
                {
                    message = message + "Team Game with " + NumberOfTeams + " teams";
                }
                else
                {
                    message = message + "Individual Game";
                }
                Scorekeeper.Enabled = true;
                Scorekeeper.StartGame(NumberOfLives, message); //Tells the scorekeeping object to start the game will a set number of lives
                ScoreKeeperThread = new Thread(new ThreadStart(updateGameData)); //Runs in seperate thread so that other controls can be used while the game file is scanned
                ScoreKeeperThread.Name = "ScoreKeeper Thread";
                ScoreKeeperThread.Start();
                //End code to start scorekeeper

                //Starts code to write STARTGAMEKEYWORD
                WriteKeyword(STARTKEYWORD + NumberOfLives.ToString());
                //Ends code to write STARTGAMEKEYWORD
            }
        }

        private void updateGameData()
        {
            DateTime FileLastAccessed=System.IO.File.GetCreationTime(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME);
            while (gameTimer.getTimerIsRunning())
            {
                if (DateTime.Compare(FileLastAccessed, System.IO.File.GetLastWriteTime(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME)) < 0 || !File.Exists(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME)) //Only scans the file if it has changed since it was last accessed. Will also run if the file goes missing
                {
                    if (Scorekeeper.InvokeRequired) //if the thread acessing the object is not the same as the thread that created the text label
                    {
                        Scorekeeper.Invoke((MethodInvoker)(() => Scorekeeper.updateGame())); //Runs this command as if it was running in the parent thread
                        //Invoke command referenced from http://tinyurl.com/m6nz8n8
                    }
                    else
                    {
                        Scorekeeper.updateGame();
                    }
                    FileLastAccessed = DateTime.Now; //Update the veriable to the current time that the file was accessed
                    if (Scorekeeper.OnePlayerRemaining()) //If only one player is alive the game should end.
                    {
                        WriteKeyword(ENDKEYWORD + " because only one player is remaining.");
                        //Then reload the file so that the GameScores textbox will show the ENDKEYWORD
                        if (Scorekeeper.InvokeRequired) //if the thread acessing the object is not the same as the thread that created the text label
                        {
                            Scorekeeper.Invoke((MethodInvoker)(() => Scorekeeper.updateGame())); //Runs this command as if it was running in the parent thread
                            //Invoke command referenced from http://tinyurl.com/m6nz8n8
                        }
                        else
                        {
                            Scorekeeper.updateGame();
                        }
                        timerThread.Abort(); //End the timer because the game is over. Must be manually stopped to prevent duplicate timer threads being created while one thread is in sleep mode.
                        gameTimer.stopTimer();
                        if (EStopButton.InvokeRequired)//if the thread acessing the button is not the same as the thread that created the text label
                        {
                            EStopButton.Invoke((MethodInvoker)(() => EStopButton.Text = "Reset Game")); //Runs this command as if it was running in the parent thread
                            //Invoke command referenced from http://tinyurl.com/m6nz8n8
                        }
                        else
                        {
                            EStopButton.Text = "Reset Game"; //Change E-Stop button to a reset game button.
                        }
                        break;
                    }
                }
                else
                {
                    Thread.Sleep(100);
                }
            }
        }

        private void updateTimerLabel()
        {
            gameTimer.updateLabel(TimerLabel);
            if (gameTimer.timerExpired()) //If the timer completed full time without being canceled prematurely.
            {
                if (EStopButton.InvokeRequired) //if the thread acessing the text label is not the same as the thread that created the text label
                {
                    EStopButton.Invoke((MethodInvoker)(() => EStopButton.Text = "Reset Game")); //Runs this command as if it was running in the parent thread
                    //Invoke command referenced from http://tinyurl.com/m6nz8n8
                }
                else
                {
                    EStopButton.Text = "Reset Game"; //Change E-Stop button to a reset game button.
                }
                ScoreKeeperThread.Abort(); //Manually abort this thread to prevent duplicate threads if a new thread is started while this thread is sleeping.
                WriteKeyword(ENDKEYWORD); //Signal to the web server that the game has ended.
                //Refresh the score results to show that the key word was written to the file.
                if (EStopButton.InvokeRequired) //if the thread acessing the text label is not the same as the thread that created the text label
                {
                    EStopButton.Invoke((MethodInvoker)(() => Scorekeeper.updateGame()));
                }
                else
                {
                    Scorekeeper.updateGame();
                }
            }
        }

        private void EStopButton_Click(object sender, EventArgs e)
        {
            if (StartButton.Enabled||gameTimer.timerExpired()||Scorekeeper.OnePlayerRemaining()) //If the start button is enabled then the game can be reset. The game can also be reset when the game is over (one player remaing or time expired).
            {
                ResetGame();
            }
            else //This is the Emergency Stop branch for if a game is stoped that is already in progress
            {
                gameTimer.stopTimer();
                timerThread.Abort();
                ScoreKeeperThread.Abort();
                StartButton.Enabled = true; //Reactivating the start/resume button
                EStopButton.Text = "Reset Game"; //Change E-Stop button to a reset game button.
                //Starts code to write ENDEKEYWORD
                WriteKeyword(ENDKEYWORD);
                Scorekeeper.updateGame(); //Refresh the game's score so that the end keyword is availible.
                //Ends code to write ENDKEYWORD
            }
        }

        private void ResetGame()
        {
            Scorekeeper.ResetGame();
            Scorekeeper.Enabled = false;
            NumberOfLivesComboBox.SelectedIndex = 5;
            GameLengthComboBox.SelectedIndex = 4;
            EStopButton.Enabled = false; //Disabled because while the game is running there is nothing to stop
            EStopButton.Text = "Emergency Stop"; //Changes text from Reset Game to Emergency Stop
            StartButton.Text = "Start"; //Changes text from Resume Game to Start
            gameTimer.ClearTimer();
            TimerLabel.Text = gameTimer.ToString();
            IndividualGameRadioButton.Checked = true;
            TeamGameRadioButton.Checked = false;

            //Begin enabling setting controls
            StartButton.Enabled = true;
            GameSettingsLabel.Enabled = true;
            NumberOfLivesLabel.Enabled = true;
            NumberOfLivesComboBox.Enabled = true;
            GameLengthLabel.Enabled = true;
            GameLengthComboBox.Enabled = true;
            IndividualGameRadioButton.Enabled = true;
            TeamGameRadioButton.Enabled = true;
            NumberOfLivesLabel.Enabled = true;
            NumberOfTeamsComboBox.Enabled = true;
            //End enabling setting controls
        }

        private void NumberOfLivesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            NumberOfLives = NumberOfLivesComboBox.SelectedIndex + 1; //adding 1 because we started counting from 1 instead of from 0
        }

        private void GameLengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GameLengthComboBox.SelectedIndex < 10) //The first 10 items count sequentally from 1-10
            {
                GameLength = GameLengthComboBox.SelectedIndex + 1; //adding 1 because we started counting from 1 instead of from 0
            }
            else
            {
                GameLength = (GameLengthComboBox.SelectedIndex - 7) * 5; //After item 10 the items count by fives from 15 to 60
            }
        }

        private void NumberOfTeamsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IndividualGameRadioButton.Checked)
            {
                NumberOfTeams = 0;
            }
            else
            {
                NumberOfTeams = NumberOfTeamsComboBox.SelectedIndex + 2; //adding 2 because we started counting from 2 instead of from 0

            }
            Scorekeeper.setNumberOfTeams(NumberOfTeams);
        }

        private void TeamRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TeamGameRadioButton.Checked)
            {
                NumberOfTeamsLabel.Visible = true;
                NumberOfTeamsComboBox.Visible = true;
                NumberOfTeamsComboBox.SelectedIndex = 0; //Sets the default number of teams as 2
            }
            else
            {
                NumberOfTeams = 0;
                NumberOfTeamsLabel.Visible = false;
                NumberOfTeamsComboBox.Visible = false;
            }
            NumberOfTeamsComboBox_SelectedIndexChanged(sender, e);//This function will also change the labels from Team to Player or Player to Team
        }

        private void WriteKeyword(string KEYWORD)
        {
            string FileText= null;
            StreamReader ReadAccess = null;
            StreamWriter WriteAccess = null;
            if (!Directory.Exists(ScoreControl.SCOREFILEDIRECTORY))
            {
                Directory.CreateDirectory(ScoreControl.SCOREFILEDIRECTORY);
            }
            if (!File.Exists(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME))
            {
                File.CreateText(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME).Close();
                try
                {
                    using (WriteAccess = new StreamWriter(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME))
                    {
                        WriteAccess.WriteLine("{0}\tERROR: {1} was not found and was replaced by a blank {1}", DateTime.Now.ToLongTimeString(), ScoreControl.SCOREFILENAME);
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
                using (ReadAccess = new StreamReader(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME))
                {
                    FileText=ReadAccess.ReadToEnd();
                    ReadAccess.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error reading from file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                using (WriteAccess = new StreamWriter(ScoreControl.SCOREFILEDIRECTORY + "\\" + ScoreControl.SCOREFILENAME))
                {
                    WriteAccess.Write(FileText);
                    if (FileText.ElementAt(FileText.Length-1) != '\n')
                    {
                        WriteAccess.WriteLine();
                    }
                    WriteAccess.WriteLine("{0}\t{1}", DateTime.Now.ToLongTimeString(), KEYWORD);
                    WriteAccess.Close();
                }
            }
            catch (IOException)
            {
                MessageBox.Show("Error writing to file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
