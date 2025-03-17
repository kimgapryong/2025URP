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
    public ShopItem shopItem = null;
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
        foreach(var solet in Manager.Ui.soletClickUIs)
        {
            solet.DesableSelectBg();
        }
        select.gameObject.SetActive(true);
        if (myItemBase != null)
            myItemBase.gameObject.SetActive(true);

        if (myItemBase == null)
        {
            player.itemAction = null;
            return;
        }
        player.itemAction = myItemBase.ItemAblity;
    }

    public virtual void DesableSelectBg()
    {
        select.gameObject.SetActive(false);
        if(myItemBase != null && myItemBase.GetType() != typeof(FlashLight))
            myItemBase.gameObject.SetActive(false);
    }


    public void SetBgSp(Sprite sprite)
    {
        bgSp.sprite = sprite;
        itemSp.sprite = sprite;
        bgSp.gameObject.SetActive(true);
        itemSp.gameObject.SetActive(true);
    }
}
