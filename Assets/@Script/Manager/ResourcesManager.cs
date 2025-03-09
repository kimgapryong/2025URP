using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesManager 
{
    public T Load<T>(string path) where T : UnityEngine.Object
    {
        T obj = Resources.Load<T>($"Prefab/{path}");
        return obj;
    }
}
