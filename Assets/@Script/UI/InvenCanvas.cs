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
    

    private int maxPanelCount = 6;
    public override bool Init()
    {
        base.Init();
        
        Bind<Image>(typeof(Images));
        Bind<GameObject>(typeof(Objects));

        for(int  i = 0; i < maxPanelCount; i ++)
        {
            Manager.Ui.soletClickUIs.Add(Manager.Ui.CreateUI<SoletClickUI>("Bg_panel", GetObject((int)Objects.InvenBackground).transform));
            //Instantiate(ui_Panel, GetObject((int)Objects.InvenBackground).transform);
        }

        return true;
    }
}
