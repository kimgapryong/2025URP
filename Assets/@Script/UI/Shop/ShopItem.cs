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

    #region 아이템들 UI
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

        //가장 처음 아이템 이미지 설정
        upgrdebars = new GameObject[items.Length];
        Debug.Log("rmxs");
        itemSp.sprite = items[0].itemData.sprite;
        itemName.text = items[0].itemData.name;

        for (int i = 0; i < items.Length; i++)
        {
            upgrdebars[i] = Manager.Resources.Instantiate("UI/Shop_UI/UpgradeBar",GetObject((int)Objects.UpdgradeObject).transform);
        }

        //초기 아이템 설정
        if (invenItem == Dfine.InvenItem.FlashLight || invenItem == Dfine.InvenItem.Sword)
            BuyOrUpgrade();
    }

    //업그레이드 버튼
    public void BuyOrUpgrade()
    {
        if (!isFirst)
        {
            isFirst = true;
            foreach (var so in Manager.Ui.soletClickUIs)
            {
                if (so.shopItem == null)
                {
                    so.shopItem = this;
                    mySolet = so;
                    GetText((int)Texts.UpgradeTxt).text = "강화";
                    break;
                }
            }
        }

        if (upgradeCount >= maxUpgrade - 1)
            return;

        upgradeCount++;

        //이미지 업그레이드 상한선 설정?
        if(upgradeCount < maxUpgrade)
        {
            if (upgradeCount  == maxUpgrade - 1)
                GetText((int)Texts.UpgradeTxt).text = "마지막";

            itemSp.sprite = items[upgradeCount].itemData.sprite;
            itemName.text = items[upgradeCount].itemData.name;
            upgrdebars[upgradeCount].GetComponent<Image>().color = Color.green;
        }

        Manager.Item.LoadPlayerItem(items[upgradeCount].itemData.itemManagerName, mySolet);

        Debug.Log("업그레이드 완료");
    }

}
