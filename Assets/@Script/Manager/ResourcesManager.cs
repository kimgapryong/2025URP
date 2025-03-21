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
    public AudioClip LoadAudio(string path)
    {
        AudioClip audio = Resources.Load<AudioClip>($"Sounds/{path}");
        return audio;
    }
    public GameObject Instantiate(string name, Transform trans = null)
    {
        GameObject obj = Load<GameObject>(name);

        GameObject clone = Object.Instantiate(obj);
        clone.name = obj.name;
        clone.transform.parent = trans;
        
        return clone;
    }
}
