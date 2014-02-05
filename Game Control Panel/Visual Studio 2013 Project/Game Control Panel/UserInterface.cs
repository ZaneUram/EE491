﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Control_Panel
{
    public partial class UserInterface : Form
    {
        private int NumberOfLives = 6;
        private int GameLength = 5; //measured in minutes
        private int NumberOfTeams = 0; //Valid values are 0, 2, 3, and 4
        private Timer gameTimer = new Timer();
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
                Thread timerThread = new Thread(new ThreadStart(updateTimerLabel)); //Sets up a seperate thread
                timerThread.Start(); //Updates the timer in a sperate thread so other things can be done while the clock counts down
                //Ends code to resume timer

                EStopButton.Enabled = true; //Enabling Emergency Stop button
                EStopButton.Text = "Emergency Stop";
                StartButton.Enabled = false; //Disabling Start button because while game is running you can not start another game.


                MessageBox.Show("Resuming Game", "Resume");
            }
            else
            {
                //Start New Game

                //Begins code to start timer
                gameTimer.setMinutes(GameLength);
                gameTimer.startTimer();
                Thread timerThread = new Thread(new ThreadStart(updateTimerLabel)); //Sets up a seperate thread
                timerThread.Start(); //Updates the timer in a sperate thread so other things can be done while the clock counts down
                //Ends code to start timer

                //Begin disabling setting controls
                NumberOfLivesLabel.Enabled = false;
                NumberOfLivesComboBox.Enabled = false;
                GameLengthLabel.Enabled = false;
                GameLengthComboBox.Enabled = false;
                IndividualGameRadioButton.Enabled = false;
                TeamGameRadioButton.Enabled = false;
                NumberOfLivesLabel.Enabled = false;
                NumberOfTeamsComboBox.Enabled = false;
                //End disabling setting controls

                EStopButton.Enabled = true; //Enabling Emergency Stop button
                StartButton.Enabled = false; //Disabling Start button because while game is running you can not start another game.
                StartButton.Text = "Resume Game"; //Change Start button to Resume Button

                //Begins code to set all life indicators
                Player1Lives.Value = 100;
                Player2Lives.Value = 100;
                Player3Lives.Value = 100;
                Player4Lives.Value = 100;
                //Ends code to set all life indicators

                //Begins code to output message
                string message = "Game Started " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString() + "\n";
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
                    message = message + "Team Game with " + NumberOfTeams + " teams\n";
                }
                else
                {
                    message = message + "Individual Game\n";
                }
                GameScores.Text = message; //This will be implimented differently once the scoring object is complete
                MessageBox.Show(message, "Start");
                //Ends code to output message
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
                MessageBox.Show("Game Ended", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void EStopButton_Click(object sender, EventArgs e)
        {
            if (StartButton.Enabled||gameTimer.timerExpired()) //If the start button is enabled then the game can be reset
            {
                ResetGame();
            }
            else //This is the Emergency Stop branch for if a game is stoped that is already in progress
            {
                gameTimer.stopTimer();
                StartButton.Enabled = true; //Reactivating the start/resume button
                EStopButton.Text = "Reset Game"; //Change E-Stop button to a reset game button.
                MessageBox.Show("Game Aborted", "E-Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ResetGame()
        {
            GameScores.Text = "";
            NumberOfLivesComboBox.SelectedIndex = 5;
            GameLengthComboBox.SelectedIndex = 4;
            EStopButton.Enabled = false; //Disabled because while the game is running there is nothing to stop
            EStopButton.Text = "Emergency Stop"; //Changes text from Reset Game to Emergency Stop
            StartButton.Text = "Start"; //Changes text from Resume Game to Start
            Player1Lives.Value = 0;
            Player2Lives.Value = 0;
            Player3Lives.Value = 0;
            Player4Lives.Value = 0;
            gameTimer.ClearTimer();
            TimerLabel.Text = gameTimer.ToString();
            IndividualGameRadioButton.Checked = true;
            TeamGameRadioButton.Checked = false;

            //Begin enabling setting controls
            StartButton.Enabled = true;
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
                   break;
                case 3:
                   //Players 1 and 2 are not forced to a visible state because they are never hidden
                   Player3Label.Visible = true;
                   Player3Lives.Visible = true;
                   Player3Score.Visible = true;
                   Player4Label.Visible = false;
                   Player4Lives.Visible = false;
                   Player4Score.Visible = false;
                   break;
                default:
                case 4:
                   //Players 1 and 2 are not forced to a visible state because they are never hidden
                   Player3Label.Visible = true;
                   Player3Lives.Visible = true;
                   Player3Score.Visible = true;
                   Player4Label.Visible = true;
                   Player4Lives.Visible = true;
                   Player4Score.Visible = true;
                   break;

            }
        }

        private void TeamRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (TeamGameRadioButton.Checked)
            {
                NumberOfTeamsLabel.Visible = true;
                NumberOfTeamsComboBox.Visible = true;
                Player1Label.Text = "Team 1";
                Player2Label.Text = "Team 2";
                Player3Label.Text = "Team 3";
                Player4Label.Text = "Team 4";
                NumberOfTeamsComboBox.SelectedIndex = 0; //Sets the default number of teams as 2
            }
            else
            {
                NumberOfTeams = 0;
                NumberOfTeamsLabel.Visible = false;
                NumberOfTeamsComboBox.Visible = false;
                Player1Label.Text = "Player 1";
                Player2Label.Text = "Player 2";
                Player3Label.Text = "Player 3";
                Player4Label.Text = "Player 4";
            }
            NumberOfTeamsComboBox_SelectedIndexChanged(sender, e);//
        }
    }
}