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

    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.CloseBtn).gameObject.BindingBtn(CloseShop);

        for(int i = 0; i < itemDatas.Count; i++)
        {
            ShopItem shopItem = Manager.Ui.CreateUI<ShopItem>("Shop_UI/ShopFragment", GetObject((int)Objects.Content).transform);
            shopItem.items = itemDatas[i].items;
            shopItem.StrInit();
 
        }

        return true;
    }

    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}
