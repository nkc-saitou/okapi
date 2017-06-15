using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlg : MonoBehaviour {

    //-----------------------------------------------------
    // 定数
    //-----------------------------------------------------

    const float border = 5.6f;

    //-----------------------------------------------------
    // public
    //-----------------------------------------------------

    public int soldierNo;

    void Update()
    {
        Vector2 soldierPos = gameObject.transform.position;

        if(soldierNo == 0 && soldierPos.x > border)
        {
            PlayerMove.flickState_R = "upDown";
        }

        if(soldierNo == 1 && soldierPos.x < -border)
        {
            PlayerMove.flickState_L = "upDown";
        }
    }

    void OnTriggerStay2D(Collider2D hit)
    {
        
        //おかっぴきさんにあたったらフラグをtrueにする
        if (hit.tag == "lPlayer" && PlayerMove.flickState_R != "upDown")
        {
            PlayerMove.flickState_R = "returnMove";
        }

        if (hit.tag == "rPlayer" && PlayerMove.flickState_L != "upDown")
        {
            PlayerMove.flickState_L = "returnMove";
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.tag == "enemy")
        {
            if (soldierNo == 0 && PlayerMove.flickState_R != "returnMove")
            {
                PlayerMove.flickState_R = "waitTime";
                StartCoroutine(WaitTime_R());
            }

            if (soldierNo == 1 && PlayerMove.flickState_L != "returnMove")
            {
                PlayerMove.flickState_L = "waitTime";
                StartCoroutine(WaitTime_L());
            }
        }
    }

    IEnumerator WaitTime_R()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerMove.flickState_R = "returnMove";
    }

    IEnumerator WaitTime_L()
    {
        yield return new WaitForSeconds(0.8f);
        PlayerMove.flickState_L = "returnMove";
    }

}