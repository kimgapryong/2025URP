using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagesMove : MonoBehaviour
{
    public Transform[] door;

    private void Update()
    {
        for(int i =0;  i < door.Length; i++)
        {
            if(Vector3.Distance(Manager.Instance.player.transform.position, door[i].position) < 2f)
            {
                if (Manager.Stage.CheckStage(i))
                {
                    SceneManager.LoadScene($"Stage{i + 1}");
                }
                else
                {
                    //TODO 경고 ui파업창 띄우기
                    Debug.Log("오지마라");
                }
            }
        }
    }
}
