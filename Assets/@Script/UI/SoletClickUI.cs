using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoletClickUI : UI_Base, IPointerClickHandler
{
    enum Images
    {
        Bg_Sprite,
        SelectBg,
        Sprite,
    }
    Image select;
    public override bool Init()
    {
        base.Init();

        Bind<Image>(typeof(Images));
        select = GetImage((int)Images.SelectBg);
        select.gameObject.SetActive(false);
        return true;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Å¬¸¯");
       
        foreach(var solet in Manager.Ui.soletClickUIs)
        {
            solet.DesableSelectBg();
        }
        select.gameObject.SetActive(true);
    }

    public void DesableSelectBg()
    {
        select.gameObject.SetActive(false);
    }
}
