using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenCanvas : UI_Base
{
    enum Images
    {
        InvenBackground,
    }
    enum Objects
    {
        InvenBackground,
    }
    enum Sliders
    {
        Hp_Slider,
        Breath_Slider,
    }

    Slider hpSlider;
    Slider brSlider;

    private int maxPanelCount = 6;
    public override bool Init()
    {
        base.Init();
        
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Objects));
        Bind<Slider>(typeof(Sliders));

        hpSlider = GetSlider((int)Sliders.Hp_Slider);
        brSlider = GetSlider((int)Sliders.Breath_Slider);

        player.hpAction = Hp_UI;
        player.breathAction = Breath_UI;

        for (int  i = 0; i < maxPanelCount; i ++)
        {
            Manager.Ui.soletClickUIs.Add(Manager.Ui.CreateUI<SoletClickUI>("Bg_panel", GetObject((int)Objects.InvenBackground).transform));
            //Instantiate(ui_Panel, GetObject((int)Objects.InvenBackground).transform);
        }

        // 플레이어 start 아이템 설정
        Manager.Item.Init();
        Manager.Item.LoadPlayerItem("LightHandle");
        Manager.Item.LoadPlayerItem("Sword1");
        return true;
    }

    #region 플레이어 슬라이더 관리
    public void Hp_UI(float cur, float max)
    {
        float sliderValue = Mathf.Max(cur, 0);
        hpSlider.value = sliderValue / max;
    }

    public void Breath_UI(float cur, float max)
    {
        Debug.Log(max);
        float sliderValue = Mathf.Max(cur, 0);
        brSlider.value = sliderValue / max;
    }
    #endregion

    #region 플레이어 가방 관련

    #endregion
}
