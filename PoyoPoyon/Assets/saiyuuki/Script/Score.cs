using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //-------------------------------------
    // public
    //------------------------------------

    public static bool scoreCountFlg;
    float nowScore;

    //public Text test;

    //-------------------------------------
    // private
    //-------------------------------------

    float score; //計算用スコア

    float maxScore = 10;

    bool scoreFlg = true;

    void Start()
    {
        scoreCountFlg = false;
        ScoreManager.Instance.ScoreReset();
        ScoreManager.Instance.DoseScoreReset();
    }

    void Update ()
    {
        //Enemy
        //不届きものの両脇におかっぴきさんが当たったら
        if (scoreCountFlg)
        {
            score = Enemy.memoryTime;
            ScoreManager.Instance.DoseScore = maxScore - (score * 10);

            ScoreManager.Instance.Score += ScoreManager.Instance.DoseScore;
            //test.text = Mathf.FloorToInt(ScoreManager.Instance.Score).ToString();

            scoreCountFlg = false;
            scoreFlg = false;
        }
	}
}
