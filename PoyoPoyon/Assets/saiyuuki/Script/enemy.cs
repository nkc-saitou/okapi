using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public Text scoreText;
    public static float memoryTime;

    float scoreTime;
    bool scoreFlg = false;

    List<GameObject> hitList = new List<GameObject>();

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        //当たったオブジェクトが左右のおかっぴきだったら
        if(hit.tag == "rPlayer" || hit.tag == "lPlayer")
        {
            scoreFlg = true;
            //リストに追加されていないオブジェクトの場合のみリストに追加
            if(!hitList.Contains(hit.gameObject))
            {
                hitList.Add(hit.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if(hit.tag == "rPlayer" || hit.tag == "lPlayer")
        {
            scoreTime = 0;
            scoreFlg = false;

            if(hitList.Contains(hit.gameObject))
            {
                hitList.Remove(hit.gameObject);
            }
        }
    }

    void Update()
    {
        if(scoreFlg) scoreTime += 1 * Time.deltaTime;
        //scoreText.text = scoreTime.ToString();

        //リストに両方のおかっぴきさんが格納されていたらオブジェクト消去
        if (hitList.Count == 2)
        {
            if (hitList[0].tag == "rPlayer" || hitList[0].tag == "lPlayer")
            {
                if (hitList[1].tag == "rPlayer" || hitList[1].tag == "lPlayer")
                {
                    Score.scoreCountFlg = true;
                    memoryTime = scoreTime;
                    scoreTime = 0;

                    PlayerMove.flickState_R = "returnMove";
                    PlayerMove.flickState_L = "returnMove";

                    Destroy(gameObject);
                }
            }
        }
    }

}