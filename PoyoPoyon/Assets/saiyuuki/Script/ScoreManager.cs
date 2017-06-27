using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{

    private float m_score;

    public RankingDate[] rankingDate;

    public float Score
    {
        set
        {
            m_score = value;
        }
        get
        {
            return m_score;
        }
    }

    public void ScoreSetRanking()
    {
        //ランキングのセーブデータがあるときは順次比較
        if (rankingDate[RankingStageNo.rankingStageNo].score[0] != 0)
        {
            //小さい方を次の配列へ入れる
            for (int i = 0; i < 3; i++)
            {
                Debug.Log(RankingStageNo.rankingStageNo);
                if (rankingDate[RankingStageNo.rankingStageNo].score[i] < Score)
                {
                    float _tmp = rankingDate[RankingStageNo.rankingStageNo].score[i];
                    rankingDate[RankingStageNo.rankingStageNo].score[i] = Score;
                    Score = _tmp;
                }
            }
        }

        else if (rankingDate[RankingStageNo.rankingStageNo].score[0] == 0)
        {
            //セーブデータがなかったときは先頭へ
            rankingDate[RankingStageNo.rankingStageNo].score[0] = Score;
        }
    }

    public void ScoreReset()
    {
        m_score = 0;
    }
}
