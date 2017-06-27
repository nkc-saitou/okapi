using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{

    private float m_score;
    private float d_score;

    public RankingDate[] rankingDate;

    public float DoseScore
    {
        set { d_score = value; }
        get { return d_score; }
    }

    public float Score
    {
        set { m_score = value; }
        get { return m_score; }
        
    }

    public void ScoreSetRanking()
    {
        float new_score = Score;
        //ランキングのセーブデータがあるときは順次比較
        if (rankingDate[RankingStageNo.rankingStageNo].score[0] != 0)
        {
            //小さい方を次の配列へ入れる
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(RankingStageNo.rankingStageNo);
                if (rankingDate[RankingStageNo.rankingStageNo].score[i] < new_score)
                {
                    float _tmp = rankingDate[RankingStageNo.rankingStageNo].score[i];
                    rankingDate[RankingStageNo.rankingStageNo].score[i] = new_score;
                    new_score = _tmp;
                }
            }
        }
        else if (rankingDate[RankingStageNo.rankingStageNo].score[0] == 0)
        {
            //セーブデータがなかったときは先頭へ
            rankingDate[RankingStageNo.rankingStageNo].score[0] = new_score;
        }
    }

    public void ScoreReset()
    {
        m_score = 0;
    }

    public void DoseScoreReset()
    {
        d_score = 0;
    }
}
