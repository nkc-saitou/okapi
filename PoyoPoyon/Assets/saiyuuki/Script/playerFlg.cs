using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlg : MonoBehaviour {

    //--------------------------------------------------
    // 定数
    //--------------------------------------------------

    const float RETURN_SOLDIER = 2.0f;

    //--------------------------------------------------
    // public
    //--------------------------------------------------

    public int soldierNo;

    public static bool[] soldierFlg = new bool[2];

    //--------------------------------------------------
    // private
    //--------------------------------------------------

    bool waitFlg = true;

    float time = 1;
    float startTime;
    float rate;

    [SerializeField]
    Vector2 endPos;

    Vector2 startPos;
    Vector2 soldierReturnPos;

    void Start()
    {
        soldierReturnPos = transform.parent.position;
        
        //フラグをfalseに
        for (int i = 0; i< soldierFlg.Length; i++)
        {
            soldierFlg[i] = false;
        }
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
            StartCoroutine(WaitTime());
        }
        //if(soldierFlg[1])
        //{
        //    transform.parent.position = Vector2.Lerp(transform.parent.position, soldierReturnPos, RETURN_SOLDIER * Time.deltaTime);
        //}

        ////右側のおかっぴきさんが元の位置に戻ったら
        //if (transform.parent.position.x >= soldierReturnPos.x && soldierNo == 0)
        //{
        //    soldierFlg[0] = false;
        //}
        ////左側のおかっぴきさんが元の位置に戻ったら
        //if(transform.parent.position.x <= soldierReturnPos.x && soldierNo == 1)
        //{
        //    soldierFlg[1] = false;
        //}

        //Vector2 soldierPos = transform.parent.position;
        ////おかっぴきさんが衝突し、フラグがtrueになったとき、元の位置に戻る処理
        //if (soldierFlg[soldierNo])
        //{
        //    if (soldierNo == 0) soldierPos.x += RETURN_SOLDIER * Time.deltaTime;
        //    if (soldierNo == 1) soldierPos.x -= RETURN_SOLDIER * Time.deltaTime;

        //    transform.parent.position = soldierPos;
        //}

        ////右側のおかっぴきさんが元の位置より移動しないようにする
        //if (soldierNo == 0 && soldierPos.x > soldierReturnPos.x)
        //{
        //    Vector2 nowPos = transform.parent.position;
        //    nowPos.x = soldierReturnPos.x;
        //    transform.parent.position = nowPos;
        //    soldierFlg[soldierNo] = false;
        //}
        ////左側のおかっぴきさんが元の位置より移動しないようにする
        //if (soldierNo == 1 && soldierPos.x < soldierReturnPos.x)
        //{
        //    Vector2 nowPos = transform.parent.position;
        //    nowPos.x = soldierReturnPos.x;
        //    transform.parent.position = nowPos;
        //    soldierFlg[soldierNo] = false;
        //}
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        //おかっぴきさんにあたったらフラグをtrueにする
        if(hit.tag == "pl_collider")
        {
            soldierFlg[soldierNo] = true;

            PlayerMove.FlickFlg[soldierNo] = false; 
        }
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2.0f);
        soldierFlg[soldierNo] = false;
    }
}