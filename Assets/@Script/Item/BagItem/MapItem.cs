using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : ItemBase
{
    GameObject onePiece;

    public void SetOnePiece(GameObject obj)
    {
        onePiece = obj;
    }
    public override void ItemAblity()
    {
        onePiece = GameObject.FindGameObjectWithTag("OnePiece");
        if(onePiece == null )
            return;

        onePiece.GetComponent<OnePiece>().myOne.gameObject.SetActive(true);

        if (Manager.Instance.player.weaponHole.Find("MiniMap"))
            Manager.Ui.InvenCanvas.GetAllTxt("맵에 보물에 위치가 표시되었습니다");
        else
            Manager.Ui.InvenCanvas.GetAllTxt("지도를 구입해야 이 물약의 진가가 드러날것 같아");

    }
}

