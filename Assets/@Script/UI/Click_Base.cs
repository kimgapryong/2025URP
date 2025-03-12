using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Click_Base : UI_Base
{
    enum Images
    {
        ClickImage,
    }
    Image curImage;
    public PlayerController player;
    public Transform playerTrans;

    public override bool Init()
    {
        base.Init();
        player = Manager.Instance.player;
        playerTrans = player.transform;
        Bind<Image>(typeof(Images));
        curImage = GetImage((int)Images.ClickImage);
        Debug.Log(curImage);
        return true;
    }

    private void Update()
    {
        
        if (curImage != null)
        {
            if (Vector3.Distance(playerTrans.position, transform.parent.position) <= 1.5f)
            {
                curImage.gameObject.SetActive(true);
                player.currentClickAction = ClickAction;
            }
            else
            {
                curImage.gameObject.SetActive(false);
                player.currentClickAction = null;
            }
        }
        UpdateMehod();
    }

    public virtual void UpdateMehod() { }
    public abstract void ClickAction();
       
}
