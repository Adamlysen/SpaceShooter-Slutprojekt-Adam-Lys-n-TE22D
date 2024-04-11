using System.Data.Common;
using Raylib_cs;

class Bullet
{
    public const int MaxBullets = 100;
    public int BulletSpeed = 15;
    public Rectangle[] bullets = new Rectangle[MaxBullets];
    public bool[] BulletActive = new bool[MaxBullets];

    public void Shoot(int BpX, int BpY)
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            for (int i = 0; i < MaxBullets; i++)
            {
                if (!BulletActive[i])
                {
                    bullets[i] = new Rectangle(BpX + 50, BpY + 20, 5, 15);
                    BulletActive[i] = true;
                    break;
                }
            }
        }

        for (int i = 0; i < MaxBullets; i++)
        {
            if (BulletActive[i])
            {
                bullets[i].Y -= BulletSpeed;
                if (bullets[i].Y + bullets[i].Height <= 0)
                {
                    BulletActive[i] = false;
                }
                else
                {
                    Raylib.DrawRectangleRec(bullets[i], Color.Red);
                }
            }
        }
    }
}