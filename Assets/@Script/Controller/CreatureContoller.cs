using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureContoller : BaseContoller
{

    public Action<float, float> hpAction;

    public Action itemAction;
    //public ItemBase myCurItem;
    public bool damageCool;
    public float atkCoolTime = 1f;

    public bool isDie;

    private Vector3 _dir;
    public Vector3 dir { get { return _dir; } set { _dir = value.normalized; } }
    public CreatureData creatureData;
    public Animator animator;

    #region 캐릭터의 스테이터스
    private float _cur;
    public float CurrentHp
    {
        get
        {
            return _cur;
        }
        set
        {
            _cur = value;
            hpAction?.Invoke(value, Hp);
        }
    }
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
       // GetComponent<SpriteRenderer>().flipX = dir.x < 0 ? true : dir.x > 0 ? false : GetComponent<SpriteRenderer>().flipX;
       transform.eulerAngles = dir.x > 0 ? Vector3.zero : dir.x < 0 ? new Vector3(0,-180,0) : transform.eulerAngles;

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

        //if(attker.GetType() == typeof(PlayerController))
        //    transform.Find("HpCanvas").GetComponent<HpCanvas>().ChangeSlider(CurrentHp, Hp);

        if (CurrentHp <= 0 && !isDie)
        {
            isDie = true;
            OnDie();
        }
            
        StartCoroutine(waitCoolTime());
    }
    public virtual void OnDie()
    {
        Debug.Log("난 죽었다");
    }
    IEnumerator waitCoolTime()
    {
        yield return new WaitForSeconds(atkCoolTime);
        damageCool = false;
    }

    //나중에 abstract로 바꾸기
    public virtual void ChangeAnim(Dfine.State state) { }
    public virtual void UseItem() { }
    public virtual void Moving() { }
    public virtual void Idle() { }
    public virtual void Attack() { }
}
