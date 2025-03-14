using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpCanvas : UI_Base
{
    Slider slider;

    enum Sliders
    {
        Hp_Slider,
    }
    public override bool Init()
    {
        base.Init();
        Bind<Slider>(typeof(Sliders));
        slider = GetSlider((int)Sliders.Hp_Slider);
        transform.parent.GetComponent<CreatureContoller>().hpAction = ChangeSlider;
        return true;
    }

    public void ChangeSlider(float curHp, float myMaxHp)
    {
        
        float sliderValue = Mathf.Max(curHp, 0);
        slider.value = sliderValue / myMaxHp;
    }
}
