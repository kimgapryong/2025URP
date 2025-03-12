using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Starter : Stage
{
    public Vector3 strPos = new Vector3(0.5f, -0.1f);

    public override bool Init()
    {
        base.Init();
        Manager.Instance.player.transform.position = strPos;
        return true;
    }
    
    
}
