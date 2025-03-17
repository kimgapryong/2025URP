using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dfine
{
    public enum StageScene
    {
        Start,
        Lobby,
        Stage,
        Clear,
    }
   public enum State
    {
        Idle,
        Move,
        Attack
    }

    public enum ItemState
    {
        Idle,
        Play,
    }

    public enum InvenItem
    {
        FlashLight,
        Sword,
        Gun,
        ShotGun,
        RayzerGun,
        Legend,
        Bagpack,
        Breath,
        MiniMap,
    }
}
