using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage4Starter : Stage1Starter
{
    public List<GameObject> gameobj = new List<GameObject>();

    public override bool Init()
    {
        base.Init();
        for(int i = 0; i < gameobj.Count; i++)
        {
            gameobj[i].SetActive(false);
        }
           

        return true;
    }

    public void SetBossMonster()
    {
      
        if(gameobj.Count >= 2)
            for (int i = 0; i < 2; i++)
                gameobj[i].SetActive(true);

    }
    public void DelGameObj()
    {
        for (int i = 0; i < 2; i++)
        {
            gameobj[0].SetActive(false);
            gameobj.Remove(gameobj[0]);
        }
    }
}
