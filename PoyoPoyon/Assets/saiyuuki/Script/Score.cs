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

    public Text test;

    //-------------------------------------
    // private
    //-------------------------------------

    float score; //計算用スコア
    public static float scoreDisplay; //表示用スコア

    float maxScore = 10;

    bool scoreFlg = true;

    void Start()
    {
        scoreCountFlg = false;
        scoreDisplay = 0;
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
            test.text = Mathf.FloorToInt(scoreDisplay).ToString();

            scoreCountFlg = false;
            scoreFlg = false;
        }
	}
}
