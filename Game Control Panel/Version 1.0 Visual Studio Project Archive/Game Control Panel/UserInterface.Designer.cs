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
            this.IndividualGameRadioButton = new System.Windows.Forms.RadioButton();
            this.TeamGameRadioButton = new System.Windows.Forms.RadioButton();
            this.NumberOfTeamsLabel = new System.Windows.Forms.Label();
            this.NumberOfTeamsComboBox = new System.Windows.Forms.ComboBox();
            this.Scorekeeper = new Game_Control_Panel.ScoreControl();
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
            this.NumberOfLivesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberOfLivesComboBox.FormattingEnabled = true;
            this.NumberOfLivesComboBox.Items.AddRange(new object[] {
            "1 Life",
            "2 Lives",
            "3 Lives",
            "4 Lives",
            "5 Lives",
            "6 Lives"});
            this.NumberOfLivesComboBox.Location = new System.Drawing.Point(38, 51);
            this.NumberOfLivesComboBox.Name = "NumberOfLivesComboBox";
            this.NumberOfLivesComboBox.Size = new System.Drawing.Size(129, 21);
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
            this.GameLengthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
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
            this.GameLengthComboBox.Size = new System.Drawing.Size(129, 21);
            this.GameLengthComboBox.TabIndex = 4;
            this.GameLengthComboBox.SelectedIndexChanged += new System.EventHandler(this.GameLengthComboBox_SelectedIndexChanged);
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(17, 138);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(150, 150);
            this.StartButton.TabIndex = 0;
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
            this.EStopButton.TabIndex = 11;
            this.EStopButton.Text = "Emergency Stop";
            this.EStopButton.UseVisualStyleBackColor = true;
            this.EStopButton.Click += new System.EventHandler(this.EStopButton_Click);
            // 
            // TimeRemainingLabel
            // 
            this.TimeRemainingLabel.AutoSize = true;
            this.TimeRemainingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeRemainingLabel.Location = new System.Drawing.Point(12, 317);
            this.TimeRemainingLabel.Name = "TimeRemainingLabel";
            this.TimeRemainingLabel.Size = new System.Drawing.Size(171, 26);
            this.TimeRemainingLabel.TabIndex = 12;
            this.TimeRemainingLabel.Text = "Time Remaining";
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimerLabel.Location = new System.Drawing.Point(12, 342);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(347, 91);
            this.TimerLabel.TabIndex = 13;
            this.TimerLabel.Text = "00:00:00";
            // 
            // IndividualGameRadioButton
            // 
            this.IndividualGameRadioButton.AutoSize = true;
            this.IndividualGameRadioButton.Checked = true;
            this.IndividualGameRadioButton.Location = new System.Drawing.Point(188, 33);
            this.IndividualGameRadioButton.Name = "IndividualGameRadioButton";
            this.IndividualGameRadioButton.Size = new System.Drawing.Size(101, 17);
            this.IndividualGameRadioButton.TabIndex = 6;
            this.IndividualGameRadioButton.TabStop = true;
            this.IndividualGameRadioButton.Text = "Individual Game";
            this.IndividualGameRadioButton.UseVisualStyleBackColor = true;
            this.IndividualGameRadioButton.CheckedChanged += new System.EventHandler(this.TeamRadioButton_CheckedChanged);
            // 
            // TeamGameRadioButton
            // 
            this.TeamGameRadioButton.AutoSize = true;
            this.TeamGameRadioButton.Location = new System.Drawing.Point(188, 52);
            this.TeamGameRadioButton.Name = "TeamGameRadioButton";
            this.TeamGameRadioButton.Size = new System.Drawing.Size(83, 17);
            this.TeamGameRadioButton.TabIndex = 7;
            this.TeamGameRadioButton.Text = "Team Game";
            this.TeamGameRadioButton.UseVisualStyleBackColor = true;
            // 
            // NumberOfTeamsLabel
            // 
            this.NumberOfTeamsLabel.AutoSize = true;
            this.NumberOfTeamsLabel.Location = new System.Drawing.Point(183, 75);
            this.NumberOfTeamsLabel.Name = "NumberOfTeamsLabel";
            this.NumberOfTeamsLabel.Size = new System.Drawing.Size(91, 13);
            this.NumberOfTeamsLabel.TabIndex = 8;
            this.NumberOfTeamsLabel.Text = "Number of Teams";
            this.NumberOfTeamsLabel.Visible = false;
            // 
            // NumberOfTeamsComboBox
            // 
            this.NumberOfTeamsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NumberOfTeamsComboBox.FormattingEnabled = true;
            this.NumberOfTeamsComboBox.Items.AddRange(new object[] {
            "2 Teams",
            "3 Teams",
            "4 Teams"});
            this.NumberOfTeamsComboBox.Location = new System.Drawing.Point(186, 91);
            this.NumberOfTeamsComboBox.Name = "NumberOfTeamsComboBox";
            this.NumberOfTeamsComboBox.Size = new System.Drawing.Size(129, 21);
            this.NumberOfTeamsComboBox.TabIndex = 9;
            this.NumberOfTeamsComboBox.Visible = false;
            this.NumberOfTeamsComboBox.SelectedIndexChanged += new System.EventHandler(this.NumberOfTeamsComboBox_SelectedIndexChanged);
            // 
            // Scorekeeper
            // 
            this.Scorekeeper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Scorekeeper.Location = new System.Drawing.Point(350, 0);
            this.Scorekeeper.Name = "Scorekeeper";
            this.Scorekeeper.Size = new System.Drawing.Size(275, 450);
            this.Scorekeeper.TabIndex = 14;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.Scorekeeper);
            this.Controls.Add(this.NumberOfTeamsComboBox);
            this.Controls.Add(this.NumberOfTeamsLabel);
            this.Controls.Add(this.TeamGameRadioButton);
            this.Controls.Add(this.IndividualGameRadioButton);
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
        private System.Windows.Forms.Label GameLengthLabel;
        private System.Windows.Forms.ComboBox GameLengthComboBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button EStopButton;
        private System.Windows.Forms.Label TimeRemainingLabel;
        public System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.RadioButton IndividualGameRadioButton;
        private System.Windows.Forms.RadioButton TeamGameRadioButton;
        private System.Windows.Forms.Label NumberOfTeamsLabel;
        private System.Windows.Forms.ComboBox NumberOfTeamsComboBox;
        private System.Windows.Forms.ComboBox NumberOfLivesComboBox;
        private ScoreControl Scorekeeper;
    }
}

