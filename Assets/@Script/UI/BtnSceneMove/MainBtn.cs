using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBtn : MonoBehaviour
{
    public GameObject helpBtn;
    public GameObject rank;
    public AudioClip audioClip;
    public AudioSource audioSource;


    public void HelpFalse()
    {
        audioSource.clip =  audioClip;
        audioSource.Play();
        helpBtn.SetActive(false);
    }
    public void HelpTure()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        helpBtn.SetActive(true);
    }

    public void RankFalse()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        rank.gameObject.SetActive(false);
    }
    public void RankTrue()
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        rank.gameObject.SetActive(true);
    }
}
