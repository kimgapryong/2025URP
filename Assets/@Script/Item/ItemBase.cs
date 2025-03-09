using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemData itemData;
    public PlayerController player;
    private void Start()
    {
        Init();
    }
    public virtual void Init()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        ItemAblity();
    }
    public abstract void ItemAblity();
}
