using Raylib_cs;
using System;

class Score
{
    public int score = 0;

    public void ScoreCount(int DelayTimeforScore)
    {
        Raylib.DrawText($"{score}", 242, 100, 50, Color.White);

        if (score >= 3 && score < 6)
        {
            DelayTimeforScore = 2;
        }
        if (score >= 6) {
            DelayTimeforScore = 1;
        }
    }
}