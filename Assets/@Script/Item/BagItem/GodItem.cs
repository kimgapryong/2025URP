using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodItem : ItemBase
{
    public override void ItemAblity()
    {
        if (player.godCoroutine != null)
            StopCoroutine(player.godCoroutine);

        player.godCoroutine = StartCoroutine(AddGod());
    }

    IEnumerator AddGod()
    {
        player.isGod = true;
        yield return new WaitForSeconds(7);
        player.isGod = false;
        player.godCoroutine = null;
    }
}
