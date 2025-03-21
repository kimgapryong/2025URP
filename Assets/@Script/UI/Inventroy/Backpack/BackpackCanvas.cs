using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackCanvas : UI_Base
{
    public GameObject bg_Back;
    public Text weight_txt;
    public Dictionary<string, ItemBase> items = new Dictionary<string, ItemBase>();
    public float plaCurSpeed;
    
    enum Objects
    {
        BackpackSort,
        Bg_Back,
    }
    enum Texts
    {
        Weight_Txt,
    }

    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));
        Bind<Text>(typeof(Texts));
        bg_Back = GetObject((int)Objects.BackpackSort);
        bg_Back.SetActive(true);

        weight_txt = GetText((int)Texts.Weight_Txt);
        Manager.Game.backpackWeightAction = ChangeWeight; //함수 등록
        Manager.Game.BackpackWeight = 0;                                                         
        plaCurSpeed = player.Speed;

        for(int i = 0; i < Manager.Game.BackpackCount; i++)
        {
            BackpackClickUI backpack = Manager.Ui.CreateUI<BackpackClickUI>("Backpack_UI/Bg_Shop", bg_Back.transform);
            backpack.backCanvas = this;
            Manager.Ui.backpackSolet.Add(backpack);
        }
        return true;
    }

    #region 가방 무게 관련 함수

    public void ChangeWeight(int weight)
    {
        if(weight > Manager.Game.MaxBackpackWeight )
        {
            Manager.Ui.InvenCanvas.GetAllTxt("가방이 너무 무겁습니다");
            Debug.Log(player.Speed);
            player.Speed -= (float)(weight - Manager.Game.MaxBackpackWeight) / 5;
            Debug.Log(player.Speed);
        }
        else
        {
            player.Speed = player.maxSpeed;
        }

        weight_txt.text = $"무게: {weight} / {Manager.Game.MaxBackpackWeight}";
    }

    #endregion
}
