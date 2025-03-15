using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : UI_Base
{
    enum Images
    {
        ItemSprite,
    }
    enum Objects
    {
        UpdgradeObject,
    }
    enum Buttons
    {
        UpgradeBtn
    }
    enum Texts
    {
        UpgradeTxt,
        ItemName,
    }

    private int itemID;
    public Dfine.InvenItem invenItem;
    public int upgradeCount;
    int maxUpgrade;

    #region �����۵� UI
    public Image itemSp;
    public Text itemName;

    #endregion

    private bool isFirst;

    public ItemBase[] items;
    GameObject[] upgrdebars;
    public SoletClickUI mySolet;
    public void StrInit(int myItemID, Dfine.InvenItem inven)
    {
        itemID = myItemID;
        invenItem = inven;

        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Objects));
        Bind<Button>(typeof(Buttons));
        Bind<Text>(typeof(Texts));

        itemSp = GetImage((int)Images.ItemSprite);
        itemName = GetText((int)Texts.ItemName);
        Debug.Log(items.Length);
        GetButton((int)Buttons.UpgradeBtn).gameObject.BindingBtn(BuyOrUpgrade);
     
        maxUpgrade = items.Length;
        upgradeCount = -1;

        //���� ó�� ������ �̹��� ����
        upgrdebars = new GameObject[items.Length];
        Debug.Log("rmxs");
        itemSp.sprite = items[0].itemData.sprite;
        itemName.text = items[0].itemData.name;

        for (int i = 0; i < items.Length; i++)
        {
            upgrdebars[i] = Manager.Resources.Instantiate("UI/Shop_UI/UpgradeBar",GetObject((int)Objects.UpdgradeObject).transform);
        }
    }

    //���׷��̵� ��ư
    public void BuyOrUpgrade()
    {
        if (!isFirst)
        {
            isFirst = true;
            Queue<SoletClickUI> solet = new Queue<SoletClickUI>(Manager.Ui.soletClickUIs);
            foreach(var so in solet)
            {
                if(so.shopItem == null)
                {
                    so.shopItem = this;
                    mySolet = so;
                    GetText((int)Texts.UpgradeTxt).text = "��ȭ";
                    break;
                }
            }
        }

        if (upgradeCount >= maxUpgrade - 1)
            return;

        upgradeCount++;

        //�̹��� ���׷��̵� ���Ѽ� ����?
        if(upgradeCount < maxUpgrade)
        {
            if (upgradeCount  == maxUpgrade - 1)
                GetText((int)Texts.UpgradeTxt).text = "������";

            itemSp.sprite = items[upgradeCount].itemData.sprite;
            itemName.text = items[upgradeCount].itemData.name;
            upgrdebars[upgradeCount].GetComponent<Image>().color = Color.green;
        }


        Debug.Log("���׷��̵� �Ϸ�");
    }

}
