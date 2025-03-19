using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public HashSet<SoletClickUI> soletClickUIs = new HashSet<SoletClickUI>();
    public List<BackpackClickUI> backpackSolet = new List<BackpackClickUI>();
    public BackpackCanvas Backpack { get; set; } = null;
    public InvenCanvas InvenCanvas { get; set; }
    public ShopCanvas Shop { get; set; }
    public MiniMapCanvas MiniMapCanvas { get; set; }
    public ItemSellCanvas ItemSell { get; set; }
    
    public T CreateUI<T>(string path, Transform trans = null) where T : Component
    {
        GameObject canvas = Manager.Resources.Load<GameObject>($"UI/{path}");
        GameObject clone = Object.Instantiate(canvas);
        clone.name = canvas.name;
        clone.transform.parent = trans; 
        T com = clone.GetOrAddComponent<T>();

        return com;
    }
}
