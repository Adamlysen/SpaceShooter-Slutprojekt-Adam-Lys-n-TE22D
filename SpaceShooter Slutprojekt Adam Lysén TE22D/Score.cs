using Raylib_cs;
using System;

class Score
{
    public int score = 0;

    public void ScoreCount()
    {
        Raylib.DrawText($"{score}", 242, 100, 50, Color.White);
    }
}