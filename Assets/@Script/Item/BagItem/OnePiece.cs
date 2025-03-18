using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePiece : ItemBase
{
    public GameObject myOne;
    public override void Init()
    {
        if(gameObject.CompareTag("OnePiece"))
            myOne = transform.Find("OnePieceSprite").gameObject;

        if (myOne != null )
            myOne.SetActive(false);
    }
    public override void ItemAblity()
    {
        gameObject.transform.parent = null;
        gameObject.transform.position = player.transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
    }
}
