using System.Drawing.Imaging;

namespace BTLT04;

public class Sprite
{
    private readonly Image spriteSheet;
    private readonly ImageAttributes attr;
    private readonly bool Loop;
    private int currentFrame = 0;
    private const int FrameTime = 100; // ms
    private long lastFrameTime = 0;

    public readonly int FrameWidth, FrameHeight, FrameCount;
    public float X { get; set; }
    public float Y { get; set; }
    public float SpeedX { get; set; }
    public float SpeedY { get; set; }
    public bool IsFinished { get; set; } = false;

    public Sprite(
        string filePath,
        int frameWidth,
        int frameHeight,
        int frameCount,
        bool loop = true,
        Color? transparentColorFrom = null,
        Color? transparentColorTo = null)
    {
        spriteSheet = Image.FromFile(filePath);
        FrameWidth = frameWidth;
        FrameHeight = frameHeight;
        FrameCount = frameCount;
        Loop = loop;

        attr = new ImageAttributes();
        if (transparentColorFrom.HasValue && transparentColorTo.HasValue)
        {
            attr.SetColorKey(transparentColorFrom.Value, transparentColorTo.Value);
        }
    }

    // Update animation based on elapsed time
    public void Update()
    {
        if (IsFinished) return;
        
        var now = Environment.TickCount64;
        if (now - lastFrameTime < FrameTime) return;
        
        lastFrameTime = now;

        // Move sprite
        X += SpeedX;
        Y += SpeedY;
        
        if (Loop)
            currentFrame = (currentFrame + 1) % FrameCount;
        else
        {
            if (currentFrame < FrameCount - 1)
                currentFrame++;
            else
                IsFinished = true;
        }
    }

    public void Draw(Graphics g)
    {
        var srcRect = new Rectangle(currentFrame * FrameWidth, 0, FrameWidth, FrameHeight);
        var destRect = new Rectangle((int)X, (int)Y, FrameWidth, FrameHeight);

        g.DrawImage(spriteSheet, destRect, srcRect.X, srcRect.Y, srcRect.Width, srcRect.Height, GraphicsUnit.Pixel, attr);
    }
    
    public void Dispose() => spriteSheet.Dispose();
}