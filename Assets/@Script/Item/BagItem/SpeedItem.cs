using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedItem : ItemBase
{
    public float setSpeed;
    public float speedTime;
    public override void ItemAblity()
    {
        if (player.speedCoroutine != null)
        {
            StopCoroutine(player.speedCoroutine);
            player.Speed -= setSpeed;
        }

        player.speedCoroutine = StartCoroutine(SpeedPlus());
    }

    public IEnumerator SpeedPlus()
    {
        player.Speed += setSpeed;
        yield return new WaitForSeconds(speedTime);
        player.Speed -= setSpeed;
        player.speedCoroutine = null;
    }
}
