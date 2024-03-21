using System;
using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.SetTargetFPS(60);
        Raylib.InitWindow(600, 900, "SpaceShooter");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            StartScreen();
            Raylib.ClearBackground(Color.Blue);
            Raylib.DrawText("GAY", 200, 200, 50, Color.Black);
            Raylib.EndDrawing();
        }
    }

    static void StartScreen()
    {
        while (!Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            Raylib.ClearBackground(Color.White);
            Raylib.DrawText("Press Enter to Start", 50, 250, 45, Color.Black);
        }
       
    }
}
