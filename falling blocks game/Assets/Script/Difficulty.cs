using UnityEngine;
using System.Collections;

public class Difficulty
{
    private static float secondsToMaxDifficulty = 60;

    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Timers.GetTimers().Seconds/secondsToMaxDifficulty);
    }
}
