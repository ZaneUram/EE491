namespace Game_Control_Panel
{
    partial class Form1
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
<<<<<<< HEAD
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Text = "Form1";
        }

        #endregion
=======
            this.GameLengthLabel = new System.Windows.Forms.Label();
            this.GameLengthComboBox = new System.Windows.Forms.ComboBox();
            this.LivesPerPlayerLabel = new System.Windows.Forms.Label();
            this.LivesPerPlayerComboBox = new System.Windows.Forms.ComboBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.EStopButton = new System.Windows.Forms.Button();
            this.TimeRemainingInGameLabel = new System.Windows.Forms.Label();
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.GameScoresTitleLabel = new System.Windows.Forms.Label();
            this.Player1Label = new System.Windows.Forms.Label();
            this.Player2Label = new System.Windows.Forms.Label();
            this.Player1Points = new System.Windows.Forms.Label();
            this.Player2Points = new System.Windows.Forms.Label();
            this.Player3Label = new System.Windows.Forms.Label();
            this.Player4Label = new System.Windows.Forms.Label();
            this.Player3Points = new System.Windows.Forms.Label();
            this.Player4Points = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // GameLengthLabel
            // 
            this.GameLengthLabel.AutoSize = true;
            this.GameLengthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameLengthLabel.Location = new System.Drawing.Point(12, 9);
            this.GameLengthLabel.Name = "GameLengthLabel";
            this.GameLengthLabel.Size = new System.Drawing.Size(111, 20);
            this.GameLengthLabel.TabIndex = 0;
            this.GameLengthLabel.Text = "Game Length:";
            // 
            // GameLengthComboBox
            // 
            this.GameLengthComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameLengthComboBox.FormattingEnabled = true;
            this.GameLengthComboBox.Items.AddRange(new object[] {
            "1 Minutes",
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
            this.GameLengthComboBox.Location = new System.Drawing.Point(16, 32);
            this.GameLengthComboBox.Name = "GameLengthComboBox";
            this.GameLengthComboBox.Size = new System.Drawing.Size(317, 28);
            this.GameLengthComboBox.TabIndex = 1;
            // 
            // LivesPerPlayerLabel
            // 
            this.LivesPerPlayerLabel.AutoSize = true;
            this.LivesPerPlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LivesPerPlayerLabel.Location = new System.Drawing.Point(12, 75);
            this.LivesPerPlayerLabel.Name = "LivesPerPlayerLabel";
            this.LivesPerPlayerLabel.Size = new System.Drawing.Size(124, 20);
            this.LivesPerPlayerLabel.TabIndex = 2;
            this.LivesPerPlayerLabel.Text = "Lives Per Player:";
            // 
            // LivesPerPlayerComboBox
            // 
            this.LivesPerPlayerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LivesPerPlayerComboBox.FormattingEnabled = true;
            this.LivesPerPlayerComboBox.Items.AddRange(new object[] {
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
            "60 Lives",
            "70 Lives",
            "80 Lives",
            "85 Lives",
            "90 Lives",
            "95 Lives",
            "100 Lives"});
            this.LivesPerPlayerComboBox.Location = new System.Drawing.Point(16, 98);
            this.LivesPerPlayerComboBox.Name = "LivesPerPlayerComboBox";
            this.LivesPerPlayerComboBox.Size = new System.Drawing.Size(317, 28);
            this.LivesPerPlayerComboBox.TabIndex = 3;
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(19, 144);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 100);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // EStopButton
            // 
            this.EStopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EStopButton.Location = new System.Drawing.Point(153, 144);
            this.EStopButton.Name = "EStopButton";
            this.EStopButton.Size = new System.Drawing.Size(100, 100);
            this.EStopButton.TabIndex = 5;
            this.EStopButton.Text = "E-Stop";
            this.EStopButton.UseVisualStyleBackColor = true;
            this.EStopButton.Click += new System.EventHandler(this.EStopButton_Click);
            // 
            // TimeRemainingInGameLabel
            // 
            this.TimeRemainingInGameLabel.AutoSize = true;
            this.TimeRemainingInGameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeRemainingInGameLabel.Location = new System.Drawing.Point(12, 259);
            this.TimeRemainingInGameLabel.Name = "TimeRemainingInGameLabel";
            this.TimeRemainingInGameLabel.Size = new System.Drawing.Size(191, 20);
            this.TimeRemainingInGameLabel.TabIndex = 6;
            this.TimeRemainingInGameLabel.Text = "Time Remaining in Game:";
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.AutoSize = true;
            this.CountdownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CountdownLabel.Location = new System.Drawing.Point(12, 279);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(374, 73);
            this.CountdownLabel.TabIndex = 7;
            this.CountdownLabel.Text = "00:00:00.00";
            // 
            // GameScoresTitleLabel
            // 
            this.GameScoresTitleLabel.AutoSize = true;
            this.GameScoresTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameScoresTitleLabel.Location = new System.Drawing.Point(15, 352);
            this.GameScoresTitleLabel.Name = "GameScoresTitleLabel";
            this.GameScoresTitleLabel.Size = new System.Drawing.Size(111, 20);
            this.GameScoresTitleLabel.TabIndex = 8;
            this.GameScoresTitleLabel.Text = "Game Scores:";
            // 
            // Player1Label
            // 
            this.Player1Label.AutoSize = true;
            this.Player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Label.Location = new System.Drawing.Point(21, 372);
            this.Player1Label.Name = "Player1Label";
            this.Player1Label.Size = new System.Drawing.Size(69, 20);
            this.Player1Label.TabIndex = 9;
            this.Player1Label.Text = "Player 1:";
            // 
            // Player2Label
            // 
            this.Player2Label.AutoSize = true;
            this.Player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Label.Location = new System.Drawing.Point(21, 392);
            this.Player2Label.Name = "Player2Label";
            this.Player2Label.Size = new System.Drawing.Size(69, 20);
            this.Player2Label.TabIndex = 10;
            this.Player2Label.Text = "Player 2:";
            // 
            // Player1Points
            // 
            this.Player1Points.AutoSize = true;
            this.Player1Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1Points.Location = new System.Drawing.Point(92, 372);
            this.Player1Points.Name = "Player1Points";
            this.Player1Points.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Player1Points.Size = new System.Drawing.Size(66, 20);
            this.Player1Points.TabIndex = 11;
            this.Player1Points.Text = "0 Points";
            // 
            // Player2Points
            // 
            this.Player2Points.AutoSize = true;
            this.Player2Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2Points.Location = new System.Drawing.Point(92, 392);
            this.Player2Points.Name = "Player2Points";
            this.Player2Points.Size = new System.Drawing.Size(66, 20);
            this.Player2Points.TabIndex = 12;
            this.Player2Points.Text = "0 Points";
            // 
            // Player3Label
            // 
            this.Player3Label.AutoSize = true;
            this.Player3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3Label.Location = new System.Drawing.Point(209, 372);
            this.Player3Label.Name = "Player3Label";
            this.Player3Label.Size = new System.Drawing.Size(69, 20);
            this.Player3Label.TabIndex = 13;
            this.Player3Label.Text = "Player 3:";
            // 
            // Player4Label
            // 
            this.Player4Label.AutoSize = true;
            this.Player4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4Label.Location = new System.Drawing.Point(209, 392);
            this.Player4Label.Name = "Player4Label";
            this.Player4Label.Size = new System.Drawing.Size(69, 20);
            this.Player4Label.TabIndex = 14;
            this.Player4Label.Text = "Player 4:";
            // 
            // Player3Points
            // 
            this.Player3Points.AutoSize = true;
            this.Player3Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player3Points.Location = new System.Drawing.Point(280, 372);
            this.Player3Points.Name = "Player3Points";
            this.Player3Points.Size = new System.Drawing.Size(66, 20);
            this.Player3Points.TabIndex = 15;
            this.Player3Points.Text = "0 Points";
            // 
            // Player4Points
            // 
            this.Player4Points.AutoSize = true;
            this.Player4Points.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player4Points.Location = new System.Drawing.Point(280, 392);
            this.Player4Points.Name = "Player4Points";
            this.Player4Points.Size = new System.Drawing.Size(66, 20);
            this.Player4Points.TabIndex = 16;
            this.Player4Points.Text = "0 Points";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.Controls.Add(this.Player4Points);
            this.Controls.Add(this.Player3Points);
            this.Controls.Add(this.Player4Label);
            this.Controls.Add(this.Player3Label);
            this.Controls.Add(this.Player2Points);
            this.Controls.Add(this.Player1Points);
            this.Controls.Add(this.Player2Label);
            this.Controls.Add(this.Player1Label);
            this.Controls.Add(this.GameScoresTitleLabel);
            this.Controls.Add(this.CountdownLabel);
            this.Controls.Add(this.TimeRemainingInGameLabel);
            this.Controls.Add(this.EStopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LivesPerPlayerComboBox);
            this.Controls.Add(this.LivesPerPlayerLabel);
            this.Controls.Add(this.GameLengthComboBox);
            this.Controls.Add(this.GameLengthLabel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GameLengthLabel;
        private System.Windows.Forms.ComboBox GameLengthComboBox;
        private System.Windows.Forms.Label LivesPerPlayerLabel;
        private System.Windows.Forms.ComboBox LivesPerPlayerComboBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button EStopButton;
        private System.Windows.Forms.Label TimeRemainingInGameLabel;
        private System.Windows.Forms.Label CountdownLabel;
        private System.Windows.Forms.Label GameScoresTitleLabel;
        private System.Windows.Forms.Label Player1Label;
        private System.Windows.Forms.Label Player2Label;
        private System.Windows.Forms.Label Player1Points;
        private System.Windows.Forms.Label Player2Points;
        private System.Windows.Forms.Label Player3Label;
        private System.Windows.Forms.Label Player4Label;
        private System.Windows.Forms.Label Player3Points;
        private System.Windows.Forms.Label Player4Points;
>>>>>>> Basic GUI Design
    }
}

