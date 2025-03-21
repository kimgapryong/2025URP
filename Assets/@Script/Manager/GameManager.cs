using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public Action<int> backpackWeightAction;
    public Action<int> moneyAction;


    public int Score { get; set; } = 2000;
    #region 가방 무게와 칸수
    public int CurrentBackCount { get; set; }   
    public int BackpackCount { get; set; } = 6;

    public bool CanShop { get; set; }  = false;
    public int MaxBackpackWeight { get; set; }
    private int _backWeigth = 0;
    public int BackpackWeight
    {
        get
        {
            return _backWeigth;
        }

        set
        {
            _backWeigth = value;
            backpackWeightAction?.Invoke(value);
        }
    }

    #endregion

    #region
    private int _money;
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            moneyAction?.Invoke(value);
        }
    }
    #endregion
}
