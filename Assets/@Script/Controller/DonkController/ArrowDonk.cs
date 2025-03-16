using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDonk : DonkController
{
    public GameObject arrow;
    public Vector3 atkDir;

    public override bool Init()
    {
        Damage = damage;
        StartCoroutine(StartAtkTime());
        return true;
    }

    public override IEnumerator StartAtkTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            GameObject clone = Instantiate(arrow);
            clone.transform.position = transform.position;
            clone.AddPreatical(atkDir, Damage, 15, this);
        }
      
    }

}
