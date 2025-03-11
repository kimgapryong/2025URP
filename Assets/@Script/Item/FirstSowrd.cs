using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSowrd : Sword_Item
{
    public override void Init()
    {
        base.Init();
        animator = transform.Find("SwordObject").GetComponent<Animator>();
    }
  
    public override void ChangeAnim(Dfine.ItemState state)
    {
        switch (state)
        {
            case Dfine.ItemState.Idle:
                animator.Play("Sowrd_Idle");
                break;

            case Dfine.ItemState.Play:
                animator.Play("Sowrd_Atk");
                break;
        }
    }
}
