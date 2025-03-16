using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : UI_Base
{
    public List<ItemDataGroup> itemDatas = new List<ItemDataGroup>();
    
    enum Objects
    {
        Content,
    }
    enum Buttons
    {
        CloseBtn
    }
    enum Texts
    {
        Money,
    }
    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        GetButton((int)Buttons.CloseBtn).gameObject.BindingBtn(CloseShop);

        Manager.Game.moneyAction = ChagneMoney;
        Manager.Game.Money = 0;

        for(int i = 0; i < itemDatas.Count; i++)
        {
            ShopItem shopItem = Manager.Ui.CreateUI<ShopItem>("Shop_UI/ShopFragment", GetObject((int)Objects.Content).transform);
            shopItem.items = itemDatas[i].items;
            shopItem.StrInit(i, itemDatas[i].invenItem);
        }
        
        //처음에는 상점 끄기
        CloseShop();

        return true;
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }

    public void ChagneMoney(int money)
    {
        GetText((int)Texts.Money).text = money.ToString();
    }
}
