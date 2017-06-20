using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    //public float moveLimit = 5.0f;

    public soldierMoveType moveType;
    string stuck;

    float swichTimer = 2.0f;

    float moveSpeed = 1.0f;
    Vector2 enemyPos;
    Vector2 startSoldierPos;
    bool upRight = true;
    bool switchFlg_upDown = true;

    public enum soldierMoveType
    {
        UpDown = 0,
        RightLeft,
        Stop
    }

	void Start ()
    {
        startSoldierPos = transform.localPosition;
	}
	
	void Update ()
    {
        if (WaveMove.WaveMoveEnd == true)
        {
            switch (moveType)
            {
                case soldierMoveType.UpDown:
                    //stuck = "UpDown";
                    StartCoroutine(soldierMove_UpDown());
                    break;

                case soldierMoveType.RightLeft:
                    //stuck = "RightLeft";
                    StartCoroutine(soldierMove_RightLeft());
                    break;

                case soldierMoveType.Stop:
                    
                    break;
            }
        }

        if (transform.localPosition.y > startSoldierPos.y + 2.5f
            || transform.localPosition.y < startSoldierPos.y - 2.5f)
        {
            upRight = !upRight;
        }
    }

    IEnumerator soldierMove_UpDown()
    {
        enemyPos = transform.localPosition;
        //float enemyDis = enemyPos.y - startSoldierPos.y;

        if (upRight)
        {
            enemyPos.y += moveSpeed * Time.deltaTime;
        }
        else if (upRight == false)
        {
            enemyPos.y -= moveSpeed * Time.deltaTime;
        }

        if (switchFlg_upDown)
        {
            upRight = !upRight;
            switchFlg_upDown = false;

            yield return new WaitForSeconds(2.0f);
            switchFlg_upDown = true;
            Debug.Log("ok");
        }



        transform.localPosition = enemyPos;

    }

    IEnumerator soldierMove_RightLeft()
    {
        enemyPos = transform.localPosition;
        float enemyDis = enemyPos.y - startSoldierPos.y;

        if (upRight)
        {
            enemyPos.x += moveSpeed * Time.deltaTime;
        }
        else if (upRight == false)
        {
            enemyPos.x -= moveSpeed * Time.deltaTime;
        }

        if (switchFlg_upDown)
        {
            upRight = !upRight;
            switchFlg_upDown = false;

            yield return new WaitForSeconds(2.0f);
            switchFlg_upDown = true;
            Debug.Log("ok");
        }

        transform.localPosition = enemyPos;
    }

    void soldierMove_Stop()
    {
        //Flgを全てfalseに
        switchFlg_upDown = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        stuck=moveType.ToString();
        if (other.tag == "lPlayer" || other.tag == "rPlayer")
        {
            Debug.Log("off");
            moveType = soldierMoveType.Stop;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "lPlayer" || other.tag == "rPlayer")
        {
            Debug.Log("off");
            if (stuck == "UpDown") moveType = soldierMoveType.UpDown;
            else if (stuck == "RightLeft") moveType = soldierMoveType.RightLeft;
        }
    }
}