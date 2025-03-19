using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAlphabert : UI_Base
{
    public QuizCanvas quizCanvas;
    public int myArrayInt;
    public Text setTxt;
    public Image myImage;
    enum Images
    {
        Set,
    }
    enum Texts
    {
        SetTxt,
    }
    public override bool Init()
    {
        gameObject.BindingBtn(FlaseSetTxt);

        Bind<Image>(typeof(Images));
        Bind<Text>(typeof(Texts));

        myImage = GetImage((int)Images.Set);
        setTxt = GetText((int)Texts.SetTxt);

        return true;
    }

    public void TrueSetTxt(char a)
    {
        myImage.color = Color.white;
        setTxt.color = Color.black;

        setTxt.text = a.ToString();
        setTxt.gameObject.SetActive(true);
    }

    public void FlaseSetTxt()
    {
        if (quizCanvas.resultQuiz[myArrayInt] != ' ')
        {
            quizCanvas.resultQuiz[myArrayInt] = ' ';
      
            myImage.color = Color.black;
            setTxt.color= Color.white;

            setTxt.gameObject.SetActive(false);
        }
      
    }
}
