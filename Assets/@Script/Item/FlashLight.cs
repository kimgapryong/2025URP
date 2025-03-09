using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : ItemBase
{
    public override void ItemAblity()
    {
        if(player.dir == Vector3.zero)
            return;

        //외워야 할것
        float angle = Mathf.Atan2(-player.dir.x, player.dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
  
