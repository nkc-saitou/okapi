using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviourExtension {

    //const int RANKING_NUM = 3;

    //public RankingDate[] rankingDate;
    //public Text[] rankLabel = new Text[RANKING_NUM];
    //int[] rank = new int[RANKING_NUM];

    public Text scoreText;

    //public List<int> scoreLis = new List<int>();
    //public Sprite[] scoreImage;

    //int stageNo = 0;

    //public bool setRankingFlg = true; //saveならtrue,loadならfalse

	void Start ()
    {
        //if (setRankingFlg == true)
        //{
            //SaveRanking(ScoreManager.Instance.Score);
            ScoreManager.Instance.ScoreSetRanking();

        WaitAfter(0.1f, () =>
        {
            scoreText.text = Mathf.FloorToInt(ScoreManager.Instance.Score).ToString();
        });

        //}
    }

    //void Update()
    //{

    //    stageNo = RankingStageNo.rankingStageNo;

    //    if (setRankingFlg == false) LoadRanking();
    //}

    //void SaveRanking(/*float new_score*/)
    //{
    //    //ランキングのセーブデータがあるときは順次比較
    //    if (rankingDate[RankingStageNo.rankingStageNo].score[0] != 0)
    //    {
    //        Debug.Log(new_score);
    //        //小さい方を次の配列へ入れる
    //        for (int i = 0; i < RANKING_NUM; i++)
    //        {
    //            Debug.Log(RankingStageNo.rankingStageNo);
    //            if (rankingDate[RankingStageNo.rankingStageNo].score[i] < new_score)
    //            {
    //                float _tmp = rankingDate[RankingStageNo.rankingStageNo].score[i];
    //                rankingDate[RankingStageNo.rankingStageNo].score[i] = new_score;
    //                new_score = _tmp;
    //            }
    //        }
    //    }
    //    else if (rankingDate[RankingStageNo.rankingStageNo].score[0] == 0)
    //    {
    //        //セーブデータがなかったときは先頭へ
    //        rankingDate[RankingStageNo.rankingStageNo].score[0] = new_score;
    //    }
    //}

    //void LoadRanking()
    //{
    //    for (int i = 0; i < RANKING_NUM; i++)
    //    {
    //        //rankLabel[i].text = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[i]).ToString();

    //        rank[i] = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[i]);

    //        scoreLis = new List<int>();

    //        int digit = rank[i];

    //        while(digit != 0)
    //        {
    //            rank[i] = digit % 10;
    //            digit = digit / 10;
    //            scoreLis.Add(rank[i]);
    //        }
    //    }
    //}
}