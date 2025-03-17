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
            Manager.Ui.InvenCanvas.GetAllTxt("�ʿ� ������ ��ġ�� ǥ�õǾ����ϴ�");
        else
            Manager.Ui.InvenCanvas.GetAllTxt("������ �����ؾ� �� ������ ������ �巯���� ����");

    }
}

