using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Click : Click_Base
{
    public override void ClickAction()
    {
        //���濡 �� �������� ������
        ItemBase item = myParent.GetComponent<ItemBase>();
        Debug.Log(item);
        Debug.Log(myParent);
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
                else if (backClick.backCanvas.items.ContainsKey(item.name) == false && Manager.Game.CurrentBackCount < Manager.Game.BackpackCount)
                {
                    backClick.myItemBase = item;
                    
                    backClick.ItemName = item.itemData.name;
                    backClick.ItemNum++;

                    backClick.SetBgSp(item.itemData.sprite);

                    backClick.itemNameTxt.gameObject.SetActive(true);
                    backClick.itemNumTxt.gameObject.SetActive(true);

                    Manager.Game.CurrentBackCount++;
                    backClick.backCanvas.items.Add(item.name, item);
                    break;
                }
                else
                {
                    //TODO���� ������ ���� �Ѱ� ǥ��
                    
                }
            }
            player.currentClickAction = null;
            myParent.SetActive(false);
            //Destroy(myParent);
        }

    }
}
