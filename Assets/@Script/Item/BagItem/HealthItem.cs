using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : ItemBase
{
    public float setHp;
    public override void ItemAblity()
    {

        Manager.Instance.player.CurrentHp += setHp;
        
    }
}
