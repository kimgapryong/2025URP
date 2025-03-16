using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public static class Utils
{
    public static T GetOrAddComponent<T>(this GameObject go) where T : Component
    {
        T component = go.GetComponent<T>();
        if(component == null)
            component = go.AddComponent<T>();
        return component;
    }

    public static T FindChild<T>(this GameObject obj, string name) where T : UnityEngine.Object
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

    public static void BindingBtn(this GameObject obj, Action action)
    {
        UI_EventHandle evt = obj.GetOrAddComponent<UI_EventHandle>();
        evt.clickAction -= action;
        evt.clickAction += action;
    }

    public static void AddPreatical(this GameObject obj, Vector3 dir, float damage, float speed, CreatureContoller creature)
    {
        Preatical preatical = obj.GetOrAddComponent<Preatical>();
        preatical.dir = dir;
        preatical.damage = damage;
        preatical.speed = speed;
        preatical.atker = creature;
    }
}
