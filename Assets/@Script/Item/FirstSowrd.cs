using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSowrd : ItemBase
{
    private Collider2D coll;
    public bool isWait;
    public Coroutine _cor;
    public override void Init()
    {
        base.Init();
        coll = GetComponent<Collider2D>();
        animator = transform.Find("SwordObject").GetComponent<Animator>();
        coll.enabled = false;
    }
    public override void ItemAblity()
    {
       if(!isWait)
        {
            if (_cor != null)
                StopCoroutine(WaitTime());

            _cor = StartCoroutine(WaitTime());
        }
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

    public IEnumerator WaitTime()
    {
        isWait = true;
        coll.enabled = true;
        State = Dfine.ItemState.Play;
        yield return new WaitForSeconds(0.4f);
        coll.enabled = false;
        State = Dfine.ItemState.Idle;

        yield return new WaitForSeconds(itemData.atkTime);
        isWait = false;
    }

    public override void UpdateMehod()
    {
        bool isturn = player.GetComponent<SpriteRenderer>().flipX;
        if (isturn)
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        else
            gameObject.transform.eulerAngles = Vector3.zero;
    }
}
