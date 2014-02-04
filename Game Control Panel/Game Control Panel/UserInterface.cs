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

namespace Game_Control_Panel
{
    public partial class UserInterface : Form
    {
        private int NumberOfLives = 5;
        private int GameLength = 5; //measured in minutes
        private Timer gameTimer = new Timer();
        public UserInterface()
        {
            InitializeComponent();
            NumberOfLivesComboBox.SelectedIndex = 4;
            GameLengthComboBox.SelectedIndex = 4;
        }
        private void StartButton_Click(object sender, EventArgs e)
        {
            //Begins code to start timer
            gameTimer.setMinutes(GameLength);
            gameTimer.startTimer();
            Thread timerThread = new Thread(new ThreadStart(updateLabel)); //Sets up a seperate thread
            timerThread.Start(); //Updates the timer in a sperate thread so other things can be done while the clock counts down
            //Ends code to start timer

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
                message = message + GameLength + " Minutes\n";
            }
            else
            {
                message = message + GameLength + " Minute\n";
            }
            MessageBox.Show(message, "Start");
            //Ends code to output message
        }

        private void updateLabel()
        {
            gameTimer.updateLabel(TimerLabel);
        }

        private void EStopButton_Click(object sender, EventArgs e)
        {
            gameTimer.stopTimer();
            MessageBox.Show("Game Aborted", "E-Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
    }
}
