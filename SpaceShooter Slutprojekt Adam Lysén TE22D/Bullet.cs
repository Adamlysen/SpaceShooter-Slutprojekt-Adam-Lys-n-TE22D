using System;
using Raylib_cs;

class Bullet
{
    public const int MaxBullets = 100;
    public int BulletSpeed = 15;
    public Rectangle[] bullets = new Rectangle[MaxBullets];
    public bool[] BulletActive = new bool[MaxBullets];
    Enemy enemy;

    Score score;
    Background Background;
    

    public void Shoot(int BpX, int BpY, Enemy enemy, Score score, Background background)
    {
        this.enemy = enemy; // Förstår ej än
        this.score = score; // Förstår ej än
        this.Background = background; // Förstår ej än
        

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

        for (int i = 0; i < MaxBullets; i++)
        {
            if (BulletActive[i])
            {
                for (int j = 0; j < Enemy.MaxEnemies; j++)
                {
                    if (enemy.EnemyActive[j] && Raylib.CheckCollisionRecs(bullets[i], enemy.Enemies[j]))
                    {
                        BulletActive[i] = false;
                        enemy.EnemyActive[j] = false;
                        score.score++;
                    }
                }
            }
        }
    }
}
