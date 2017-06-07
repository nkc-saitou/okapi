using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlg : MonoBehaviour {

    //--------------------------------------------------
    // 定数
    //--------------------------------------------------

    const float RETURN_SOLDIER = 1.8f;

    //--------------------------------------------------
    // public
    //--------------------------------------------------

    public static bool[] soldierFlg = new bool[2];

    //--------------------------------------------------
    // private
    //--------------------------------------------------

    bool waitFlg = true;

    Vector2 startPos;
    Vector2 soldierReturnPos;

    [SerializeField]
    int soldierNo;



    void Start()
    {
        soldierReturnPos = transform.parent.position;
        soldierFlg[soldierNo] = false;
    }

    void Update()
    {
        ReturnSoldierMove();
    }

    void ReturnSoldierMove()
    {
        //おかっぴきさん同士が衝突したら元いた位置に戻る
        if(soldierFlg[soldierNo])
        {
            transform.parent.position = Vector2.Lerp(transform.parent.position, soldierReturnPos, RETURN_SOLDIER * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        //おかっぴきさんにあたったらフラグをtrueにする
        if(hit.tag == "pl_collider")
        {
            soldierFlg[soldierNo] = true; //元に戻るフラグ
            PlayerMove.FlickFlg[soldierNo] = false; //フリック時の移動用フラグ
            PlayerMove.flickController[soldierNo] = false;
        }
    }

    void OnTriggerStay2D(Collider2D hit)
    {
        if (hit.tag == "return_collider")
        {
            soldierFlg[soldierNo] = false;
            StartCoroutine(WaitTime());
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.0f);
        PlayerMove.flickController[soldierNo] = true;
    }
}