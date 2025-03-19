using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetFragment : UI_Base
{
    public QuizCanvas quizCanvas;
    public Text text;
    public char myChar;
    enum Texts
    {
        AlphabetText,
    }

    public void StrInit()
    {
        gameObject.BindingBtn(SetAlphabet);
        Bind<Text>(typeof(Texts));
        text = GetText((int)Texts.AlphabetText);
       
        text.text = myChar.ToString();
    }

    public void SetAlphabet()
    {
        Debug.Log("클릭");
        for (int i = 0; i < quizCanvas.resultQuiz.Length; i++)
        {
            if (quizCanvas.resultQuiz[i] == ' ')
            {
                quizCanvas.resultQuiz[i] = myChar;
                quizCanvas.setAlphabets[i].TrueSetTxt(myChar);
                break;
            }
        }

        Manager.Ui.InvenCanvas.GetAllTxt("칸을 비워주세요");
    }
}
