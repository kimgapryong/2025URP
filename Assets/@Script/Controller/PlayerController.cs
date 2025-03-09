using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : CreatureContoller
{
    public override bool Init()
    {
        base.Init();

        state = Dfine.State.Move;

        return true;
    }
    public override void UpdateMehod()
    {
        float x = Input.GetAxisRaw("Horizontal"); 
        float y = Input.GetAxisRaw("Vertical");

        dir = new Vector3(x, y, 0);

        base.UpdateMehod();
    }
    public override void Moving()
    {
        transform.position += dir * creatureData.speed * Time.deltaTime;
    }
}
