using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item Data", menuName = "Item Data")]
public class ItemData : ScriptableObject
{
    public string itemManagerName;
    public string itemName;
    public float atkTime;
    public float damage;

    public int money;
    public int itemWeight;
    public Sprite sprite;
}
[Serializable]
public class ItemDataGroup
{
    public Dfine.InvenItem invenItem;
    public ItemData[] items; 
}
