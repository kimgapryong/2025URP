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

    int nextCount = 0;
    public int upgradeCount;
    int maxUpgrade;

    #region �����۵� UI
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

        //���� ó�� ������ �̹��� ����
        upgrdebars = new GameObject[items.Length];
        Debug.Log("rmxs");
        itemSp.sprite = items[0].sprite;
        itemName.text = items[0].name;

        for (int i = 0; i < items.Length; i++)
        {
            upgrdebars[i] = Manager.Resources.Instantiate("UI/Shop_UI/UpgradeBar",GetObject((int)Objects.UpdgradeObject).transform);
        }

        //�ʱ� ������ ����
        if (invenItem == Dfine.InvenItem.FlashLight || invenItem == Dfine.InvenItem.Sword || invenItem == Dfine.InvenItem.Bagpack)
            BuyOrUpgrade();
    }

    //���׷��̵� ��ư
    public void BuyOrUpgrade()
    {
        
        if (upgradeCount >= maxUpgrade)
            return;

        
        if (nextCount + 1 < maxUpgrade)
            nextCount++;

        if (items[upgradeCount + 1].money > Manager.Game.Money && !Manager.Game.CanShop)
        {
            Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("ItemNotBuy"));
            Manager.Ui.InvenCanvas.GetAllTxt("���� �����մϴ�");
            return;
        }

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
                    Debug.Log(so);
                    mySolet = so;
                    GetText((int)Texts.UpgradeTxt).text = items[nextCount].money.ToString();
                    break;
                }
            }
        }

        upgradeCount++;

        //�̹��� ���׷��̵� ���Ѽ� ����?
        if(upgradeCount < maxUpgrade)
        {
            if (upgradeCount  == maxUpgrade - 1)
                GetText((int)Texts.UpgradeTxt).text = "������";

            itemSp.sprite = items[upgradeCount].sprite;
            itemName.text = items[upgradeCount].itemName;
            upgrdebars[upgradeCount].GetComponent<Image>().color = Color.green;
        }

        if(invenItem == Dfine.InvenItem.Bagpack)
        {
            GetText((int)Texts.UpgradeTxt).text = items[nextCount].money.ToString();
            Manager.Game.BackpackCount = (int)items[upgradeCount].damage;
            Manager.Game.MaxBackpackWeight = items[upgradeCount].itemWeight;
            Manager.Game.Money -= items[upgradeCount].money;
            Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("ItemBuy"));
            Manager.Ui.InvenCanvas.ReBack();
            return;
        }

        if(invenItem == Dfine.InvenItem.Breath)
        {
            player.MaxBreath = items[upgradeCount].itemWeight;
            player.CurrentBreath = items[upgradeCount].itemWeight;
            Manager.Game.Money -= items[upgradeCount].money;
            GetText((int)Texts.UpgradeTxt).text = items[nextCount].money.ToString();


            Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("ItemBuy"));
            return;
        }

        Manager.Item.LoadPlayerItem(items[upgradeCount].itemManagerName, mySolet);
        Manager.Game.Money -= items[upgradeCount].money;
        GetText((int)Texts.UpgradeTxt).text = items[nextCount].money.ToString();

        Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("ItemBuy"));
    }

}
