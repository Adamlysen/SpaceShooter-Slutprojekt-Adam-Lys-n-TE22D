using System;
using Raylib_cs;

class Enemy
{
    public const int MaxEnemies = 50;
    public bool[] EnemyActive = new bool[MaxEnemies];
    public Rectangle[] Enemies = new Rectangle[MaxEnemies];
    float TimeSinceLastSpawn = 0;
    public double DelayTime = 3;
    Score score;

    public void EnemySpawn()
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
                Enemies[i].Y += 2;
                if (Enemies[i].Y >= 900)
                {
                    EnemyActive[i] = false;
                }
                else
                {
                    Raylib.DrawRectangleRec(Enemies[i], Color.Purple);
                }
            }
        }
    }

}