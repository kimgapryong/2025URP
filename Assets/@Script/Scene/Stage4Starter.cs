using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Starter : Stage1Starter
{
    public GameObject[] gameobj;

    public override bool Init()
    {
        base.Init();
        for(int i = 0; i < gameobj.Length; i++)
            gameobj[i].SetActive(false);

        return true;
    }

    public void SetBossMonster()
    {
        for (int i = 0; i < gameobj.Length; i++)
            gameobj[i].SetActive(true);
    }

}
