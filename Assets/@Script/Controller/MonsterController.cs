using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : CreatureContoller
{
    public PlayerController player;
    private Rigidbody2D rigid;
    public bool isBack;
    private float backPower = 14f;
    public override bool Init()
    {
        base.Init();
        state = Dfine.State.Idle;
        player = Manager.Instance.player;
        rigid = GetComponent<Rigidbody2D>();
        return true;
    }
    public override void Idle()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= creatureData.arange && !isBack) 
            state = Dfine.State.Move;
    }
    public override void Attack()
    {
        UseItem();
        state = Dfine.State.Idle;
    }
    public override void Moving()
    {
        dir = (player.transform.position - transform.position).normalized;

        if (Vector3.Distance(transform.position, player.transform.position) >= creatureData.arange)
        {
            state = Dfine.State.Idle;
            return;
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= creatureData.atkArange)
        {
            state = Dfine.State.Attack;
            return;
        }
        else
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position - new Vector3(0, 1,0), Time.deltaTime * Speed);
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CreatureContoller cur = collision.gameObject.GetComponent<CreatureContoller>();
        if (cur != null && !damageCool)
        {
            cur.Ondamage(this, Damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        CreatureContoller cur = collision.gameObject.GetComponent<CreatureContoller>();
        if (cur != null && !damageCool)
        {
            cur.Ondamage(this, Damage);
        }
    }

    public override void Ondamage(CreatureContoller attker, float damage)
    {
        BackMonster();
        base.Ondamage(attker, damage);
    }
    public override void OnDie()
    {
        Destroy(gameObject);   
    }

    private void BackMonster()
    {
        isBack = true;
        state = Dfine.State.Idle;
        player.GetComponent<Rigidbody2D>().isKinematic = true;    //외워야 할것
        rigid.AddForce(-dir * backPower, ForceMode2D.Impulse); //외워야 할것
        player.GetComponent<Rigidbody2D>().isKinematic = false;   //외워야 할것
        StartCoroutine(WaitSecond());
    }

    IEnumerator WaitSecond()
    {
        yield return new WaitForSeconds(0.6f);
        isBack = false;
        rigid.velocity = Vector3.zero;
        state = Dfine.State.Move;
    }
    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            CreatureContoller cur = collision.gameObject.GetComponent<CreatureContoller>();
            if (cur != null && !damageCool)
            {
                cur.Ondamage(this, Damage);
            }
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            CreatureContoller cur = collision.gameObject.GetComponent<CreatureContoller>();
            if (cur != null && !damageCool)
            {
                cur.Ondamage(this, Damage);
            }
        }*/

}
