using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Base : MonoBehaviour
{
    private bool isFirst;
    Dictionary<Type, UnityEngine.Object[]> typeDic = new Dictionary<Type, UnityEngine.Object[]>();
    public PlayerController player;
    private void Awake()
    {
        Init();
    }

    public virtual bool Init()
    {
        if(!isFirst)
        {
            isFirst = true;
            player = Manager.Instance.player;
            return true;
        }

        return false;
    }

    protected void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);
 
        UnityEngine.Object[] objs = new UnityEngine.Object[names.Length];

        for(int i = 0; i < names.Length; i++)
        {
            objs[i] = gameObject.FindChild<T>(names[i]);
        }
        typeDic.Add(typeof(T), objs);
    }

    protected T Get<T>(int key) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objs = null;

        if (typeDic.TryGetValue(typeof(T), out objs))
            return objs[key] as T;

        return null;
    }

    protected Image GetImage(int key)
    {
        return Get<Image>(key);
    }
    protected GameObject GetObject(int key)
    {
        return Get<GameObject>(key);    
    }
    protected Slider GetSlider(int key)
    {
        return Get<Slider>(key);
    }
}
