using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //-------------------------------------
    // 定数
    //-------------------------------------

    const float FLICK_DIRECTION = 50; //フリックする距離
    const float FLICK_MOVE = 2.0f;

    //-------------------------------------
    // public
    //-------------------------------------

    public GameObject[] soldier = new GameObject[2]; //0がRight,1がLeft
    //public GameObject[] col = new GameObject[2];

    public static bool[] FlickFlg = new bool[2]; //0がRight,1がLeft
    public static bool[] flickController = new bool[2];
    public static string flickState_R;
    public static string flickState_L;

    //-------------------------------------
    // private
    //-------------------------------------

    Ray ray;
    RaycastHit2D hit;

    GameObject[] touchObj = new GameObject[10]; //タッチしたオブジェクトの配列(指10)
    GameObject clickObj;

    Vector3 clickPos;
    Vector2[] startSoldierPos = new Vector2[2];
    Vector2[] soldierReturnPos = new Vector2[2];
    Vector2[] touchStartPos = new Vector2[2];
    Vector2[] touchEndPos = new Vector2[2];

    Vector2 clickStartPos;
    Vector2 clickEndPos;
    float[] disX = new float[2];
    float[] disY = new float[2];

    bool filstTouchFlg;

    ClickState clickState = 0;
    //Right_SoldierState rightState = 0;


    //enum PlayerState
    //{
    //    Idle = 0,
    //    Move,
    //    Attack
    //}

    enum ClickState
    {
        Click = 0,
        Drag
    }

    //////////////////////////////////////////////////////////////////////

    void Start()
    {
        filstTouchFlg = false;

        for (int i = 0; i < FlickFlg.Length; i++)
        {
            FlickFlg[i] = false;
            flickController[i] = true;
        }

        StartCoroutine(WaitTime());

        startSoldierPos[0] = new Vector2(6.1f, soldier[0].transform.position.y);
        startSoldierPos[1] = new Vector2(-6.1f, soldier[1].transform.position.y);

        flickState_R = "upDown";
        flickState_L = "upDown";
    }

    void Update()
    {
        if (filstTouchFlg)
        {
            //TouchTest();
            if (Input.touchSupported)
            {
                foreach (Touch t in Input.touches)
                {
                    switch (t.phase)
                    {
                        //タッチしたとき
                        case TouchPhase.Began:
                            Touch(t);
                            break;

                        //タッチされているとき
                        case TouchPhase.Moved:
                            TouchDrag(t);
                            break;

                        //タッチされていないとき
                        case TouchPhase.Ended:
                            TouchEnd(t);
                            break;
                    }
                }
            }

            else
            {
                switch (clickState)
                {
                    case ClickState.Click:
                        MouseClick();
                        break;

                    case ClickState.Drag:
                        MouseDrag();
                        break;
                }
            }
            RightSoldierMoveState();
        }
    }

    //--------------------------------------------
    // Touch用メソッド
    //--------------------------------------------
    void Touch(Touch t)
    {
        //rayを生成
        ray = Camera.main.ScreenPointToRay(t.position);

        //rayの衝突判定
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        touchStartPos[t.fingerId] = t.position;


        if (hit.collider.tag == "rPlayer" || hit.collider.tag == "lPlayer")
        //if(hit.collider.tag == "touch_R" || hit.collider.tag == "touch_L")
        {
            touchObj[t.fingerId] = hit.collider.gameObject;
        }
        
    }

    void TouchDrag(Touch t)
    {
        if (touchObj[t.fingerId] != null)
        {
            //タッチした位置を保存
            Vector3 TouchPos = t.position;
            TouchPos.z = 10;

            //タッチした位置をワールド座標へ変換
            Vector3 soldierObjPos = Camera.main.ScreenToWorldPoint(TouchPos);

            //移動
            soldierObjPos.x = touchObj[t.fingerId].transform.position.x;
            touchObj[t.fingerId].transform.position = soldierObjPos;
        }
    }

    void TouchEnd(Touch t)
    {
        //タッチを離したfingerId番目の配列をnullにする
        touchObj[t.fingerId] = null;
        touchEndPos[t.fingerId] = t.position;
        GetDirection(t);
    }

    void GetDirection(Touch t)
    {
        disX[t.fingerId] = touchEndPos[t.fingerId].x - touchStartPos[t.fingerId].x;
        disY[t.fingerId] = touchEndPos[t.fingerId].y - touchStartPos[t.fingerId].y;

        if (Mathf.Abs(disY[t.fingerId]) < Mathf.Abs(disX[t.fingerId]))
        {
            //右フリック(LeftObjが右へ移動)
            if (FLICK_DIRECTION < disX[t.fingerId])
            {
                AudioManager.Instance.PlaySE("goyou");

                soldierReturnPos[1] = soldier[1].transform.position;
                soldierReturnPos[1].x = startSoldierPos[1].x;
                flickState_L = "flickMove";
            }
            //左フリック(RightObjが左へ移動)
            else if (-FLICK_DIRECTION > disX[t.fingerId])
            {
                AudioManager.Instance.PlaySE("goyou");

                soldierReturnPos[0] = soldier[0].transform.position;
                soldierReturnPos[0].x = startSoldierPos[0].x;
                flickState_R = "flickMove";
            }
        }
    }

    //--------------------------------------------
    // Click用メソッド
    //--------------------------------------------

    void MouseClick()
    {
        //rayの生成
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //rayの衝突判定
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (Input.GetMouseButtonDown(0) && hit.collider)
        {
            //フリック用のクリック開始位置を保存
            clickStartPos = Input.mousePosition;

            //rayが当たったオブジェクトを保存
            clickObj = hit.collider.gameObject;

            //状態をドラッグに
            clickState = ClickState.Drag;
        }
    }

    void MouseDrag()
    {
        for (int soldierNo = 0; soldierNo < 2; soldierNo++)
        {
            if (Input.GetMouseButton(0))
            {
                clickPos = Input.mousePosition;
                clickPos.z = 10;

                if (clickObj == soldier[soldierNo])
                {
                    //クリックした位置へ移動させる
                    Vector3 soldierPos = Camera.main.ScreenToWorldPoint(clickPos);
                    soldierPos.x = soldier[soldierNo].transform.position.x;
                    soldierPos.y = Mathf.Clamp(soldierPos.y, -4, 4);
                    soldier[soldierNo].transform.localPosition = soldierPos;

                    //float dis = Camera.main.ScreenToWorldPoint(clickPos).y - Camera.main.ScreenToWorldPoint(clickStartPos).y;

                    //Debug.Log(dis);
                    //Vector2 soldierPos = soldier[soldierNo].transform.position;
                    //soldierPos.y += dis * Time.deltaTime;
                    //soldierPos.x = startSoldierPos[soldierNo].x;
                    //soldier[soldierNo].transform.position = soldierPos;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                //状態をクリック待ちにする
                clickState = ClickState.Click;

                //フリック用のクリック終了位置を保存
                clickEndPos = Input.mousePosition;
                GetDirection();
            }
        }
    }

    void GetDirection()
    {
        float disX = clickEndPos.x - clickStartPos.x;
        float disY = clickEndPos.y - clickStartPos.y;

        if (Mathf.Abs(disY) < Mathf.Abs(disX))
        {
            //右フリック
            if (FLICK_DIRECTION < disX)
            {
                AudioManager.Instance.PlaySE("goyou");

                soldierReturnPos[1] = soldier[1].transform.position;
                soldierReturnPos[1].x = startSoldierPos[1].x;
                flickState_L = "flickMove";
            }
            //左フリック
            else if (-FLICK_DIRECTION > disX)
            {
                AudioManager.Instance.PlaySE("goyou");

                soldierReturnPos[0] = soldier[0].transform.position;
                soldierReturnPos[0].x = startSoldierPos[0].x;
                flickState_R = "flickMove";
            }
        }
    }

    //--------------------------------------------------
    // フリック移動
    //--------------------------------------------------

    void RightSoldierMoveState()
    {
        switch (flickState_R)
        {
            case "flickMove":
                soldier[0].transform.position =
                    Vector2.Lerp(soldier[0].transform.position, soldier[1].transform.position, FLICK_MOVE * Time.deltaTime);
                break;

            case "returnMove":
                soldier[0].transform.position = 
                    Vector2.Lerp(soldier[0].transform.position, soldierReturnPos[0], FLICK_MOVE * Time.deltaTime);
                break;

            default:
                break;
        }

        switch(flickState_L)
        {
            case "flickMove":
                soldier[1].transform.position =
                    Vector2.Lerp(soldier[1].transform.position, soldier[0].transform.position, FLICK_MOVE * Time.deltaTime);
                break;

            case "returnMove":
                soldier[1].transform.position =
                    Vector2.Lerp(soldier[1].transform.position, soldierReturnPos[1], FLICK_MOVE * Time.deltaTime);
                break;

            default:
                break;
        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(1.0f);
        filstTouchFlg = true;

    }

//-----------------------------------------------------------
// フリック用の処理
//-----------------------------------------------------------

    //PlayerState state;

    //public void PlayerMode(int modeNo)
    //{
    //    state = (PlayerState)modeNo;
    //}
}