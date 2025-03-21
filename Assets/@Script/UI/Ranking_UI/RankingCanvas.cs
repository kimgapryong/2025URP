using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingCanvas : UI_Base
{
    private GameObject content;
    enum Objects
    {
        Content,
    }
    public override bool Init()
    {
        Bind<GameObject>(typeof(Objects));
        content = GetObject((int)Objects.Content);

        List<int> scoreList = Manager.Rank.GetRankingList();

        for(int i = 0; i < scoreList.Count; i++)
        {
            RankingFragment fragment = Manager.Ui.CreateUI<RankingFragment>("Ranking/RankFragment",content.transform);
            fragment.StrInit(i + 1, scoreList[i]);
        }

        gameObject.SetActive(false);
        return true;
    }
}
