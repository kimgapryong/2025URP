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

    public ItemData[] items;
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
        itemSp.sprite = items[0].sprite;
        itemName.text = items[0].name;

        for (int i = 0; i < items.Length; i++)
        {
            upgrdebars[i] = Manager.Resources.Instantiate("UI/Shop_UI/UpgradeBar",GetObject((int)Objects.UpdgradeObject).transform);
        }

        //초기 아이템 설정
        if (invenItem == Dfine.InvenItem.FlashLight || invenItem == Dfine.InvenItem.Sword || invenItem == Dfine.InvenItem.Bagpack)
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
                if (invenItem == Dfine.InvenItem.Breath || invenItem == Dfine.InvenItem.Bagpack)
                    break;

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

            itemSp.sprite = items[upgradeCount].sprite;
            itemName.text = items[upgradeCount].itemName;
            upgrdebars[upgradeCount].GetComponent<Image>().color = Color.green;
        }

        if(invenItem == Dfine.InvenItem.Bagpack)
        {
            
            if(Manager.Ui.Backpack != null)
                Destroy(Manager.Ui.Backpack.gameObject);

            GetText((int)Texts.UpgradeTxt).text = "강화";
            Manager.Game.BackpackCount = (int)items[upgradeCount].damage;
            Manager.Game.MaxBackpackWeight = items[upgradeCount].itemWeight;
            Manager.Ui.InvenCanvas.ReBack();
            return;
        }

        if(invenItem == Dfine.InvenItem.Breath)
        {
            player.MaxBreath = items[upgradeCount].itemWeight;
            player.CurrentBreath = items[upgradeCount].itemWeight;
            GetText((int)Texts.UpgradeTxt).text = "강화";
            return;
        }

        Manager.Item.LoadPlayerItem(items[upgradeCount].itemManagerName, mySolet);

        Debug.Log("업그레이드 완료");
    }

}
