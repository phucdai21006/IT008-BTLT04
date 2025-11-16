using System.Drawing.Imaging;

namespace BTLT04;

public class Sprite
{
    private readonly Image spriteSheet;
    private readonly ImageAttributes attr;
    public readonly int frameWidth, frameHeight, frameCount;
    private int currentFrame = 0;
    private const int FrameTime = 100; // ms
    private long lastFrameTime = 0;

    public float X { get; set; }
    public float Y { get; set; }
    public float SpeedX { get; set; }
    public float SpeedY { get; set; }

    public Sprite(
        string filePath,
        int frameWidth,
        int frameHeight,
        int frameCount,
        Color? transparentColorFrom = null,
        Color? transparentColorTo = null)
    {
        spriteSheet = Image.FromFile(filePath);
        this.frameWidth = frameWidth;
        this.frameHeight = frameHeight;
        this.frameCount = frameCount;

        attr = new ImageAttributes();
        if (transparentColorFrom.HasValue && transparentColorTo.HasValue)
        {
            attr.SetColorKey(transparentColorFrom.Value, transparentColorTo.Value);
        }
    }

    // Update animation based on elapsed time
    public void Update()
    {
        var now = Environment.TickCount64;
        if (now - lastFrameTime < FrameTime) return;

        currentFrame = (currentFrame + 1) % frameCount;
        lastFrameTime = now;

        // Move sprite
        X += SpeedX;
        Y += SpeedY;
    }

    public void Draw(Graphics g)
    {
        var srcRect = new Rectangle(currentFrame * frameWidth, 0, frameWidth, frameHeight);
        var destRect = new Rectangle((int)X, (int)Y, frameWidth, frameHeight);

        g.DrawImage(spriteSheet, destRect, srcRect.X, srcRect.Y, srcRect.Width, srcRect.Height, GraphicsUnit.Pixel, attr);
    }
    public void Dispose() => spriteSheet.Dispose();
}