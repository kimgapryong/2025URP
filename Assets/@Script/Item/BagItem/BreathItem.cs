using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreathItem : ItemBase
{
    public float setBreath;
    public override void ItemAblity()
    {
        float curBreath = Manager.Instance.player.CurrentBreath += setBreath;
        if (curBreath > Manager.Instance.player.MaxBreath)
        {
            Manager.Instance.player.CurrentBreath = Manager.Instance.player.MaxBreath;
            return;
        }
        Manager.Instance.player.CurrentBreath = curBreath;
    }

  
}
