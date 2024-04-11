using Raylib_cs;

class Bullet
{
    public const int MaxBullets = 100;
    public int BulletSpeed = 10;
    public Rectangle[] bullets = new Rectangle[MaxBullets];
    public bool[] BulletActive = new bool[MaxBullets];
    Player player = new Player();

    public void Shoot()
    {
        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            for (int i = 0; i < MaxBullets; i++)
            {
                if (!BulletActive[i])
                {
                    bullets[i] = new Rectangle(player.Xpos + 45, player.Ypos + 20, 5, 15);
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