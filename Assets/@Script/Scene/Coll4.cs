using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll4 : MonoBehaviour
{
    public Stage4Starter stage;
    public RandomMonsterSpwan randMon;
    public GameObject heartMon;
    public AudioSource audioSo;
    public AudioClip audioClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            if(heartMon != null) 
                Destroy(heartMon);

            if(audioSo != null)
            {
                audioSo.clip = audioClip;
                audioSo.Play();
            }
              
            stage.SetBossMonster();

            StartCoroutine(randMon.MonsterRandomSpwan());
            transform.position = new Vector3(-1000, -1000);
        }
    }
}
