﻿using System;
using System.Security.Cryptography.X509Certificates;
using Raylib_cs;


Raylib.SetTargetFPS(60);
Raylib.InitWindow(506, 900, "SpaceShooter");

Texture2D bgtexture = Raylib.LoadTexture(@"spacebgdotspng.png");
Texture2D PlayerTexture = Raylib.LoadTexture(@"Spaceship2.png");
bool Game = false;
bool Start = true;

Player player = new Player();

while (!Raylib.WindowShouldClose())
{
    if (Start)
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.White);
        Raylib.DrawText("Press Enter to Start", 25, 250, 40, Color.Black);
        Raylib.EndDrawing();

        if (Raylib.IsKeyPressed(KeyboardKey.Enter))
        {
            Start = false;
            Game = true;
        }
    }
    else if (Game)
    {
        Raylib.BeginDrawing();
        Raylib.DrawTexture(PlayerTexture, player.Xpos, player.Ypos, Color.White);
        Raylib.EndDrawing();

        player.PlayerMove();
        player.EdgeCollision();
        
    }

    else if (!Game && !Start)
    {

    }

}

