using System;
using System.Numerics;
using Raylib_cs;

class Background
{

    Texture2D bgtexture = Raylib.LoadTexture(@"spacebgdotspng.png");
    public int bgspeed = 1;
    int Xpos = 0;
    int Ypos = 0;
    int ScreenHeight = 900;

    public void BackScroll()
    {
        Raylib.DrawTexture(bgtexture, Xpos, Ypos, Color.White);
        Raylib.DrawTexture(bgtexture, Xpos, Ypos - ScreenHeight, Color.White);

        Ypos += bgspeed;

        if (Ypos == ScreenHeight)
        {
            Ypos = 0;
        }
    }

}