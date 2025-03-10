using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureContoller
{
    public PlayerController player; 
    public override bool Init()
    {
        base.Init();
        state = Dfine.State.Idle;
        player = Manager.Instance.player;
        return true;
    }
    public override void Idle()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= creatureData.arange)
            state = Dfine.State.Move;
    }
    public override void Attack()
    {
        UseItem();
        state = Dfine.State.Move;
    }
    public override void Moving()
    {
        dir = (player.transform.position -transform.position).normalized;
        Debug.Log(dir.x + ", " + dir.y);
        transform.position += dir * Speed * Time.deltaTime;

        if(Vector3.Distance(transform.position, player.transform.position) <= creatureData.atkArange) 
            state = Dfine.State.Attack;

        if (Vector3.Distance(transform.position, player.transform.position) >= creatureData.arange)
            state = Dfine.State.Idle;
    }
}
