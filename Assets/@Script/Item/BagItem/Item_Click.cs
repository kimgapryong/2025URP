using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Click : Click_Base
{
    public override void ClickAction()
    {
        //���濡 �� �������� ������
        throw new System.NotImplementedException();
    }

    protected abstract void UseItem();
}
