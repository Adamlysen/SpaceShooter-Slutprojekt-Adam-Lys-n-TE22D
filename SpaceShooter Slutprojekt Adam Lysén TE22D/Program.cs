using System;
using System.Threading;
using Raylib_cs;

class Program
{
    public static bool Game = false;
    public static bool Start = true;

    static void Main()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(506, 900, "SpaceShooter");

        Texture2D PlayerTexture = Raylib.LoadTexture(@"Spaceship2.png");
        Background background = new Background();
        Player player = new Player();
        Score score = new Score();
        Enemy enemy = new Enemy();
        Bullet bullet = new Bullet();

        while (!Raylib.WindowShouldClose())
        {
            if (Start)       // Startskärm
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);
                Raylib.DrawText("Press Enter", 125, 200, 40, Color.Black);
                Raylib.DrawText("To Start", 150, 260, 40, Color.Black);
                Raylib.EndDrawing();

                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    CountDown();
                    Start = false;             // Startar spelet
                    Game = true;
                }
            }
            else if (Game)  // Huvudspelet
            {
                Raylib.BeginDrawing();
                background.BackScroll();           // Startar bakgrunden
                Rectangle playerrec = new Rectangle(player.Xpos + 15, player.Ypos + 5, 70, 60); // Skapar spelarens collisionbox
                player.PlayerMove();              // Player Movement
                player.EdgeCollision();           // Skapar boundaries runt skärmen
                bullet.Shoot(player.Xpos, player.Ypos, enemy, score, background);  // Låter spelaren skjuta
                enemy.EnemySpawn(playerrec, background, player);  // Spawnar fienderna
                Raylib.DrawRectangleRec(playerrec, Color.Blank);  // Ritar ut collisionbox
                Raylib.DrawTexture(PlayerTexture, player.Xpos, player.Ypos, Color.White); // Ritar ut spelarens texture
                score.ScoreCount(enemy);  // Ansvarar för poängräkningen
                Raylib.EndDrawing();

                if (Raylib.IsKeyPressed(KeyboardKey.Escape))  // Avslutar spelet när man trycker på ESC
                {
                    Raylib.CloseWindow();
                }
            }
            else if (!Game && !Start) // Slutskärmen när man dör
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.Red);
                Raylib.DrawText("You Died", 150, 175, 50, Color.Black);
                Raylib.DrawText("Press Enter To Play Again", 50, 275, 30, Color.Black);
                Raylib.DrawText("Press ESC to Exit", 110, 375, 30, Color.Black);
                Raylib.EndDrawing();
                if (Raylib.IsKeyPressed(KeyboardKey.Escape))  // Stänga ner spelet vid förlust
                {
                    Raylib.CloseWindow();
                }
                else if (Raylib.IsKeyPressed(KeyboardKey.Enter))  // Starta om spelet vid förlust
                {
                    CountDown();
                    player.Xpos = 205;  
                    player.Ypos = 600;  // Återställer spelaren till startpositionen
                    player.Speed = 5;

                    background.bgspeed = 1; // Startar bakgrunden igen

                    player.CanMove = true; // Låter spelaren röra på sig igen

                    enemy.enemyspeed = 2; // Startar fienderna igen

                    score.levels[0] = true; // Starta på Level 1

                    score.score = 0; // Återställer antalet poäng till 0

                    enemy.ResetEnemy(); // Tar bort fienderna som fanns innan

                    Game = true; // Startar spelet på nytt
                }
            }
        }
    }

    static void CountDown()  // Skapar en countdown som räknar ner innan spelet börjar
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Gray);

        Raylib.DrawText("3", 252, 400, 50, Color.Black);
        Raylib.EndDrawing();
        Thread.Sleep(1000);   // Pausa i en sekund 

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Gray);

        Raylib.DrawText("2", 252, 400, 50, Color.Black);
        Raylib.EndDrawing();
        Thread.Sleep(1000);

        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Gray);

        Raylib.DrawText("1", 252, 400, 50, Color.Black);
        Raylib.EndDrawing();
        Thread.Sleep(1000);
    }
}
