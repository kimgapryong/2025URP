using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackpackClickUI : SoletClickUI
{
    public BackpackCanvas backCanvas;
    enum Texts
    {
        ItemNum,
        ItemName,
    }

    private int _item;
    public int ItemNum
    {
        get
        {
            return _item;
        }
        set
        {
            _item = value;
            ChangeItemNum(value);
        }
    }

    private string _itemName;
    public string ItemName
    {
        get
        {
            return _itemName;
        }
        set
        {
            _itemName = value;
            ChangeItemName(value);
        }
    }
    public string backName;
    public Text itemNumTxt;
    public Text itemNameTxt;
    public override bool Init()
    {
        base.Init();
        Bind<Text>(typeof(Texts));

        itemNumTxt = GetText((int)Texts.ItemNum);
        itemNameTxt = GetText((int)Texts.ItemName);
        ItemNum = 0;

        itemNameTxt.gameObject.SetActive(false);
        itemNumTxt.gameObject.SetActive(false);

        return true;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        foreach (var solet in Manager.Ui.backpackSolet)
        {
            solet.DesableSelectBg();
        }
        select.gameObject.SetActive(true);
        //CheckSprite();

        if (myItemBase == null)
            return;

        myItemBase.ItemAblity();

        //아이템 사용 
        ItemNum--;
        Manager.Game.BackpackWeight -= myItemBase.itemData.itemWeight;

        if(ItemNum <= 0) 
            ResetBagpack();
        
    }
    public override void DesableSelectBg()
    {
        select.gameObject.SetActive(false);
    }
    public void ResetBagpack()
    {
        backCanvas.items.Remove(backName);
        backName = null;

        myItemBase = null;

        bgSp.sprite = null;
        itemSp.sprite = null;

        itemNumTxt.gameObject.SetActive(false );    
        itemNameTxt.gameObject.SetActive(false);
        itemSp.gameObject.SetActive(false);
        bgSp.gameObject.SetActive(false);

        Manager.Game.CurrentBackCount--;
    }
    public void ChangeItemNum(int number)
    {
        itemNumTxt.text = number.ToString();
    }
    public void ChangeItemName(string name)
    {
        itemNameTxt.text = name;

    }
}
