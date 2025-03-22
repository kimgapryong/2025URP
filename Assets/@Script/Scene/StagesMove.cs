using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StagesMove : MonoBehaviour
{
    public int currentStageId;
    public Transform door;

    private void Update()
    {
        if(Manager.Instance != null)
        if (Vector3.Distance(Manager.Instance.player.transform.position, door.position) < 2f)
        {
            if(currentStageId == 6)
                Manager.Instance.DieClear();

            SceneManager.LoadScene($"Stage{currentStageId}");
        }
    }
}
