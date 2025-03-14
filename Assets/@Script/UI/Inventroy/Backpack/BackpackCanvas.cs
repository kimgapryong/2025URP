using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackpackCanvas : UI_Base
{
    public GameObject bg_Back;
    
    enum Objects
    {
        BackpackSort,
        Bg_Back,
    }

    public override bool Init()
    {
        base.Init();
        Bind<GameObject>(typeof(Objects));
        bg_Back = GetObject((int)Objects.BackpackSort);
        bg_Back.SetActive(true);

        for(int i = 0; i < Manager.Game.BackpackCount; i++)
        {
            Manager.Ui.backpackSolet.Add(Manager.Ui.CreateUI<BackpackClickUI>("Backpack_UI/Bg_Shop", bg_Back.transform));
        }
        return true;
    }
}
