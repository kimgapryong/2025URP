using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class FixMonsterController : CreatureContoller
{
    public Dfine.plaAtk plaAtk;

    public float moveDis;
    public Vector3 targetPos;
    public Vector3[] dirs = new Vector3[4]
    {
        Vector3.up,
        Vector3.left,
        Vector3.down,
        Vector3.right,
    };
    public int curDir = 0;

    public override bool Init()
    {
        base.Init();
        state = Dfine.State.Move;

        targetPos = transform.position + dirs[curDir] * moveDis;
        dir = dirs[curDir];
        curDir++;
        return true;
    }
    public override void UpdateMehod()
    {
        base.UpdateMehod();

        if(Vector3.Distance(transform.position, targetPos) <= 0.002f)
        {
            if (curDir >= dirs.Length)
                curDir = 0;

            targetPos = transform.position + dirs[curDir] * moveDis;
            dir = dirs[curDir];
            curDir++;
        }

    }
    public override void Moving()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (curDir >= dirs.Length)
                curDir = 0;

            targetPos = transform.position + dirs[curDir] * moveDis;
            curDir++;
        }

        PlayerController cur = collision.gameObject.GetComponent<PlayerController>();
        if (cur != null && !damageCool)
        {
            cur.PlayerDamage(this, Damage, plaAtk);
        }


    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (curDir >= dirs.Length)
                curDir = 0;

            targetPos = transform.position + dirs[curDir] * moveDis;
            curDir++;
        }
        PlayerController cur = collision.gameObject.GetComponent<PlayerController>();
        if (cur != null && !damageCool)
        {
            cur.PlayerDamage(this, Damage, plaAtk);
        }
    }
    public override void Ondamage(CreatureContoller attker, float damage)
    {
        Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("MonsterHit"));
        base.Ondamage(attker, damage);
    }
    public override void OnDie()
    {
        Manager.Instance.RanomSpwan.RandomItemSpwan(transform.position);
        Destroy(gameObject);
    }
}
