using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteItem : ItemBase
{
    public override void ItemAblity()
    {
        if (player.whiteCoroutine != null)
            StopCoroutine(player.whiteCoroutine);

        player.whiteCoroutine = StartCoroutine(AddWhite());
    }

    IEnumerator AddWhite()
    {
        player.isRole = true;
        player.GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.4f);
        yield return new WaitForSeconds(7);
        player.isRole = false;
        player.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        player.whiteCoroutine = null;
    }
}
