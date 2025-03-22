using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuizCanvas : UI_Base
{
    public GameObject myDoor;
    public string quizAnimal;
    public bool isOk;
    public float SetSize;
    public Sprite animalSprite;
    public char[] alphabet = new char[26]
    {
       'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
    };

    public char[] resultQuiz;
    public SetAlphabert[] setAlphabets;
    enum Images
    {
        AnimalImage,

    }
    enum Texts
    {
        Set1txt, Set2txt, Set3txt,
    }
    enum Objects
    {
        Alphvet,
        SetAlphabet,
    }
    public void StrInit()
    {
        Bind<GameObject>(typeof(Objects));
        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));

        GetImage((int)Images.AnimalImage).sprite = animalSprite;


        resultQuiz = new char[quizAnimal.Length];
        setAlphabets = new SetAlphabert[quizAnimal.Length];

        for(int i =0; i < quizAnimal.Length; i++)
        {
            SetAlphabert setAl = Manager.Ui.CreateUI<SetAlphabert>("Quiz/Set", GetObject((int)Objects.SetAlphabet).transform);
            setAl.GetComponent<RectTransform>().sizeDelta = new Vector2(SetSize, SetSize);

            setAl.quizCanvas = this;
            setAlphabets[i] = setAl;
            setAl.myArrayInt = i;

            setAl.FlaseSetTxt();
        }
        for (int i = 0; i < alphabet.Length; i++)
        {
            AlphabetFragment alpha = Manager.Ui.CreateUI<AlphabetFragment>("Quiz/AlphabetFragment", GetObject((int)Objects.Alphvet).transform);
            alpha.quizCanvas = this;
            alpha.myChar = alphabet[i];

            alpha.StrInit();
        }
    }

    private void Update()
    {
        if(quizAnimal == string.Concat(resultQuiz) && !isOk)
        {
            
            isOk = true;
            GameObject[] objs = GameObject.FindGameObjectsWithTag("Door");
            Manager.Ui.InvenCanvas.GetAllTxt("퍼즐을 풀었습니다 문이 열립니다");
            Manager.Instance.audioSource.PlayOneShot(Manager.Resources.LoadAudio("/ShootingSound/magic_03"));
           

            Manager.Stage.OkStage();
            player.enabled = true;

            for(int i = 0; i < objs.Length; i++)
            {
                GameObject clone = Manager.Resources.Instantiate("Particel/DoorDelete");
                clone.transform.position = objs[i].transform.position;
                Destroy(objs[i]);
            }

            if(myDoor != null) 
                Destroy(myDoor);

            Destroy(gameObject);
        }
    }
}
