using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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

        }

       
        items.Add(itemCom);
    }

    public void LoadBackItem(string itemName, Vector3 pos)
    {
        GameObject item = Manager.Resources.Load<GameObject>($"Item/PlayerItem/{itemName}");
        GameObject backItem = Object.Instantiate(item);
        backItem.name = itemName;
        backItem.transform.position = pos;
    }

    
}
