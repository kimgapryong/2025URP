using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CreatureData", menuName ="new Creature")]
public class CreatureData : ScriptableObject
{
    public float hp;
    public float speed;
    public float damage;
    public float arange;
    public float atkArange;

}
