using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class RandomMonsterSpwan : MonoBehaviour
{

    public Vector3[] dirs = new Vector3[8]
    {
        Vector3.up,
        Vector3.left,
        Vector3.down,
        Vector3.right,
        new Vector3(-1,1),
        new Vector3(-1,-1),
        new Vector3(1,-1),
        new Vector3(1,1),
    };
    public float minvecX = 75;
    public float maxvecX = 110;
    public float minvecY = 41;
    public float maxvecY = 70;

    public int maxMonster = 40;
    public int curMonster;

    public int monsterCount; //몬스터 얼마나 생설할지 예 1000마리
    private int curCount;


    public float spawnTime;

    public GameObject[] monsters;


    public IEnumerator MonsterRandomSpwan()
    {
        while(monsterCount > 0)
        {
            if(curMonster <= maxMonster)
            {
                Vector3 curDis;
                curCount++;
                int curCreate = curCount * curCount;

                int rand = Random.Range(0, monsters.Length);
                int curSpwan = 0;

                float randX = Random.Range(minvecX, maxvecX);
                float randY = Random.Range(minvecY, maxvecY);
                curDis = new Vector3(randX, randY);

                if(curCreate > 21)
                    curCreate = 21;

                for (int i = 0; i < curCreate; i++)
                {
                    if(curSpwan >= dirs.Length)
                        curSpwan = 0;

                    GameObject randMonster = Instantiate(monsters[rand], curDis, Quaternion.identity);
                    Debug.LogWarning(randMonster);
                    DieMonster dieMon = randMonster.AddComponent<DieMonster>();
                    dieMon.randSpwan = this;

                    curDis = curDis + dirs[curSpwan];
                    curSpwan++;
                    curMonster++;
                }
                yield return new WaitForSeconds(spawnTime);
            }
            else
            {
                yield return null;
            }
        }
       
    }
}
