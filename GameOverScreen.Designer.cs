namespace BTLT04
{
    partial class GameOverScreen
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
            RestartButton = new System.Windows.Forms.Button();
            BackStartScreenButton = new System.Windows.Forms.Button();
            TimePlayBox = new System.Windows.Forms.Label();
            ScoreBox = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // RestartButton
            // 
            RestartButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)255)), ((int)((byte)128)));
            RestartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            RestartButton.Location = new System.Drawing.Point(169, 270);
            RestartButton.Name = "RestartButton";
            RestartButton.Size = new System.Drawing.Size(200, 70);
            RestartButton.TabIndex = 0;
            RestartButton.Text = "Restart";
            RestartButton.UseVisualStyleBackColor = false;
            // 
            // BackStartScreenButton
            // 
            BackStartScreenButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)255)), ((int)((byte)128)));
            BackStartScreenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            BackStartScreenButton.Location = new System.Drawing.Point(435, 270);
            BackStartScreenButton.Name = "BackStartScreenButton";
            BackStartScreenButton.Size = new System.Drawing.Size(200, 70);
            BackStartScreenButton.TabIndex = 1;
            BackStartScreenButton.Text = "Start Screen";
            BackStartScreenButton.UseVisualStyleBackColor = false;
            // 
            // TimePlayBox
            // 
            TimePlayBox.BackColor = System.Drawing.Color.Transparent;
            TimePlayBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            TimePlayBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)128)));
            TimePlayBox.Location = new System.Drawing.Point(169, 363);
            TimePlayBox.Name = "TimePlayBox";
            TimePlayBox.Size = new System.Drawing.Size(200, 30);
            TimePlayBox.TabIndex = 2;
            TimePlayBox.Text = "TimePlay:";
            TimePlayBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ScoreBox
            // 
            ScoreBox.BackColor = System.Drawing.Color.Transparent;
            ScoreBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            ScoreBox.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)192)), ((int)((byte)128)));
            ScoreBox.Location = new System.Drawing.Point(436, 360);
            ScoreBox.Name = "ScoreBox";
            ScoreBox.Size = new System.Drawing.Size(200, 30);
            ScoreBox.TabIndex = 3;
            ScoreBox.Text = "SCORE:";
            ScoreBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GameOverScreen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = global::BTLT04.Properties.Resources.GameOver;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(ScoreBox);
            Controls.Add(TimePlayBox);
            Controls.Add(BackStartScreenButton);
            Controls.Add(RestartButton);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "GameOverScreen";
            ResumeLayout(false);
        }

        #endregion

        private Button RestartButton;
        private Button BackStartScreenButton;
        private Label TimePlayBox;
        private Label ScoreBox;
    }
}