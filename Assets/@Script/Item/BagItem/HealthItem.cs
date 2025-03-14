using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : ItemBase
{
    public override void ItemAblity()
    {
        player.text++;
        Debug.Log("여기 출력좀 해라");
        Debug.Log("피 회복함");
    }
}
