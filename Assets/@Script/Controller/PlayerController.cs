using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : CreatureContoller
{
    public int text = 0;
    public Action currentClickAction; //���� ������
    public Action itemClickAction; //������ Ŭ��
    public Action<float, float> breathAction; //�÷��̾� ��� ������

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
        CurrentBreath = MaxBreath;
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
    }
    public override void Moving()
    {
        transform.position += dir * creatureData.speed * Time.deltaTime;
    }
}
