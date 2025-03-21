using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnSceneMove : MonoBehaviour
{
   public void GoToLobby()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void GoToStage0()
    {
        SceneManager.LoadScene("Stage0");
    }
}
