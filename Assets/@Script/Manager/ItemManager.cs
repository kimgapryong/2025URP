using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ItemManager
{
    public void LoadPlayerItem(string itemName, SoletClickUI solet)
    {

        GameObject item = Manager.Resources.Load<GameObject>($"Item/PlayerItem/{itemName}");
        Debug.Log(Manager.Instance.player.transform.Find("WeponHole"));
        Debug.Log(item);
        GameObject paItem = Object.Instantiate(item, Manager.Instance.player.transform.Find("WeponHole"));

        ItemBase itemCom = paItem.GetComponent<ItemBase>();

        if (itemCom == null)
            return;

        if(solet.myItemBase != null)
        {
            Object.Destroy(solet.myItemBase.gameObject);
        }
        solet.myItemBase = itemCom;
        solet.SetBgSp(itemCom.itemData.sprite);

    }

    public void LoadBackItem(string itemName, Vector3 pos)
    {
        GameObject item = Manager.Resources.Load<GameObject>($"Item/PlayerItem/{itemName}");
        GameObject backItem = Object.Instantiate(item);
        backItem.name = itemName;
        backItem.transform.position = pos;
    }

    
}
