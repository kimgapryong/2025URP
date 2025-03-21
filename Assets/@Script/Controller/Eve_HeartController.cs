using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eve_HeartController : FixMonsterController
{
    public int myCurID;
    public float speed;
    public override bool Init()
    {
        base.Init();
        Speed = speed;
        if(Manager.Stage.CheckStage(myCurID))
            Destroy(gameObject);
        return true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            player.Ondamage(this, Damage);
    }
}
