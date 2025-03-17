using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCanvas : UI_Base
{
    public override bool Init()
    {
        base.Init();
        gameObject.SetActive(false);

        return true;
    }
}
