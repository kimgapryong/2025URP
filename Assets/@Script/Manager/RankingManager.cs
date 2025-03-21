using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RankingManager
{
    private const string RANKING_KEY = "Ranking";

    public void AddScore(int newScore)
    {
        List<int> scores = GetRankingList();
        scores.Add(newScore);

        scores = scores.OrderByDescending(s => s).Take(10).ToList();

        SaveRanking(scores);
    }

    public List<int> GetRankingList()
    {
        List<int> scores = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            if(PlayerPrefs.HasKey($"{RANKING_KEY}_{i}"))
                scores.Add(PlayerPrefs.GetInt($"{RANKING_KEY}_{i}"));
        }

        return scores;
    }

    private void SaveRanking(List<int> scores)
    {
        for(int i =0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt($"{RANKING_KEY}_{i}", scores[i]);
        }
        PlayerPrefs.Save();
    }
}
