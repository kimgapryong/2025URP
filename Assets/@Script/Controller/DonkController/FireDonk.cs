using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDonk : DonkController
{
    public Collider2D coll;
    private AudioSource audioSource;
    private AudioClip fireClip;
    public override bool Init()
    {
        coll = GetComponent<Collider2D>();
        coll.enabled = false;
        animator = GetComponent<Animator>();

        audioSource = transform.parent.GetComponent<AudioSource>();
        fireClip = Manager.Resources.LoadAudio("FireDonk");

        audioSource.clip = fireClip;
        base.Init();
        return true;
    }
    public override void Attack()
    {
        coll.enabled = true;
    }
    //애니메이션 이벤트
    public void ReturnIdle()
    {
        state = Dfine.State.Idle;
        audioSource.Stop();
        coll.enabled = false;
    }
    public override void ChangeAnim(Dfine.State state)
    {
        switch (state)
        {
            case Dfine.State.Idle:
                animator.Play("Idle");
       
                break;

            case Dfine.State.Attack:
                audioSource.Play();
                animator.Play("Fire_Incendiary_Start");
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null)
            player.PlayerDamage(this, Damage);
        
    }
}
