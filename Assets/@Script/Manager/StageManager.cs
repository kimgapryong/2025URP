using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stages
{
    public static bool[] stages = new bool[5]
    {
        true,
        false,
        false,
        false,
        false,
    };
}

public class StageManager
{
    public bool CheckStage(int key)
    {
        return Stages.stages[key];
    }
}
