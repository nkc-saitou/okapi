using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlg : MonoBehaviour {

    //--------------------------------------------------
    // 定数
    //--------------------------------------------------

    //const float RETURN_SOLDIER = 2.0f;

    //--------------------------------------------------
    // public
    //--------------------------------------------------

    //public static bool[] soldierFlg = new bool[2];

    //--------------------------------------------------
    // private
    //--------------------------------------------------

    //Vector2 startPos;
    //Vector2 soldierReturnPos;

    //[SerializeField]
    //int soldierNo;

    //void Start()
    //{
    //    soldierReturnPos = transform.parent.position;
    //    soldierFlg[soldierNo] = false;
    //}

    //void Update()
    //{
    //    ReturnSoldierMove();
    //}

    //void ReturnSoldierMove()
    //{
    //    //おかっぴきさん同士が衝突したら元いた位置に戻る
    //    if(soldierFlg[soldierNo])
    //    {
    //        transform.parent.position = Vector2.Lerp(transform.parent.position, soldierReturnPos, RETURN_SOLDIER * Time.deltaTime);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D hit)
    {
        //おかっぴきさんにあたったらフラグをtrueにする
        if (hit.tag == "rPlayer" && PlayerMove.flickState_L != "upDown"/* && PlayerMove.flickState_R != null*/) PlayerMove.flickState_L = "returnMove";
        if (hit.tag == "lPlayer" && PlayerMove.flickState_R != "upDown"/* && PlayerMove.flickState_L != null*/) PlayerMove.flickState_R = "returnMove";

        //if (hit.tag == "return_collider")
        //{
        //    PlayerMove.flickState_R = "";
        //}

        //if (soldierNo == 0) PlayerMove.flickState_R = "returnMove";
        //if (soldierNo == 1) PlayerMove.flickState_R = "returnMove";
        //soldierFlg[soldierNo] = true; //元に戻るフラグ
        //PlayerMove.FlickFlg[soldierNo] = false; //フリック時の移動用フラグ
    }

    //void OnTriggerEnter2D(Collider2D hit)
    //{
    //    if (hit.tag == "return_collider")
    //    {
    //        PlayerMove.flickState_R = "";
    //    }
    //}

    //IEnumerator WaitTime()
    //{
    //    yield return new WaitForSeconds(5.0f);
    //    PlayerMove.flickController[soldierNo] = true;
    //}
}