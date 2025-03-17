using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : ItemBase
{
    public override void ItemAblity()
    {
        if (Manager.Ui.MiniMapCanvas == null)
            return;

        if(Manager.Ui.MiniMapCanvas.gameObject.activeSelf == false )
            Manager.Ui.MiniMapCanvas.gameObject.SetActive(true);
        else
            Manager.Ui.MiniMapCanvas.gameObject.SetActive(false);
    }
}
