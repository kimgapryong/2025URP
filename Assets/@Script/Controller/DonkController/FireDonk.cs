using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDonk : DonkController
{
    public Collider2D coll;

    public override bool Init()
    {
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        animator = GetComponent<Animator>();

        base.Init();
        return true;
    }
    public override void Attack()
    {
        coll.enabled = true;
    }
    //애니메이션 이벤트
    public void ReturnIdle()
    {
        state = Dfine.State.Idle;
        coll.enabled = false;
    }
    public override void ChangeAnim(Dfine.State state)
    {
        switch (state)
        {
            case Dfine.State.Idle:
                animator.Play("Idle");
                Debug.Log("대기");
                break;

            case Dfine.State.Attack:
                animator.Play("Fire_Incendiary_Start");
                Debug.Log("공격");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null)
            player.Ondamage(this, Damage);
        
    }
}
