using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : ItemBase
{
    public override void ItemAblity()
    {
        player.text++;
        Debug.Log("���� ����� �ض�");
        Debug.Log("�� ȸ����");
    }
}
