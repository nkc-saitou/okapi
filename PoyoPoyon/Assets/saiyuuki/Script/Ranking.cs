using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

    const int RANKING_NUM = 3;

    public RankingDate[] rankingDate;
    public Text[] rankLabel = new Text[RANKING_NUM];

    //int stageNo = 0;

    public bool setRankingFlg = true; //saveならtrue,loadならfalse

	void Start ()
    {
        if (setRankingFlg == true)
        {
            SaveRanking(ScoreManager.Instance.Score);
        }
    }

    void Update()
    {

        //stageNo = RankingStageNo.rankingStageNo;

        if(setRankingFlg == false) LoadRanking();
    }

    void SaveRanking(float new_score)
    {
        //ランキングのセーブデータがあるときは順次比較
        if(rankingDate[RankingStageNo.rankingStageNo].score[0] != 0)
        {
            Debug.Log(new_score);
            //小さい方を次の配列へ入れる
            for (int i = 0; i< RANKING_NUM; i++)
            {
                Debug.Log(RankingStageNo.rankingStageNo);
                if(rankingDate[RankingStageNo.rankingStageNo].score[i] < new_score)
                {
                    float _tmp = rankingDate[RankingStageNo.rankingStageNo].score[i];
                    rankingDate[RankingStageNo.rankingStageNo].score[i] = new_score;
                    new_score = _tmp;
                }
            }
        }
        else if(rankingDate[RankingStageNo.rankingStageNo].score[0] == 0)
        {
            //セーブデータがなかったときは先頭へ
            rankingDate[RankingStageNo.rankingStageNo].score[0] = new_score;
        }
    }

    void LoadRanking()
    {
        for(int i = 0; i<RANKING_NUM; i++)
        {
            rankLabel[i].text = (i + 1).ToString() + "位 : " + Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[i]).ToString();
        }
    }
}