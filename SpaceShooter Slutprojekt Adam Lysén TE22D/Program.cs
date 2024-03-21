using System;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;


Raylib.SetTargetFPS(60);
Raylib.InitWindow(600, 900, "SpaceShooter");

Texture2D bgtexture = Raylib.LoadTexture(@"spacebg.gif");
bool Scenegame1 = false;

while (!Raylib.WindowShouldClose())
{
    StartScreen();
    Scenegame1 = true;
    while (Scenegame1)
    {
        Raylib.BeginDrawing();
        Raylib.DrawTexture(bgtexture, 0, 0, Color.White);
        Raylib.EndDrawing();
    }

}

static void StartScreen()
{
    while (!Raylib.IsKeyPressed(KeyboardKey.Enter))
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        Raylib.DrawText("Press Enter to Start", 50, 250, 45, Color.Black);
        Raylib.EndDrawing();
    }
}

