using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoletClickUI : UI_Base, IPointerClickHandler
{
    public ItemBase myItemBase = null;
    public Action<ItemBase> onItemClick;
    enum Images
    {
        Bg_Sprite,
        SelectBg,
        Sprite,
    }

    public Image select;
    public Image bgSp;
    public Image itemSp;
    public override bool Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        select = GetImage((int)Images.SelectBg);
        bgSp = GetImage((int)Images.Bg_Sprite);
        itemSp = GetImage((int)Images.Sprite);

        select.gameObject.SetActive(false);
        bgSp.gameObject.SetActive(false);
        itemSp.gameObject.SetActive(false);
        
        return true;
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ŭ��");
        foreach(var solet in Manager.Ui.soletClickUIs)
        {
            solet.DesableSelectBg();
        }
        select.gameObject.SetActive(true);
        CheckSprite();

        //�÷��̾� ������ ���� ��������Ʈ
        //onItemClick?.Invoke(myItemBase);
        if(myItemBase == null)
        {
            player.itemAction = null;
            return;
        }
        player.itemAction = myItemBase.ItemAblity;
    }

    public void DesableSelectBg()
    {
        select.gameObject.SetActive(false);
    }

    public void CheckSprite()
    {
        if (bgSp.sprite != null)
        {
            if (itemSp.sprite != null)
                return;

            itemSp.sprite = bgSp.sprite;
            itemSp.gameObject.SetActive(true);
        }
    }

    public void SetBgSp(Sprite sprite)
    {
        bgSp.gameObject.SetActive(true);
        bgSp.sprite = sprite;
    }
}
