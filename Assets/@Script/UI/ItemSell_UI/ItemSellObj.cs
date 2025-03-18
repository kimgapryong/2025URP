using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSellObj : UI_Base
{
    public BackpackClickUI myBag;
    private ItemData data;
   enum Images
    {
        ItemSprite,
    }
    enum Texts
    {
        ItemName,
        ItemPrice,
    }
    public void StartInit(BackpackClickUI myBag)
    {
      
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));

        this.myBag = myBag;
       
        data = myBag.myItemBase.itemData;

        GetImage((int)Images.ItemSprite).sprite = data.sprite;
        GetText((int)Texts.ItemName).text = $"{data.itemName} X{myBag.ItemNum}";

        StartCoroutine(GetPrice());
    }

    IEnumerator GetPrice()
    {
        int total = data.money * myBag.ItemNum;
        for(int i = 0; i <= total; i++)
        {
            GetText((int)Texts.ItemPrice).text = i.ToString();
            yield return null;
        }
    }
}
