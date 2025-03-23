using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieCanvas : UI_Base
{
    enum Buttons
    {
        ReturnBtn,
        MainBtn,
    }
    public override bool Init()
    {
        Bind<Button>(typeof(Buttons));

        GetButton((int)Buttons.ReturnBtn).gameObject.BindingBtn(ReturnGame);
        GetButton((int)Buttons.MainBtn).gameObject.BindingBtn(ReturnMain);

        gameObject.SetActive(false);
        return true;
    }

    public void ReturnGame()
    {
        Manager.Instance.DieClear();
        Destroy(Manager.Instance.gameObject);
        Destroy(gameObject);
        SceneManager.LoadScene("Stage0");
    }
    public void ReturnMain()
    {
        Manager.Instance.DieClear();
        Destroy(Manager.Instance.gameObject);
        Destroy(gameObject);
        SceneManager.LoadScene("MainScene");
    }
    
}
