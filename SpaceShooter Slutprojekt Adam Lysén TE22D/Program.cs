using System;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;


Raylib.SetTargetFPS(60);
Raylib.InitWindow(506, 900, "SpaceShooter");

Texture2D bgtexture = Raylib.LoadTexture(@"spacebg4.png");
Texture2D PlayerTexture = Raylib.LoadTexture(@"Spaceship2.png");
bool Game = false;
bool Start = true;

while (!Raylib.WindowShouldClose())
{
    if (Start)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        Raylib.DrawText("Press Enter to Start", 25, 250, 40, Color.Black);
        Raylib.EndDrawing();

        if (Raylib.IsKeyPressed(KeyboardKey.Enter)) {
            Start = false;
            Game = true;
        }
    }
    else if (Game)
    {
        Raylib.BeginDrawing();
        Raylib.DrawTexture(bgtexture, 0, 0, Color.White);
        Raylib.DrawTexture(PlayerTexture, 205, 600, Color.White);
        Raylib.EndDrawing();
    }

    else if (!Game && !Start)
    {

    }

}

