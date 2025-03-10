using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseContoller
{
    public PlayerController player;
    public float smoothSpeed;
    public override bool Init()
    {
        base.Init();
        
        return true;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}

