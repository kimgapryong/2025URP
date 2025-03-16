using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkController : CreatureContoller
{
    public float waitTime;
    public float damage;

    public override bool Init()
    {
        Damage = damage;
        state = Dfine.State.Idle;
        StartCoroutine(StartAtkTime());
        return true;
    }


    public virtual IEnumerator StartAtkTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            state = Dfine.State.Attack;
        }
    }
}
