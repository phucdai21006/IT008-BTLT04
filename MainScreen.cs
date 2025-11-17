using System.Media;
using Timer = System.Windows.Forms.Timer;

namespace BTLT04;

// TODO: Cập nhật currentLane theo vị trí của player để bắn lửa theo lane
// Cập nhật lane khi: player.Y + 0.5 * player.FrameHeight <= lanes[currentLane - 1]
// Kiểm tra hàng bắn lửa: player.Y + 0.5 * player.FrameHeight <= lanes[currentLane + 1] ? currentLane : currentLane + 1

public partial class MainScreen : Form
{
    private readonly Sprite player;
    private readonly List<List<Sprite>> monsters = [[], [], []]; // 3 lanes
    private readonly List<List<Sprite>> fires = [[], [], []]; // 3 lanes
    private readonly List<Sprite> explosions = [];
    private readonly Timer timer;
    private const float MoveSpeed = 3;
    private bool keyUp;
    private bool keyDown;
    private readonly int[] lanes = [20, 140, 260]; //Hang quai spawn
    private readonly Random rnd = new Random();
    private int spawnCooldown;
    private int currentLane;

    public MainScreen()
    {
        InitializeComponent();
        var maxMonsters = rnd.Next(3, 11);
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
            Y = Height-220-80,
        };
        currentLane = lanes.Length / 2;
        
        // Sprite animation timer
        timer = new Timer();
        timer.Interval = 14; // ~60 FPS
        timer.Tick += (_, _) =>
        {
            UpdatePlayerVelocity();
            
            spawnCooldown++;
            if (spawnCooldown >= rnd.Next(70, 600))
            {
                spawnCooldown = 0;

                if (monsters.Count < maxMonsters)
                {
                    var lane = rnd.Next(0, lanes.Length);
                    monsters[lane].Add(CreateMonster());
                }
            }

            for (var i = 0; i < lanes.Length; i++)
            {
                if (monsters[i].Count == 0) continue;

                var monster = monsters[i][0];
                monster.Update();
                
                if (IsColliding(monster, player))
                {
                    monsters[i].RemoveAt(0);
                    //GameOver();
                    continue;
                }
                if (monster.X + 170 < 0)
                {
                    monster.X = ClientSize.Width + rnd.Next(0, 400);
                    monster.Y = lanes[rnd.Next(lanes.Length)];

                    maxMonsters = rnd.Next(3, 11); //Tang do kho 
                }
                
                if (fires[i].Count == 0) continue;
                if (IsColliding(monster, fires[i][0]))
                {
                    explosions.Add(CreateExplosion(monster.X, monster.Y));
                    fires[i].RemoveAt(0);
                    monsters[i].RemoveAt(0);
                }
            }
            
            foreach (var explosion in explosions.ToList())
            {
                explosion.Update();
                if (explosion.IsFinished)
                {
                    explosions.Remove(explosion);
                    explosion.Dispose();
                }
            }
            
            Invalidate();
        };
        timer.Start();
        
        KeyDown += MainScreen_KeyDown;
        KeyUp += MainScreen_KeyUp;
        
