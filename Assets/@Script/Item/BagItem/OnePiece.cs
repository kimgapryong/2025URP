using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePiece : ItemBase
{
    public GameObject myOne;
    public override void Init()
    {
        myOne = transform.Find("OnePieceSprite").gameObject;
        myOne.SetActive(false);
    }
    public override void ItemAblity()
    {
        Debug.Log("보물이다");
    }
}
