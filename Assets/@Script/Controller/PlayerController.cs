using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PlayerController : CreatureContoller
{
    public Action currentClickAction; //���� ������
    public Action itemClickAction; //������ Ŭ��

   
    public Action<float, float> breathAction; //�÷��̾� ��� ������

    public float maxSpeed;

    public Transform itemHole;
    public Transform weaponHole;

    public bool isRole;  //����
    public bool isGod; //����

    #region ������ �ڷ�ƾ
    public Coroutine godCoroutine;
    public Coroutine whiteCoroutine;
    public Coroutine speedCoroutine;
    public Coroutine damageCoroutine;

    #endregion
    #region ��� ������
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

        Manager.Game.BackpackWeight = 0;
        Debug.Log(Speed);
        maxSpeed = Speed;
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

        //�ܿ����� ��
        base.UpdateMehod();
    }

    public override void UseItem()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //�ܿ��� �Ұ�
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
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Stage4");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Stage5");
        }
    }

    public  void PlayerDamage(CreatureContoller attker, float damage, Dfine.plaAtk atk = Dfine.plaAtk.Health)
    {
        if (damageCool || isGod)
            return;

        damageCool = true;

        Manager.Game.Score--;
        if(atk == Dfine.plaAtk.Health)
            CurrentHp -= damage;
        else if(atk == Dfine.plaAtk.Breath)
            CurrentBreath -= damage;

        //if(attker.GetType() == typeof(PlayerController))
        //    transform.Find("HpCanvas").GetComponent<HpCanvas>().ChangeSlider(CurrentHp, Hp);

        if (CurrentHp <= 0 || CurrentBreath <= 0 && !isDie)
        {
            isDie = true;
            OnDie();
        }

        StartCoroutine(waitCoolTime());
    }

    public override void OnDie()
    {
        Manager.Ui.Die.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public override void Moving()
    {
        transform.position += dir * Speed * Time.deltaTime;
    }

    public void PlayerClear()
    {
        Speed = creatureData.speed;
        Damage = creatureData.damage;
        isGod = false;
        isRole = false;
    }

}
