using System;
using Raylib_cs;

class Player
{
    public int Xpos = 205;
    public int Ypos = 600;
    public int Speed = 4;

    public void PlayerMove()
    {
        if (Raylib.IsKeyDown(KeyboardKey.D))
        {
            Xpos += Speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.A))
        {
            Xpos -= Speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.S))
        {
            Ypos += Speed;
        }
        if (Raylib.IsKeyDown(KeyboardKey.W))
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