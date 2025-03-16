using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preatical : MonoBehaviour
{
    public float damage;
    public CreatureContoller atker;
    public Vector3 dir;
    public float speed;

    public Dictionary<Vector3, float> rotates = new Dictionary<Vector3, float>()
    {
        [Vector3.up] = 180,
        [Vector3.right] = -90,
        [Vector3.left] = 90,
        [Vector3.down] = 0,
    };
    private void Start()
    {
        gameObject.transform.eulerAngles = new Vector3 (0f, 0f, rotates[dir]);
        Destroy(gameObject, 2);
    }
    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreatureContoller creature = collision.GetComponent<CreatureContoller>();
        if (creature != null)
            creature.Ondamage(atker, damage);
    }
}
