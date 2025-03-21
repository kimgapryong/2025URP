using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public string[] diaText;
    public float nextTime;

    public Text dialogue;
    public Text godText;
    public Button lobbyBtn;

    private bool isClick;
    private Queue<string> diaQueue;
    private void Start()
    {
        diaQueue = new Queue<string>(diaText);
        StartCoroutine(StartDialogue());
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
        }
    }
    IEnumerator StartDialogue()
    {
        while (diaQueue.Count > 0)
        {
            string cur = diaQueue.Dequeue();
            dialogue.text = "";

            isClick = false;

            foreach (char dia in cur)
            {
                if (isClick)
                {
                    dialogue.text = cur;
                    break;
                }

                dialogue.text += dia;
                yield return new WaitForSeconds(nextTime);
            }
            while (!Input.GetMouseButtonDown(0))
            {
                yield return null;
            }
        }
        dialogue.text = "YOU DIE";
        dialogue.color = Color.red;

        if(godText != null) 
            SaveRanking();
    }

    private void SaveRanking()
    {
        Manager.Rank.AddScore(Manager.Game.Score);
        StartCoroutine(StartScore());
    }

    IEnumerator StartScore()
    {
        godText.gameObject.SetActive(true);
        dialogue.text = " ";
        dialogue.color= Color.black;
        dialogue.fontSize = 300;
        yield return new WaitForSeconds(3);
        for(int i = 0; i < Manager.Game.Score; i++)
        {

            dialogue.text = i.ToString();
            yield return null;
        }
        Destroy(Manager.Instance.gameObject);
        lobbyBtn.gameObject.SetActive(true);
    }
}
