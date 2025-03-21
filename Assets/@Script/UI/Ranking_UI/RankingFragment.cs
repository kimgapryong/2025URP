using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingFragment : UI_Base
{
    public Text numTxt;
    public Text scoreTxt;
    enum Texts
    {
        NumTxt,
        ScoreTxt,
    }
    public void StrInit(int num, int score)
    {
        Bind<Text>(typeof(Texts));

        GetText((int)Texts.NumTxt).text = num.ToString();
        GetText((int)Texts.ScoreTxt).text = score.ToString();

    }
}
