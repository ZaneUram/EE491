using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
            gameTimer.setMinutes(GameLength);
            TimerLabel.Text=gameTimer.ToString();
        }

        private void EStopButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Game Aborted", "E-Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void NumberOfLivesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NumberOfLivesComboBox.SelectedIndex < 10) //The first 10 items count sequentally from 1-10
            {
                NumberOfLives = NumberOfLivesComboBox.SelectedIndex + 1; //adding 1 because we started counting from 1 instead of from 0
            }
            else
            {
                NumberOfLives = (NumberOfLivesComboBox.SelectedIndex-7)*5; //After item 10 the items count by fives from 15 to 60
            }
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
