using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PlayerController : CreatureContoller
{
    public Action currentClickAction; //현재 아이템
    public Action itemClickAction; //아이템 클릭
    public Action<float, float> breathAction; //플레이어 산소 게이지

    public Transform itemHole;
    public Transform weaponHole;

    public bool isRole;  //은신
    public bool isGod; //무적

    #region 아이템 코루틴
    public Coroutine godCoroutine;
    public Coroutine whiteCoroutine;
    public Coroutine speedCoroutine;
    public Coroutine damageCoroutine;

    #endregion
    #region 산소 게이지
    private float _curBreath;
    public float CurrentBreath
    {
        get
        {
            return _curBreath;
        }
        set
        {
            _curBreath = value;
            breathAction?.Invoke(value, MaxBreath);
        }
    }

    public float MaxBreath { get; set; } = 100f;
    #endregion

    public float atkTime;
    public override bool Init()
    {
        base.Init();

        state = Dfine.State.Move;
        CurrentBreath = MaxBreath;
        itemHole = transform.Find("ItemHole");
        weaponHole = transform.Find("WeponHole");
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


            //if (myCurItem != null)
            //    myCurItem.ItemAblity();
            itemAction?.Invoke();

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentClickAction?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Stage0");
        }
    }

    public override void Ondamage(CreatureContoller attker, float damage)
    {
        if (damageCool || isGod)
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
    public override void Moving()
    {
        transform.position += dir * Speed * Time.deltaTime;
    }

    public void PlayerClear()
    {
        Speed = creatureData.speed;
        Damage = creatureData.damage;
    }
}
