using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eve_HeartController : FixMonsterController
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            player.Ondamage(this, Damage);
    }
}
