using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    const int RANKING_NUM = 3;

    public RankingDate[] rankingDate;
    public Text[] rankLabel = new Text[RANKING_NUM];

    int stageNo;

	void Start ()
    {
        stageNo = stageSelect.rankingStageNo;

        SaveRanking(Score.scoreDisplay);
        LoadRanking();
	}
	
    void SaveRanking(float new_score)
    {
        //ランキングのセーブデータがあるときは順次比較
        if(rankingDate[stageNo].score[0] != 0)
        {
            //小さい方を次の配列へ入れる
            for (int i = 0; i< RANKING_NUM; i++)
            {
                if(rankingDate[stageNo].score[i] < new_score)
                {
                    float _tmp = rankingDate[stageNo].score[i];
                    rankingDate[stageNo].score[i] = new_score;
                    new_score = _tmp;
                }
            }
        }
        else
        {
            //セーブデータがなかったときは先頭へ
            rankingDate[stageNo].score[0] = new_score;
        }
    }

    void LoadRanking()
    {
        for(int i = 0; i<RANKING_NUM; i++)
        {
            rankLabel[i].text = (i + 1).ToString() + "位 : " + Mathf.CeilToInt(rankingDate[stageNo].score[i]).ToString();
        }
    }
}