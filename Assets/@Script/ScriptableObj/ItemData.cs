using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
  
    public string itemName;
    public float atkTime;
    public float damage;
    public Sprite sprite;
}
[Serializable]
public class ItemDataGroup
{
    public Dfine.InvenItem invenItem;
    public ItemBase[] items; 
}
