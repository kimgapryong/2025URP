using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : ItemBase
{
    public float setHp;
    public override void ItemAblity()
    {
        float curHp = Manager.Instance.player.CurrentHp += setHp;
        if (curHp > Manager.Instance.player.Hp)
        {
            Manager.Instance.player.CurrentHp = Manager.Instance.player.Hp;
            return;
        }
        Manager.Instance.player.CurrentHp = curHp;  
    }
}
