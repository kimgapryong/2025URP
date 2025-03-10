using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Starter : MonoBehaviour
{
    public Vector3 strPos = new Vector3(0.5f, -0.1f);
    private void Start()
    {
        Manager.Instance.player.transform.position = strPos;
    }
}
