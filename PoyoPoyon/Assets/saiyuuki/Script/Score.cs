using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    //-------------------------------------
    // public
    //------------------------------------

    public static bool scoreCountFlg;
    public static float nowScore;

    public Text test;

    //-------------------------------------
    // private
    //-------------------------------------

    float score; //計算用スコア
    float scoreDisplay; //表示用スコア

    float maxScore = 10.0f;

    void Start()
    {
        scoreCountFlg = false;
    }

    void Update ()
    {
        //Enemy
        //不届きものの両脇におかっぴきさんが当たったら
        if (scoreCountFlg)
        {
            score = Enemy.memoryTime;
            nowScore = maxScore - (score * 10);

            scoreDisplay += nowScore;
            test.text = Mathf.CeilToInt(scoreDisplay).ToString();
            scoreCountFlg = false;
        }
	}
}
