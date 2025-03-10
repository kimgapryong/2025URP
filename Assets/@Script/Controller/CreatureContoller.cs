using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureContoller : BaseContoller
{
    public ItemBase myCurItem;
    public bool damageCool;
    public float atkCoolTime = 0.4f;

    public bool isDie;

    private Vector3 _dir;
    public Vector3 dir { get { return _dir; } set { _dir = value.normalized; } }
    public CreatureData creatureData;
    public Animator animator;

    #region ĳ������ �������ͽ�
    public float CurrentHp { get; set; }    
    public float Hp {  get; set; }

    public float Damage { get; set; }   
    public float Speed {  get; set; }

    #endregion

    private Dfine.State _state;
    public Dfine.State state
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
            ChangeAnim(value);
        }
    }

    public override bool Init()
    {
        base.Init();
        animator = GetComponent<Animator>();
        Hp = creatureData.hp;
        CurrentHp = Hp;

        Damage = creatureData.damage;
        Speed = creatureData.speed;

        return true;
    }
    public override void UpdateMehod()
    {
        UseItem();
        GetComponent<SpriteRenderer>().flipX = dir.x < 0 ? true : dir.x > 0 ? false : GetComponent<SpriteRenderer>().flipX;

        switch (state)
        {
            case Dfine.State.Idle:
                Idle();
                break;

            case Dfine.State.Move:
                Moving();
                break;

            case Dfine.State.Attack:
                Attack();
                break;
        }
    }
    public virtual void Ondamage(CreatureContoller attker, float damage)
    {
        if (damageCool)
            return;

        damageCool = true;

        CurrentHp -= damage;
        if (CurrentHp <= 0 && !isDie)
        {
            isDie = true;
            OnDie();
        }
            
        StartCoroutine(waitCoolTime());
    }
    public virtual void OnDie()
    {
        Debug.Log("�� �׾���");
    }
    IEnumerator waitCoolTime()
    {
        yield return new WaitForSeconds(atkCoolTime);
        damageCool = false;
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


    //���߿� abstract�� �ٲٱ�
    public virtual void ChangeAnim(Dfine.State state) { }
    public virtual void UseItem() { }
    public virtual void Moving() { }
    public virtual void Idle() { }
    public virtual void Attack() { }
}
