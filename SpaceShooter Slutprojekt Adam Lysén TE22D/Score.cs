using Raylib_cs;
using System;

class Score
{
    public int score = 0;

    string level = "Level 1";
    double time = 0;
    Enemy enemy;
    public void ScoreCount(Enemy enemy)
    {
        this.enemy = enemy;

        time += Raylib.GetFrameTime();
        if (score >= 3 && time > 3)
        {
            enemy.DelayTime = 1;
            level = "Level 2";
            time = 0;
        }
        else if (score >= 20 && time > 20)
        {
            enemy.DelayTime = 2;
            level = "Level 3";
            time = 0;
        } 

        Raylib.DrawText($"{score}", 242, 100, 50, Color.White);

        Raylib.DrawText(level, 20, 20, 40, Color.White);


    }
}