namespace BTLT04;

partial class MainScreen
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
        pictureBox1 = new System.Windows.Forms.PictureBox();
        TimeBox = new System.Windows.Forms.Label();
        Score = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.BackgroundImage = ((System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage"));
        pictureBox1.ErrorImage = ((System.Drawing.Image)resources.GetObject("pictureBox1.ErrorImage"));
        pictureBox1.InitialImage = ((System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage"));
        pictureBox1.Location = new System.Drawing.Point(0, 415);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(822, 38);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // TimeBox
        // 
        TimeBox.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)255)), ((int)((byte)128)));
        TimeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        TimeBox.Location = new System.Drawing.Point(584, 9);
        TimeBox.Name = "TimeBox";
        TimeBox.Size = new System.Drawing.Size(200, 35);
        TimeBox.TabIndex = 1;
        TimeBox.Text = "Time:";
        TimeBox.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // Score
        // 
        Score.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)255)), ((int)((byte)128)));
        Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        Score.Location = new System.Drawing.Point(584, 54);
        Score.Name = "Score";
        Score.Size = new System.Drawing.Size(200, 35);
        Score.TabIndex = 2;
        Score.Text = "SCORE:";
        Score.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // MainScreen
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(Score);
        Controls.Add(TimeBox);
        Controls.Add(pictureBox1);
        StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        Text = "Form1";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private PictureBox pictureBox1;
    private Label TimeBox;
    private Label Score;
}