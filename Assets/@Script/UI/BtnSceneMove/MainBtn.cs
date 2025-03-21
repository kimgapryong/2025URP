using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBtn : MonoBehaviour
{
    public GameObject helpBtn;
    public GameObject rank;


    public void HelpFalse()
    {
        helpBtn.SetActive(false);
    }
    public void HelpTure()
    {
        helpBtn.SetActive(true);
    }

    public void RankFalse()
    {
        rank.gameObject.SetActive(false);
    }
    public void RankTrue()
    {
        rank.gameObject.SetActive(true);
    }
}
