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

        TimeSinceLastSpawn += Raylib.GetFrameTime();   // Håller koll på tiden


        if (TimeSinceLastSpawn >= DelayTime)   // Skapar delay mellan varje fiende
        {
            TimeSinceLastSpawn = 0;
            for (int i = 0; i < MaxEnemies; i++)
            {
                if (!EnemyActive[i])                    //  For loop som skapar fienderna 
                {
                    Enemies[i] = new Rectangle(Random.Shared.Next(60, 450), -25, 25, 25); 
                    EnemyActive[i] = true;                 // Skapar fienderna vid en randomized X position
                    break;            // Avlutar loopen när fienden har spawnats
                }
            }
        }

        for (int i = 0; i < MaxEnemies; i++)
        {
            if (EnemyActive[i])                     // For loop som ritar ut fienderna 
            {
                Enemies[i].Y += enemyspeed;        // Ger fienderna en speed
                if (Enemies[i].Y >= 900)
                {
                    EnemyActive[i] = false;        // Spelet avslutas om fienden når botten av skärmen
                    death = true;    
                }
                else
                {
                    Raylib.DrawRectangleRec(Enemies[i], Color.Purple);  // Ritar fienden
                }
            }
        }

        for (int i = 0; i < MaxEnemies; i++)
        {
            if ((EnemyActive[i]))              // For loop som avslutar spelet vid collision med en fiende
            {
                if (Raylib.CheckCollisionRecs(Enemies[i], playerrectangle))
                {
                    death = true;
                }
            }
        }

        if (death)              // If sats som visar vad som ska hända när man dör
        {
            enemyspeed = 0;
            background.bgspeed = 0;
            player.CanMove = false;           // Det mesta stoppas med en liten animation av en cirkel
            Raylib.DrawCircle(player.Xpos + 30, player.Ypos + 30, deathradius, Color.Red);
            deathradius += 20;
            if (deathradius >= 1000)    // När cirkeln är större än 1000 så visas slutskärmen
            {
                deathradius += 0;
                deathradius = 0;
                Program.Start = false;
                Program.Game = false;
                death = false;
            }
        }
    }

    public void ResetEnemy()   // Återställer fienden vid en restart från slutskärmen
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