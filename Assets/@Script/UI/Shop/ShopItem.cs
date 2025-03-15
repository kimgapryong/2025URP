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
    public int upgradeCount;
    int maxUpgrade;

    #region 아이템들 UI
    public Image itemSp;
    public Text itemName;

    #endregion

    public ItemBase[] items;
    GameObject[] upgrdebars;
    public GameObject test;
    public void StrInit()
    {
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

        test = GetObject((int)Objects.UpdgradeObject);
        for (int i = 0; i < items.Length; i++)
        {
            upgrdebars[i] = Manager.Resources.Instantiate("UI/Shop_UI/UpgradeBar",GetObject((int)Objects.UpdgradeObject).transform);
        }
    }

    //업그레이드 버튼
    public void BuyOrUpgrade()
    {
        if (upgradeCount > maxUpgrade - 1)
            return;

        upgradeCount++;

        //이미지 업그레이드 상한선 설정?
        if(upgradeCount + 1 <= maxUpgrade)
        {
            itemSp.sprite = items[upgradeCount].itemData.sprite;
            itemName.text = items[upgradeCount].itemData.name;
            upgrdebars[upgradeCount].GetComponent<Image>().color = Color.green;
        }


        Debug.Log("업그레이드 완료");
    }

}
