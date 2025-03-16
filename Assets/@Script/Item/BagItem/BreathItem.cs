using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathItem : ItemBase
{
    public float setBreath;
    public override void ItemAblity()
    {
        player.CurrentBreath += setBreath;
    }

  
}
