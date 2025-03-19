using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public static class Stages
{
    public static bool[] stages = new bool[6]
    {
        true,
        false,
        false,
        false,
        false,
        false,
    };
}

public static class TragerCrew
{
    public static bool[] stages = new bool[5]
   {
        false,
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
    public void OkStage()
    {
        for (int i = 0; i < Stages.stages.Length; i++)
        {
            if (!CheckStage(i))
            {
                Stages.stages[i] = true;
                break;
            }
        }
    }

    public bool CheckTrager(int key)
    {
        return TragerCrew.stages[key];
    }

    public void OkTrager()
    {
        for(int i = 0; i< TragerCrew.stages.Length; i++)
        {
            if (!CheckTrager(i))
            {
                TragerCrew.stages[i] = true;
                break;
            }
        }
    }
}
