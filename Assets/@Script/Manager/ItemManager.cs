using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    List<ItemBase> items = new List<ItemBase>();
    Queue<SoletClickUI> soQueue;

    public void Init()
    {
        soQueue = new Queue<SoletClickUI>(Manager.Ui.soletClickUIs);
    }
    public void LoadPlayerItem(string itemName)
    {

        GameObject item = Manager.Resources.Load<GameObject>($"Item/PlayerItem/{itemName}");
        GameObject paItem = Object.Instantiate(item, Manager.Instance.player.transform.Find("WeponHole"));

        ItemBase itemCom = paItem.GetComponent<ItemBase>();

        if (itemCom == null)
            return;

        if(soQueue.Count > 0)
        {
            SoletClickUI ui = soQueue.Dequeue();
            ui.myItemBase = itemCom;
            ui.SetBgSp(itemCom.itemData.sprite);

            ui.onItemClick -= EquierItem;
            ui.onItemClick += EquierItem;
        }

       
        items.Add(itemCom);
    }

    public void EquierItem(ItemBase item)
    {
        if(item is FlashLight)
        {
            Manager.Instance.player.myCurItem = item;
            return;
        }
        foreach (ItemBase itemCom in items)
        {
            if (itemCom is FlashLight)
                continue;
            
            itemCom.isEquer = false;
            itemCom.gameObject.SetActive(false);
        }
        item.isEquer = true;
        item.gameObject.SetActive(true);
        Manager.Instance.player.myCurItem = item;
    }
}
