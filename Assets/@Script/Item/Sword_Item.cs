using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Sword_Item : ItemBase
{
    public Collider2D coll;
    public bool isWait;
    public Coroutine _cor;


    public override void Init()
    {
        base.Init();
        coll = GetComponent<Collider2D>();
        coll.enabled = false;

        itemAudio = Manager.Resources.LoadAudio("PlayerHit2");
    }
    public override void ItemAblity()
    {
        if (!isWait)
        {
            if (_cor != null)
                StopCoroutine(WaitTime());

            _cor = StartCoroutine(WaitTime());
            Camera.main.GetComponent<CameraController>().StartShake();
        }
    }

    public IEnumerator WaitTime()
    {
        Manager.Instance.audioSource.PlayOneShot(itemAudio);

        isWait = true;
        coll.enabled = true;
        State = Dfine.ItemState.Play;
        yield return new WaitForSeconds(0.4f);
        coll.enabled = false;
        State = Dfine.ItemState.Idle;

        yield return new WaitForSeconds(itemData.atkTime);
        isWait = false;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreatureContoller cur = collision.gameObject.GetComponent<CreatureContoller>();
       
        if (cur != null)
            cur.Ondamage(player, itemData.damage);
    }

}
