using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheatAngine : MonoBehaviour
{
    public int curID;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Manager.Instance.player.CurrentBreath = Manager.Instance.player.MaxBreath;
            Manager.Instance.player.CurrentHp = Manager.Instance.player.Hp;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if(Manager.Game.CanShop)
                Manager.Game.CanShop = false;
            else
                Manager.Game.CanShop = true;
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene($"Stage{curID}");
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            if (curID + 1 <= 6)
                SceneManager.LoadScene($"Stage{curID + 1}");
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            if(Time.timeScale == 0)
                Time.timeScale = 1;
            else
                Time.timeScale = 0;
        }

    }
}
