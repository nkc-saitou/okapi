using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    //public float moveLimit = 5.0f;

    public soldierMoveType moveType;

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
                    StartCoroutine(soldierMove_UpDown());
                    break;

                case soldierMoveType.RightLeft:
                    break;

                case soldierMoveType.Stop:
                    break;
            }
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
        }

        transform.localPosition = enemyPos;
    }

    void soldierMove_RightLeft()
    {

    }

    void soldierMove_Stop()
    {

    }
}