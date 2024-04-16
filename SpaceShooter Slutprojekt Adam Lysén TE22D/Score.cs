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

        time += Raylib.GetFrameTime();

        if (score >= 10 && score < 20 && time >= 20)
        {
            enemy.DelayTime = 2;
            enemy.enemyspeed = 2.5f;
            level = "Level 2";
            time = 0;
        }
        else if (score >= 20 && score < 30 && time >= 20)
        {
            enemy.DelayTime = 1;
            enemy.enemyspeed = 3;
            level = "Level 3";
            time = 0;
        }
        else if (score >= 30 && score < 40 && time >= 20)
        {
            enemy.DelayTime = 0.75;
            enemy.enemyspeed = 3.5f;
            level = "Level 4";
            time = 0;
        }
        else if (score >= 40 && score < 50 && time >= 20)
        {
            enemy.DelayTime = 0.5;
            enemy.enemyspeed = 4;
            level = "Level 5";
            time = 0;
        }
        else if (score >= 50 && time >= 20)
        {
            enemy.DelayTime = 0.25;
            enemy.enemyspeed = 5;
            level = "Final Level";
            time = 0;
        }

        Raylib.DrawText($"{score}", 242, 100, 50, Color.White);

        Raylib.DrawText(level, 20, 20, 30, Color.White);


    }
}