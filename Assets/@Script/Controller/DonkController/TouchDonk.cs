using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDonk : DonkController
{
    public override bool Init()
    {
        Damage = damage;
        return true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            player.PlayerDamage(this, damage);
    }
}
