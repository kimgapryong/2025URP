using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class FlashLight : ItemBase
{
    public override void ItemAblity()
    {
        Debug.Log("�÷��� �ɷ�");
        Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("LightSwitch"));
        if (isEquer)
        {
            isEquer = false;
            gameObject.SetActive(false);
        }
        else
        {
            isEquer = true;
            gameObject.SetActive(true);
        }
    }

    public override void UpdateMehod()
    {
        if (player.dir == Vector3.zero)
            return;

        //�ܿ��� �Ұ�
        float angle = Mathf.Atan2(-player.dir.x, player.dir.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
  