        CreateBackGround();
    }

    private void MainScreen_KeyDown(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up:
                keyUp = true;
                break;
            case Keys.Down:
                keyDown = true;
                break;
            case Keys.A:
                fires[currentLane].Add(CreateFire(player.X, player.Y));
                break;
            default:
                return;
        }
    }

    private void MainScreen_KeyUp(object? sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Up:
                keyUp = false;
                break;
            case Keys.Down:
                keyDown = false;
                break;
            default:
                return;
        }
    }

    private void UpdatePlayerVelocity()
    {
        player.SpeedY = (keyDown ? MoveSpeed : 0) - (keyUp ? MoveSpeed : 0);
        if (player.SpeedY != 0)
            player.Update();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        for (var i = 0; i < lanes.Length; i++)
        {
            foreach (var monster in monsters[i])
                monster.Draw(e.Graphics);
            foreach (var fire in fires[i])
                fire.Draw(e.Graphics);
        }
        
        foreach (var explosion in explosions) // ToList to avoid modifying while iterating
            explosion.Draw(e.Graphics);
        
        player.Draw(e.Graphics);
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {  
        player.Dispose();
        for (var i = 0; i < lanes.Length; i++)
        {
            foreach (var monster in monsters[i])
                monster.Dispose();
            foreach (var fire in fires[i])
                fire.Dispose();
        }
        foreach (var explosion in explosions)
            explosion.Dispose();
        
        base.OnFormClosed(e);
    }

    //PHAN BACKGROUND

    private readonly SoundPlayer soundMainScreen = new SoundPlayer("Resources/MainScreenSound.wav");
    private readonly PictureBox pictureBox2 = new PictureBox();
    private readonly Timer timeChangeGround = new Timer();
    private readonly Timer timeCount = new Timer();
    private int time;
    private int score;
    private const int SpeedGround = 80; //ms

    private void CreateBackGround()
    {
        soundMainScreen.PlayLooping();
        timeCount.Interval = 1000;
        timeCount.Tick += TimeCount_Tick;
        timeCount.Start();
        //GameOver();
        //KHOA GAMEOVER() KHI CAN TEST NHAN VAT
    }

    private void TimeCount_Tick(object? sender, EventArgs e)
    {
        ++time;
        TimeBox.Text = "TIME: " + time;
    }
    
    //void GameOver()
    //{
    //    string date = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
    //    Result results = new Result() { Time = date, PlayTime = time, Score = score };
    //    ((StartScreen)this.Owner).AddItemToList(results);
    //    GameOverScreen gameOverScreen = new GameOverScreen(results);
    //    gameOverScreen.Show();
    //    gameOverScreen.Owner = this.Owner;
    //    this.Close();
    //}
    
    private async Task GameOver()
    {
        if (Owner is not StartScreen sc)
        {
            Close();
            return;
        }
        
        await Task.Delay(10000);
        var date = DateTime.Now.ToString("dd/MM/yy HH:mm:ss");
        var results = new Result() { Time = date, PlayTime = time, Score = score };
        sc.AddItemToList(results);
        var gameOverScreen = new GameOverScreen(results);
        gameOverScreen.Show();
        gameOverScreen.Owner = sc;
        Close();
    }
    
    private Sprite CreateMonster()
    {
        return new Sprite(
            "Resources/Images/monster.jpg",
            frameWidth:170,
            frameHeight:140,
            frameCount:6,
            transparentColorFrom: Color.FromArgb(70, 110, 150),
            transparentColorTo: Color.FromArgb(140, 180, 255)
        )
        {
            SpeedX = -rnd.Next(2, 7),
            X = ClientSize.Width + rnd.Next(0, 100),
            Y = lanes[rnd.Next(lanes.Length)] //Tang toc quai ngau nhien
        };
    }

    private static Sprite CreateFire(float x, float y)
    {
        // x: player.X
        // y: player.Y
        return new Sprite(
            "Resources/Images/fire.png",
            frameWidth: 64,
            frameHeight: 48,
            frameCount: 8,
            transparentColorFrom: Color.White,
            transparentColorTo: Color.White
        )
        {
            X = x, Y = y,
            SpeedX = 2
        };
    }
    
    private static Sprite CreateExplosion(float x, float y)
    {
        // x: monster.X
        // y: monster.Y
        return new Sprite(
            "Resources/Images/explosion.png",
            frameWidth: 32,
            frameHeight: 32,
            frameCount: 12,
            loop: false,
            transparentColorFrom: Color.FromArgb(0, 248, 0),
            transparentColorTo: Color.FromArgb(6, 248, 6)
        )
        { X = x, Y = y };
    }
    
    private static bool IsColliding(Sprite a, Sprite b)
    {
        var dx = (a.X + a.FrameWidth / 2.0) - (b.X + b.FrameWidth / 2.0);
        var dy = (a.Y + a.FrameHeight / 2.0) - (b.Y + b.FrameHeight / 2.0);

        return Math.Abs(dx) < 50 && Math.Abs(dy) < 50;
    }
}