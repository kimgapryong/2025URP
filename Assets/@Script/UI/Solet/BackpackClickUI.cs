using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackpackClickUI : SoletClickUI
{
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
        CheckSprite();

        //플레이어 아이템 장착 델리게이트
        onItemClick?.Invoke(myItemBase);
    }
    public void ChangeItemNum(int number)
    {
        itemNumTxt.text = number.ToString();
    }
    public void ChangeItemName(string name)
    {
        if(ItemName == name) return;
        itemNameTxt.text = name;
    }
}
