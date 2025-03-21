using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollBoss : MonoBehaviour
{
    public Stage4Starter stage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
            stage.SetBossMonster();

        transform.position = new Vector3(-1000, -1000);
    }
}
