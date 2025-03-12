using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item_Click : Click_Base
{
    public override void ClickAction()
    {
        //가방에 빈 공간으로 보내기
        throw new System.NotImplementedException();
    }

    protected abstract void UseItem();
}
