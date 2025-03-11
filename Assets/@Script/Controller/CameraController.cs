using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseContoller
{
    public PlayerController player;
    public float smoothSpeed;

    private float shakeTime = 0.2f;
    private float shakeForce = 0.1f;
    private Vector3 op;

    public override bool Init()
    {
        base.Init();
        
        return true;
    }
    
    public void StartShake()
    {
        op = transform.localPosition;
        StartCoroutine(ShakeCam());
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }

    IEnumerator ShakeCam()
    {
        float eskape = 0f;
        while(eskape < shakeTime)
        {
            float x = Random.Range(-1f, 1f) * shakeForce;
            float y = Random.Range(-1f, 1f) * shakeForce;

            transform.localPosition = op + new Vector3(x, y);
            eskape += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = op;
    }

}

