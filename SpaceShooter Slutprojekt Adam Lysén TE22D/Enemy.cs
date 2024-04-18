using System;
using Raylib_cs;

class Enemy
{
    public const int MaxEnemies = 50;
    public bool[] EnemyActive = new bool[MaxEnemies];
    public Rectangle[] Enemies = new Rectangle[MaxEnemies];
    float TimeSinceLastSpawn = 0;
    public double DelayTime = 3;

    public float enemyspeed = 2;

    public bool death = false;
    Score score;
    Player player;
    Background background;
    Program Program;

    public int deathradius = 0;


    public void EnemySpawn(Rectangle playerrectangle, Background background, Player player)
    {

        TimeSinceLastSpawn += Raylib.GetFrameTime();

        // DelayTime = 3;

        if (TimeSinceLastSpawn >= DelayTime)
        {
            TimeSinceLastSpawn = 0;
            for (int i = 0; i < MaxEnemies; i++)
            {
                if (!EnemyActive[i])
                {
                    Enemies[i] = new Rectangle(Random.Shared.Next(75, 430), -25, 25, 25);
                    EnemyActive[i] = true;
                    break;
                }
            }
        }

        for (int i = 0; i < MaxEnemies; i++)
        {
            if (EnemyActive[i])
            {
                Enemies[i].Y += enemyspeed;
                if (Enemies[i].Y >= 900)
                {
                    EnemyActive[i] = false;
                    death = true;
                }
                else
                {
                    Raylib.DrawRectangleRec(Enemies[i], Color.Purple);
                }
            }
        }

        for (int i = 0; i < MaxEnemies; i++)
        {
            if ((EnemyActive[i]))
            {
                if (Raylib.CheckCollisionRecs(Enemies[i], playerrectangle))
                {
                    death = true;
                }
            }
        }

        if (death)
        {
            enemyspeed = 0;
            background.bgspeed = 0;
            player.CanMove = false;
            Raylib.DrawCircle(player.Xpos + 30, player.Ypos + 30, deathradius, Color.Red);
            deathradius += 20;
            if (deathradius >= 1000)
            {
                deathradius += 0;
                deathradius = 0;
                Program.Start = false;
                Program.Game = false;
                death = false;
            }
        }
    }

    public void ResetEnemy()
    {
        for (int i = 0; i < MaxEnemies; i++)
        {
            if (EnemyActive[i])
            {
                EnemyActive[i] = false;
            }
        }
    }

}