using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemBase
{
    public float setSpeed;
    public float speedTime;
    public override void ItemAblity()
    {
        StartCoroutine(SpeedPlus());
    }

    public IEnumerator SpeedPlus()
    {
        Debug.Log("���ǵ� ����");
        player.Speed += setSpeed;
        yield return new WaitForSeconds(speedTime);
        player.Speed -= setSpeed;
    }
}
