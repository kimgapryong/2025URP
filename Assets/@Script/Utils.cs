using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class Utils
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if(component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static T FindChild<T>(GameObject obj, string name) where T : Object
    {
        if(typeof(T) == typeof(GameObject))
        {
            foreach(Transform com in obj.GetComponentsInChildren<Transform>())
            {
                if(com.gameObject.name == name)
                    return com.gameObject as T;
            }
        }
        foreach(T com in obj.GetComponentsInChildren<T>())
        {
            if(com.name == name)

                return com;
        }

        return null;
    }

    public static List<T> FindAllChild<T>(this GameObject obj) where T : Component
    {
        List<T> list = new List<T>();
        foreach(T com in obj.GetComponentsInChildren<T>())
        {
            list.Add(com);
        }
        return list;
    }
}
