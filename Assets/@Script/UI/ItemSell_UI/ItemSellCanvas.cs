using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemSellCanvas : UI_Base
{
    enum Objects
    {
        ItemSellsObj,
    }
    enum Buttons
    {
        GetItemPrice,
    }
    public GameObject itemSellsObj;
    public int totalMoney;
    public override bool Init()
    {
        base.Init();

        Bind<GameObject>(typeof(Objects));
        Bind<Button>(typeof(Buttons));

        itemSellsObj = GetObject((int)Objects.ItemSellsObj);
        GetButton((int)Buttons.GetItemPrice).gameObject.BindingBtn(ResetSellObj);

        gameObject.SetActive(false);

        return true;
    }

    public void SellItem()
    {
        gameObject.SetActive(true);
        StartCoroutine(SpwanTime());
    }

    IEnumerator SpwanTime()
    {
        foreach (var bag in Manager.Ui.backpackSolet)
        {
            ItemSellObj items = Manager.Ui.CreateUI<ItemSellObj>("ItemSell_UI/ItemSellObj",itemSellsObj.transform);
            items.StartInit(bag);
            yield return new WaitForSeconds(1.2f);
        }
    }

    private void ResetSellObj()
    {
        foreach (var bag in Manager.Ui.backpackSolet)
        {
            totalMoney += bag.myItemBase.itemData.money * bag.ItemNum;
        }
        Manager.Game.Money += totalMoney; 
        totalMoney = 0; 

        foreach(var trans in itemSellsObj.GetComponentsInChildren<Transform>().Skip(1))
        {
            Destroy(trans.gameObject);
        }

        Manager.Ui.Backpack.items.Clear();
        Manager.Ui.InvenCanvas.ReBack();
        gameObject.SetActive(false);
    }
}
