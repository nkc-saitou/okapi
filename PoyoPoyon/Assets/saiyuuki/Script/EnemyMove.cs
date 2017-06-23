using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    //public float moveLimit = 5.0f;

    //--------------------------------------------
    // 列挙型
    //-------------------------------------------
    public enum soldierMoveType
    {
        UpDown = 0,
        RightLeft,
        Stop
    }

    //-----------------------------------------------
    // public
    //-----------------------------------------------
    public soldierMoveType moveType;

    public float moveLimit;

    //-----------------------------------------------
    // private
    //-----------------------------------------------

    string stuck;

    float moveSpeed = 1.0f;
    Vector2 enemyPos;
    Vector2 startSoldierPos;
    bool upRight = true;
    bool switchFlg_upDown = true;


    void Start()
    {
        startSoldierPos = transform.localPosition;

        if (moveType == soldierMoveType.UpDown) stuck = "UpDown";
        else if (moveType == soldierMoveType.RightLeft) stuck = "RightLeft";
    }

    void Update()
    {

        if (WaveMove.WaveMoveEnd == true)
        {
            switch (moveType)
            {
                case soldierMoveType.UpDown:
                    soldierMove_UpDown();
                    break;

                case soldierMoveType.RightLeft:
                    soldierMove_RightLeft();
                    break;

                case soldierMoveType.Stop:

                    break;
            }
        }

        if (WaveMove.weveEnd)
        {
            moveType = soldierMoveType.Stop;
        }
    }

    void soldierMove_UpDown()
    {
        enemyPos = transform.localPosition;
        float enemyDis = enemyPos.y - startSoldierPos.y;

        if (Mathf.Abs(enemyDis) >= moveLimit)
        {
            upRight = !upRight;

        }

        if (upRight)
        {
            enemyPos.y += moveSpeed * Time.deltaTime;
        }
        else if (upRight == false)
        {
            enemyPos.y -= moveSpeed * Time.deltaTime;
        }

        transform.localPosition = enemyPos;

    }

    void soldierMove_RightLeft()
    {
        enemyPos = transform.localPosition;

        float enemyDis = enemyPos.x - startSoldierPos.x;

        if (Mathf.Abs(enemyDis) >= moveLimit)
        {
            upRight = !upRight;

        }

        if (upRight)
        {
            enemyPos.x += moveSpeed * Time.deltaTime;
        }
        else if (upRight == false)
        {
            enemyPos.x -= moveSpeed * Time.deltaTime;
        }

        transform.localPosition = enemyPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //stuck = moveType.ToString();

        if (other.tag == "lPlayer" || other.tag == "rPlayer")
        {
            moveType = soldierMoveType.Stop;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "lPlayer" || other.tag == "rPlayer")
        {
            if (stuck == "UpDown") moveType = soldierMoveType.UpDown;
            else if (stuck == "RightLeft") moveType = soldierMoveType.RightLeft;
        }
    }
}