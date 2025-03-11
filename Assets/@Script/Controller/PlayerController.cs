using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : CreatureContoller
{
    
    public float atkTime;
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
        //외워야할 것
      
        base.UpdateMehod();
    }

    public override void UseItem()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //외워야 할것
            if (EventSystem.current.IsPointerOverGameObject())
                return;


            if (myCurItem != null)
                myCurItem.ItemAblity();

        }
    }
    public override void Moving()
    {
        transform.position += dir * creatureData.speed * Time.deltaTime;
    }
}
