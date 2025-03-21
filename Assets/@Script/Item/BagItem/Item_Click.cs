using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Click : Click_Base
{
    public override void ClickAction()
    {
        //가방에 빈 공간으로 보내기
        ItemBase item = myParent.GetComponent<ItemBase>();
        if (Manager.Ui.backpackSolet.Count > 0)
        {
            foreach (BackpackClickUI backClick in Manager.Ui.backpackSolet)
            {
                if(item.itemData.itemManagerName == backClick.backName)
                {
                    Debug.Log("dhodkdss");
                    backClick.ItemNum++;
                    Manager.Game.BackpackWeight += item.itemData.itemWeight;
                    break;
                }
                else if (backClick.backCanvas.items.ContainsKey(item.itemData.itemManagerName) == false && Manager.Game.CurrentBackCount < Manager.Game.BackpackCount && backClick.myItemBase == null)
                {
                    backClick.myItemBase = item;
                    
                    backClick.ItemName = item.itemData.itemName;
                    backClick.backName = item.itemData.itemManagerName;
                    backClick.ItemNum++;

                    backClick.SetBgSp(item.itemData.sprite);

                    backClick.itemNameTxt.gameObject.SetActive(true);
                    backClick.itemNumTxt.gameObject.SetActive(true);

                    Manager.Game.BackpackWeight += item.itemData.itemWeight;
                    Manager.Game.CurrentBackCount++;
                    backClick.backCanvas.items.Add(item.itemData.itemManagerName, item);
                    break;
                }
                else if (Manager.Game.CurrentBackCount >= Manager.Game.BackpackCount)
                {
                    Manager.Ui.InvenCanvas.GetAllTxt("가방 공간이 가득 찼습니다");
                    return;
                }
            }
            Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("ItemGetSound"));
            player.currentClickAction = null;
            myParent.transform.SetParent(Manager.Instance.player.itemHole);
            myParent.transform.position = new Vector3(500, 500);
        }

    }
}
