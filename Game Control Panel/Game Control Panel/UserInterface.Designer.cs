namespace Game_Control_Panel
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameSettingsLabel = new System.Windows.Forms.Label();
            this.NumberOfLivesLabel = new System.Windows.Forms.Label();
            this.NumberOfLivesComboBox = new System.Windows.Forms.ComboBox();
            this.GameLengthLabel = new System.Windows.Forms.Label();
            this.GameLengthComboBox = new System.Windows.Forms.ComboBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.EStopButton = new System.Windows.Forms.Button();
            this.TimeRemainingLabel = new System.Windows.Forms.Label();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.GameScoresLabel = new System.Windows.Forms.Label();
            this.Player1ScoreLabel = new System.Windows.Forms.Label();
            this.Player1Score = new System.Windows.Forms.Label();
            this.Player2Score = new System.Windows.Forms.Label();
            this.Player2ScoreLabel = new System.Windows.Forms.Label();
            this.Player3Score = new System.Windows.Forms.Label();
            this.Player3ScoreLabel = new System.Windows.Forms.Label();
            this.Player4Score = new System.Windows.Forms.Label();
            this.Player4ScoreLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // GameSettingsLabel
            // 
            this.GameSettingsLabel.AutoSize = true;
            this.GameSettingsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameSettingsLabel.Location = new System.Drawing.Point(12, 9);
            this.GameSettingsLabel.Name = "GameSettingsLabel";
            this.GameSettingsLabel.Size = new System.Drawing.Size(157, 26);
            this.GameSettingsLabel.TabIndex = 0;
            this.GameSettingsLabel.Text = "Game Settings";
            // 
            // NumberOfLivesLabel
            // 
            this.NumberOfLivesLabel.AutoSize = true;
            this.NumberOfLivesLabel.Location = new System.Drawing.Point(35, 35);
            this.NumberOfLivesLabel.Name = "NumberOfLivesLabel";
            this.NumberOfLivesLabel.Size = new System.Drawing.Size(84, 13);
            this.NumberOfLivesLabel.TabIndex = 1;
            this.NumberOfLivesLabel.Text = "Number of Lives";
            // 
            // NumberOfLivesComboBox
            // 
            this.NumberOfLivesComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.NumberOfLivesComboBox.FormattingEnabled = true;
            this.NumberOfLivesComboBox.Items.AddRange(new object[] {
            "1 Life",
            "2 Lives",
            "3 Lives",
            "4 Lives",
            "5 Lives",
            "6 Lives",
            "7 Lives",
            "8 Lives",
            "9 Lives",
            "10 Lives",
            "15 Lives",
            "20 Lives",
            "25 Lives",
            "30 Lives",
            "35 Lives",
            "40 Lives",
            "45 Lives",
            "50 Lives",
            "55 Lives",
            "60 Lives"});
            this.NumberOfLivesComboBox.Location = new System.Drawing.Point(38, 51);
            this.NumberOfLivesComboBox.Name = "NumberOfLivesComboBox";
            this.NumberOfLivesComboBox.Size = new System.Drawing.Size(300, 21);
            this.NumberOfLivesComboBox.TabIndex = 2;
            this.NumberOfLivesComboBox.SelectedIndexChanged += new System.EventHandler(this.NumberOfLivesComboBox_SelectedIndexChanged);
            // 
            // GameLengthLabel
            // 
            this.GameLengthLabel.AutoSize = true;
            this.GameLengthLabel.Location = new System.Drawing.Point(35, 75);
            this.GameLengthLabel.Name = "GameLengthLabel";
            this.GameLengthLabel.Size = new System.Drawing.Size(71, 13);
            this.GameLengthLabel.TabIndex = 3;
            this.GameLengthLabel.Text = "Game Length";
            // 
            // GameLengthComboBox
            // 
            this.GameLengthComboBox.FormattingEnabled = true;
            this.GameLengthComboBox.Items.AddRange(new object[] {
            "1 Minute",
            "2 Minutes",
            "3 Minutes",
            "4 Minutes",
            "5 Minutes",
            "6 Minutes",
            "7 Minutes",
            "8 Minutes",
            "9 Minutes",
            "10 Minutes",
            "15 Minutes",
            "20 Minutes",
            "25 Minutes",
            "30 Minutes",
            "35 Minutes",
            "40 Minutes",
            "45 Minutes",
            "50 Minutes",
            "55 Minutes",
            "60 Minutes"});
            this.GameLengthComboBox.Location = new System.Drawing.Point(38, 91);
            this.GameLengthComboBox.Name = "GameLengthComboBox";
            this.GameLengthComboBox.Size = new System.Drawing.Size(300, 21);
            this.GameLengthComboBox.TabIndex = 4;
            this.GameLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.GameLengthComboBox_SelectedIndexChanged);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(17, 138);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(150, 150);
            this.StartButton.TabIndex = 5;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // EStopButton
            // 
            this.EStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EStopButton.Location = new System.Drawing.Point(188, 138);
            this.EStopButton.Name = "EStopButton";
            this.EStopButton.Size = new System.Drawing.Size(150, 150);
            this.EStopButton.TabIndex = 6;
            this.EStopButton.Text = "E-Stop";
            this.EStopButton.UseVisualStyleBackColor = true;
            this.EStopButton.Click += new System.EventHandler(this.EStopButton_Click);
            // 
            // TimeRemainingLabel
            // 
            this.TimeRemainingLabel.AutoSize = true;
            this.TimeRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeRemainingLabel.Location = new System.Drawing.Point(12, 331);
            this.TimeRemainingLabel.Name = "TimeRemainingLabel";
            this.TimeRemainingLabel.Size = new System.Drawing.Size(171, 26);
            this.TimeRemainingLabel.TabIndex = 7;
            this.TimeRemainingLabel.Text = "Time Remaining";
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(28, 357);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(284, 73);
            this.TimerLabel.TabIndex = 8;
            this.TimerLabel.Text = "00:00:00";
            // 
            // GameScoresLabel
            // 
            this.GameScoresLabel.AutoSize = true;
            this.GameScoresLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameScoresLabel.Location = new System.Drawing.Point(358, 9);
            this.GameScoresLabel.Name = "GameScoresLabel";
            this.GameScoresLabel.Size = new System.Drawing.Size(146, 26);
            this.GameScoresLabel.TabIndex = 9;
            this.GameScoresLabel.Text = "Game Scores";
            // 
            // Player1ScoreLabel
            // 
            this.Player1ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player1ScoreLabel.AutoSize = true;
            this.Player1ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1ScoreLabel.Location = new System.Drawing.Point(372, 331);
            this.Player1ScoreLabel.Name = "Player1ScoreLabel";
            this.Player1ScoreLabel.Size = new System.Drawing.Size(92, 26);
            this.Player1ScoreLabel.TabIndex = 11;
            this.Player1ScoreLabel.Text = "Player 1";
            // 
            // Player1Score
            // 
            this.Player1Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player1Score.AutoSize = true;
            this.Player1Score.Location = new System.Drawing.Point(388, 357);
            this.Player1Score.Name = "Player1Score";
            this.Player1Score.Size = new System.Drawing.Size(45, 13);
            this.Player1Score.TabIndex = 12;
            this.Player1Score.Text = "0 Points";
            // 
            // Player2Score
            // 
            this.Player2Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2Score.AutoSize = true;
            this.Player2Score.Location = new System.Drawing.Point(536, 357);
            this.Player2Score.Name = "Player2Score";
            this.Player2Score.Size = new System.Drawing.Size(45, 13);
            this.Player2Score.TabIndex = 14;
            this.Player2Score.Text = "0 Points";
            // 
            // Player2ScoreLabel
            // 
            this.Player2ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Player2ScoreLabel.AutoSize = true;
            this.Player2ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2ScoreLabel.Location = new System.Drawing.Point(520, 331);
            this.Player2ScoreLabel.Name = "Player2ScoreLabel";
            this.Player2ScoreLabel.Size = new System.Drawing.Size(92, 26);
            this.Player2ScoreLabel.TabIndex = 13;
            this.Player2ScoreLabel.Text = "Player 2";
            // 
            // Player3Score
            // 
            this.Player3Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player3Score.AutoSize = true;
            this.Player3Score.Location = new System.Drawing.Point(388, 407);
            this.Player3Score.Name = "Player3Score";
            this.Player3Score.Size = new System.Drawing.Size(45, 13);
            this.Player3Score.TabIndex = 16;
            this.Player3Score.Text = "0 Points";
            // 
            // Player3ScoreLabel
            // 
            this.Player3ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Player3ScoreLabel.AutoSize = true;
            this.Player3ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3ScoreLabel.Location = new System.Drawing.Point(372, 381);
            this.Player3ScoreLabel.Name = "Player3ScoreLabel";
            this.Player3ScoreLabel.Size = new System.Drawing.Size(92, 26);
            this.Player3ScoreLabel.TabIndex = 15;
            this.Player3ScoreLabel.Text = "Player 3";
            // 
            // Player4Score
            // 
            this.Player4Score.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Player4Score.AutoSize = true;
            this.Player4Score.Location = new System.Drawing.Point(536, 407);
            this.Player4Score.Name = "Player4Score";
            this.Player4Score.Size = new System.Drawing.Size(45, 13);
            this.Player4Score.TabIndex = 18;
            this.Player4Score.Text = "0 Points";
            // 
            // Player4ScoreLabel
            // 
            this.Player4ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Player4ScoreLabel.AutoSize = true;
            this.Player4ScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4ScoreLabel.Location = new System.Drawing.Point(520, 381);
            this.Player4ScoreLabel.Name = "Player4ScoreLabel";
            this.Player4ScoreLabel.Size = new System.Drawing.Size(92, 26);
            this.Player4ScoreLabel.TabIndex = 17;
            this.Player4ScoreLabel.Text = "Player 4";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(377, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(235, 250);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Example text of what will appear here when the file changes:\n\n00:00:00.00 Player1" +
    " hit Player4\n00:00:00.00 Player1 hit Player4";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Player4Score);
            this.Controls.Add(this.Player4ScoreLabel);
            this.Controls.Add(this.Player3Score);
            this.Controls.Add(this.Player3ScoreLabel);
            this.Controls.Add(this.Player2Score);
            this.Controls.Add(this.Player2ScoreLabel);
            this.Controls.Add(this.Player1Score);
            this.Controls.Add(this.Player1ScoreLabel);
            this.Controls.Add(this.GameScoresLabel);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.TimeRemainingLabel);
            this.Controls.Add(this.EStopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.GameLengthComboBox);
            this.Controls.Add(this.GameLengthLabel);
            this.Controls.Add(this.NumberOfLivesComboBox);
            this.Controls.Add(this.NumberOfLivesLabel);
            this.Controls.Add(this.GameSettingsLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "UserInterface";
            this.Text = "RoboTag Game Control Panel";
            this.TransparencyKey = System.Drawing.Color.LightPink;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameSettingsLabel;
        private System.Windows.Forms.Label NumberOfLivesLabel;
        private System.Windows.Forms.ComboBox NumberOfLivesComboBox;
        private System.Windows.Forms.Label GameLengthLabel;
        private System.Windows.Forms.ComboBox GameLengthComboBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button EStopButton;
        private System.Windows.Forms.Label TimeRemainingLabel;
        private System.Windows.Forms.Label GameScoresLabel;
        private System.Windows.Forms.Label Player1ScoreLabel;
        private System.Windows.Forms.Label Player1Score;
        private System.Windows.Forms.Label Player2Score;
        private System.Windows.Forms.Label Player2ScoreLabel;
        private System.Windows.Forms.Label Player3Score;
        private System.Windows.Forms.Label Player3ScoreLabel;
        private System.Windows.Forms.Label Player4Score;
        private System.Windows.Forms.Label Player4ScoreLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Label TimerLabel;
    }
}

