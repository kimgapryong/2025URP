using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public ItemData itemData;
    public PlayerController player;
    public Animator animator;
    public AudioClip itemAudio;
    public bool isEquer { get; set; } = true;

    private Dfine.ItemState _state;
    public Dfine.ItemState State
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
            ChangeAnim(value);
        }
    }
    private void Start()
    {
        Init();
    }
   
    public virtual void Init()
    {
        player = Manager.Instance.player;
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        UpdateMehod();
    }

    public virtual void UpdateMehod()
    {
       
    }

    public virtual void ChangeAnim(Dfine.ItemState state) { }
    public abstract void ItemAblity();


}
