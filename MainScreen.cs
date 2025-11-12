using Timer = System.Windows.Forms.Timer;

namespace BTLT04;

public partial class MainScreen : Form
{
    private readonly Sprite player, fire, explosion, monster;
    private readonly Timer timer;
    private const float MoveSpeed = 3;
    private bool keyUp;
    private bool keyDown;
    
    public MainScreen()
    {
        InitializeComponent();

        DoubleBuffered = true;
        
        // Khoi tao sprites
        // Chi duoc thay doi gia tri trong ngoac nhon (X, Y, SpeedX, SpeedY)
        // Di chuyen sprite bang cach thay doi SpeedX, SpeedY
        player = new Sprite(
            "Resources/Images/wizard.jpg",
            frameWidth: 192,
            frameHeight: 220,
            frameCount: 6,
            transparentColorFrom: Color.FromArgb(110, 110, 110),
            transparentColorTo: Color.FromArgb(170, 170, 170)
        )
        {
            // Initial position
            X = 100,
            Y = 100,
        };
        
        fire = new Sprite(
            "Resources/Images/fire.png",
            frameWidth: 64,
            frameHeight: 48,
            frameCount: 8,
            transparentColorFrom: Color.White, 
            transparentColorTo: Color.White
        )
        {
            // Fixed speed, move right
            SpeedX = 2
        };
        
        explosion = new Sprite(
            "Resources/Images/explosion.png",
            frameWidth: 32,
            frameHeight: 32,
            frameCount: 12,
            transparentColorFrom: Color.FromArgb(0, 248, 0), 
            transparentColorTo: Color.FromArgb(6, 248, 6)
        );
        
        monster = new Sprite(
            "Resources/Images/monster.jpg",
            frameWidth: 170,
            frameHeight: 145,
            frameCount: 6,
            transparentColorFrom: Color.FromArgb(70, 110, 150), 
            transparentColorTo: Color.FromArgb(140, 180, 255)
        )
        {
            // Fixed speed, move left
            SpeedX = -1.5f,
        };
        
        // Sprite animation timer
        timer = new Timer();
        timer.Interval = 16; // ~60 FPS
        timer.Tick += (s, e) =>
        {
            player.Update();
            fire.Update();
            explosion.Update();
            monster.Update();
            Invalidate();
        };
        timer.Start();
    }
    
    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up:
                keyUp = true;
                break;
            case Keys.Down:
                keyDown = true;
                break;
        }

        UpdatePlayerVelocity();
    }

    private void OnKeyUp(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up:
                keyUp = false;
                break;
            case Keys.Down:
                keyDown = false;
                break;
        }

        UpdatePlayerVelocity();
    }

    private void UpdatePlayerVelocity()
    {
        player.SpeedY = (keyDown ? MoveSpeed : 0) - (keyUp ? MoveSpeed : 0);
    }
    
    protected override void OnPaint(PaintEventArgs e)
    {
        // Ve sprite o toa do (x, y)
        player.Draw(e.Graphics);
    }
    
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // Copy toan bo function qua form game la duoc   
        player.Dispose();
        fire.Dispose();
        explosion.Dispose();
        monster.Dispose();
        base.OnFormClosed(e);
    }
}