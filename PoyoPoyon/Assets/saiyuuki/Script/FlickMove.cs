using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickMove : MonoBehaviour {

    //-----------------------------------------------
    // 定数
    //-----------------------------------------------

    const float FLICK_DISTANCE = 10.0f; //フリック距離
    const float SOLDIER_MOVE = 5.0f; //フリック時移動速度

    //-----------------------------------------------
    // public
    //-----------------------------------------------

    public GameObject[] soldier = new GameObject[2]; //0がRight,1がLeft

    //-----------------------------------------------
    // private
    //-----------------------------------------------

    float clickStartPosX;
    float clickEndPosX;

    string flickState;

    bool[] flickFlg = new bool[2];

    PlayerMove playerMove;

    void Start()
    {
        for(int i=0; i < flickFlg.Length;i++)
        {
            flickFlg[i] = false;
        }

        playerMove = GetComponent<PlayerMove>();
    }

    void GetDirection()
    {
        float dis = clickEndPosX - clickStartPosX;
        //右フリック
        if (FLICK_DISTANCE < dis)
        {
            flickFlg[0] = true;
        }
        //左フリック
        else if (-FLICK_DISTANCE > dis)
        {
            flickFlg[1] = true;
        }
    }

    public void FlickSoldierMove()
    {
        GetDirection();
        Debug.Log(clickStartPosX);
        //右フリック移動
        if (flickFlg[0])
        {
            soldier[1].transform.position = Vector2.MoveTowards(soldier[1].transform.position, soldier[0].transform.position, SOLDIER_MOVE);

        }
        //左フリック移動
        if(flickFlg[1])
        {
            soldier[0].transform.position = Vector2.MoveTowards(soldier[0].transform.position, soldier[1].transform.position, SOLDIER_MOVE);
        }
    }
}