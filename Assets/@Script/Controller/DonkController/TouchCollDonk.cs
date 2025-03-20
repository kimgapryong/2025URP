using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCollDonk : TouchDonk
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if(player != null )
            player.PlayerDamage(this, damage);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
            player.PlayerDamage(this, damage);
    }
}
