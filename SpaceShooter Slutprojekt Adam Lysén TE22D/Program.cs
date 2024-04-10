using System;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;


Raylib.SetTargetFPS(60);
Raylib.InitWindow(506, 900, "SpaceShooter");

Texture2D PlayerTexture = Raylib.LoadTexture(@"Spaceship2.png");
bool Game = false;
bool Start = true;

Player player = new Player();
Background background = new Background();

while (!Raylib.WindowShouldClose())
{
    if (Start)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        Raylib.DrawText("Press Enter", 125, 200, 40, Color.Black);
        Raylib.DrawText("To Start", 150, 260, 40, Color.Black);
        Raylib.EndDrawing();

        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            CountDown();
            Start = false;
            Game = true;
        }


    }
    else if (Game)
    {
        Raylib.BeginDrawing();
        background.BackScroll();
        Raylib.DrawTexture(PlayerTexture, player.Xpos, player.Ypos, Color.White);


        player.PlayerMove();
        player.EdgeCollision();
        player.Shoot();
        
        Raylib.EndDrawing();
    }

    else if (!Game && !Start)
    {

    }

}

static void CountDown()
{
    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Gray);

    Raylib.DrawText("3", 252, 400, 50, Color.White);
    Raylib.EndDrawing();
    Thread.Sleep(1000);

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Gray);

    Raylib.DrawText("2", 252, 400, 50, Color.White);
    Raylib.EndDrawing();
    Thread.Sleep(1000);

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Gray);

    Raylib.DrawText("1", 252, 400, 50, Color.White);
    Raylib.EndDrawing();
    Thread.Sleep(1000);
}

