using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseContoller : MonoBehaviour
{
    public bool isFrist;
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        UpdateMehod();
    }

    public virtual bool Init()
    {
        if(!isFrist)
        {
            isFrist = true;
            return true;
        }

        return false;
    }

    public virtual void UpdateMehod()
    {

    }
}
