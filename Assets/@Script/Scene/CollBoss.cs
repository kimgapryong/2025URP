using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollBoss : MonoBehaviour
{
    public Stage4Starter stage;
    public AudioSource audioSo;
    public AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            stage.SetBossMonster();
        if (audioSo != null)
        {
            audioSo.clip = audioClip;
            audioSo.Play();
        }

        transform.position = new Vector3(-1000, -1000);
    }
}
