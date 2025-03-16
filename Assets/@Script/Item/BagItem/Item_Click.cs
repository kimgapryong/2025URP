using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Click : Click_Base
{
    public override void ClickAction()
    {
        //���濡 �� �������� ������
        ItemBase item = myParent.GetComponent<ItemBase>();
        if (Manager.Ui.backpackSolet.Count > 0)
        {
            foreach (BackpackClickUI backClick in Manager.Ui.backpackSolet)
            {
                if(item.itemData.itemManagerName == backClick.name)
                {
                    Debug.LogWarning("�߰��� �߰�");
                    backClick.ItemNum++;
                    Manager.Game.BackpackWeight += item.itemData.itemWeight;
                    break;
                }
                else if (backClick.backCanvas.items.ContainsKey(item.name) == false && Manager.Game.CurrentBackCount < Manager.Game.BackpackCount)
                {
                    Debug.LogWarning("����� �����");
                    backClick.myItemBase = item;
                    
                    backClick.ItemName = item.itemData.itemName;
                    backClick.name = item.itemData.itemManagerName;
                    backClick.ItemNum++;

                    backClick.SetBgSp(item.itemData.sprite);

                    backClick.itemNameTxt.gameObject.SetActive(true);
                    backClick.itemNumTxt.gameObject.SetActive(true);

                    Manager.Game.BackpackWeight += item.itemData.itemWeight;
                    Manager.Game.CurrentBackCount++;
                    backClick.backCanvas.items.Add(item.itemData.itemManagerName, item);
                    break;
                }
                else
                {
                    if(backClick.backCanvas.items.TryGetValue(item.name, out ItemBase items))
                    {
                        Debug.Log(items);
                    }
                    //TODO���� ������ ���� �Ѱ� ǥ��

                }

            }
            player.currentClickAction = null;
            myParent.transform.position = new Vector3(500, 500);
        }

    }
}
