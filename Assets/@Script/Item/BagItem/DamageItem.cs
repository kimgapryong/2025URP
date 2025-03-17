using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageItem : ItemBase
{
    public float damage;
    public float damTime;
    public override void ItemAblity()
    {
        if (player.damageCoroutine != null)
        {
            StopCoroutine(player.damageCoroutine);
            player.Damage -= damage;
        }
           
        player.damageCoroutine = StartCoroutine(AddDamage());
    }

    IEnumerator AddDamage()
    {
        player.Damage += damage;
        yield return new WaitForSeconds(damTime);
        player.Damage -= damage;
        player.damageCoroutine = null;
    }


}
