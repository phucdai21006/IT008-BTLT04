namespace BTLT04
{
    partial class StartScreen
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
            buttonStart = new System.Windows.Forms.Button();
            buttonHistory = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // buttonStart
            // 
            buttonStart.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)255)), ((int)((byte)128)));
            buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            buttonStart.Location = new System.Drawing.Point(281, 209);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new System.Drawing.Size(250, 60);
            buttonStart.TabIndex = 0;
            buttonStart.Text = "START";
            buttonStart.UseVisualStyleBackColor = false;
            // 
            // buttonHistory
            // 
            buttonHistory.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)255)), ((int)((byte)128)));
            buttonHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
            buttonHistory.Location = new System.Drawing.Point(281, 295);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new System.Drawing.Size(250, 60);
            buttonHistory.TabIndex = 1;
            buttonHistory.Text = "HISTORY";
            buttonHistory.UseVisualStyleBackColor = false;
            // 
            // StartScreen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            BackgroundImage = global::BTLT04.Properties.Resources.StartScreenBackGround;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(buttonHistory);
            Controls.Add(buttonStart);
            DoubleBuffered = true;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "StartScreen";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonStart;
        private Button buttonHistory;
    }
}