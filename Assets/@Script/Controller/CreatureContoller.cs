using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatureContoller : BaseContoller
{
    private Vector3 _dir;
    public Vector3 dir { get { return _dir; } set { _dir = value.normalized; } }
    public CreatureData creatureData;
    public Animator animator;

    private Dfine.State _state;
    public Dfine.State state
    {
        get
        {
            return _state;
        }
        set
        {
            _state = value;
            switch (state)
            {
                case Dfine.State.Idle:

                    break;

                case Dfine.State.Move:

                    break;

                case Dfine.State.Attack:

                    break;
            }
        }
    }

    public override bool Init()
    {
        base.Init();
        animator = GetComponent<Animator>();
        return true;
    }
    public override void UpdateMehod()
    {
        switch (state)
        {
            case Dfine.State.Idle:
                Idle();
                break;

            case Dfine.State.Move:
                Moving();
                break;

            case Dfine.State.Attack:
                Attack();
                break;
        }
    }

    public virtual void Moving() { }
    public virtual void Idle() { }
    public virtual void Attack() { }
}
