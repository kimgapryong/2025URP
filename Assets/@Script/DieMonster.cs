using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieMonster : MonoBehaviour
{
    public RandomMonsterSpwan randSpwan;

    private void OnDestroy()
    {
        randSpwan.monsterCount--;
        randSpwan.curMonster--;
    }
}
