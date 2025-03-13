using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public HashSet<SoletClickUI> soletClickUIs = new HashSet<SoletClickUI>();
    public HashSet<SoletClickUI> backpackSolet = new HashSet<SoletClickUI>();
    public BackpackCanvas Backpack { get; set; }
    
    public T CreateUI<T>(string path, Transform trans = null) where T : Component
    {
 
        GameObject canvas = Manager.Resources.Load<GameObject>($"UI/{path}");
        GameObject clone = Object.Instantiate(canvas);
        clone.name = canvas.name;
        clone.transform.parent = trans; 
        T com = clone.GetOrAddComponent<T>();

        if (typeof(T) == typeof(BackpackCanvas))
            Backpack = com as BackpackCanvas;

        return com;
    }
}
