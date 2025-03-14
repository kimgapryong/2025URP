using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                if(item.itemData.name == backClick.ItemName)
                {
                    Debug.Log(backClick.ItemNum);
                    backClick.ItemNum++;
                    break;
                }
                else if (backClick.myItemBase == null)
                {
                    backClick.myItemBase = item;
                    backClick.ItemName = item.itemData.name;
                    backClick.ItemNum++;

                    backClick.SetBgSp(item.itemData.sprite);

                    backClick.itemNameTxt.gameObject.SetActive(true);
                    backClick.itemNumTxt.gameObject.SetActive(true);
                    break;
                }
                else
                {
                    //TODO가방 공간이 부족 한걸 표현
                    
                }
            }
            player.currentClickAction = null;
            Destroy(myParent);
        }

    }
}
