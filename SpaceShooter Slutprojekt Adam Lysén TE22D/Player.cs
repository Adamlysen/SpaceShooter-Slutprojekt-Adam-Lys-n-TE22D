using System;
using System.ComponentModel;
using Raylib_cs;

class Player
{
    public int Xpos = 205;
    public int Ypos = 600;
    public int Speed = 5;
    public int PlayerCenterX;
    public int PlayerCenterY;

    public bool CanMove = true;
    public void PlayerMove()  
    {
        if (Raylib.IsKeyDown(KeyboardKey.D) && CanMove)
        {
            Xpos += Speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.A) && CanMove)
        {
            Xpos -= Speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S) && CanMove)
        {
            Ypos += Speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W) && CanMove)
        {
            Ypos -= Speed;
        }
    }

    public void EdgeCollision()
    {
        if (Xpos >= 426)
        {
            Xpos = 425;
        }
        if (Xpos <= -20)
        {
            Xpos = -19;
        }
        if (Ypos >= 830)
        {
            Ypos = 829;
        }
        if (Ypos <= 0)
        {
            Ypos = 1;
        }
    }
}