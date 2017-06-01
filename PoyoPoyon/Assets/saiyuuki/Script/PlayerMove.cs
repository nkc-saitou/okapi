using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    //-------------------------------------
    // 定数
    //-------------------------------------

    const float FLICK_DIRECTION = 100; //フリックする距離
    const float FLICK_MOVE = 1.0f;

    //-------------------------------------
    // public
    //-------------------------------------

    public GameObject[] soldier = new GameObject[2]; //0がRight,1がLeft
    public Text test;


    public static bool[] FlickFlg = new bool[2]; //0がRight,1がLeft

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

    float clickStartPos;
    float clickEndPos;

    ClickState clickState = 0;

    //////////////////////////////////////////////////////////////////////

    void Start()
    {
        for(int i = 0; i<FlickFlg.Length; i++)
        {
            FlickFlg[i] = false;
            startSoldierPos[i] = soldier[i].transform.position;
        }
    }

    void Update()
    {
        TouchTest();
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
            FlickSoldierMove();
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

        if (hit.collider.tag == "rPlayer" || hit.collider.tag == "lPlayer")
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
            clickStartPos = Input.mousePosition.x;

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
                    Vector3 soilderPos = Camera.main.ScreenToWorldPoint(clickPos);
                    soilderPos.x = clickObj.transform.position.x;
                    soldier[soldierNo].transform.localPosition = soilderPos;
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                //状態をクリック待ちにする
                clickState = ClickState.Click;

                //フリック用のクリック終了位置を保存
                clickEndPos = Input.mousePosition.x;
                GetDirection();
            }
        }
    }

    enum ClickState
    {
        Click = 0,
        Drag
    }

    //-----------------------------------------------------------
    // フリック用の処理
    //-----------------------------------------------------------

    void GetDirection()
    {
        float dis = clickEndPos - clickStartPos;

        //右フリック
        if (FLICK_DIRECTION < dis)
        {
            FlickFlg[0] = true;
            soldierReturnPos[1] = soldier[1].transform.position;
        }
        //左フリック
        else if (-FLICK_DIRECTION > dis)
        {
            FlickFlg[1] = true;
            soldierReturnPos[0] = soldier[0].transform.position;
        }
    }

    void FlickSoldierMove()
    {
        //右フリック移動処理
        if (FlickFlg[0])
        {
            soldier[1].transform.position = Vector2.Lerp(soldier[1].transform.position, soldier[0].transform.position, FLICK_MOVE * Time.deltaTime);
        }
        //左フリック移動処理
        if (FlickFlg[1])
        {
            soldier[0].transform.position = Vector2.Lerp(soldier[0].transform.position, soldier[1].transform.position, FLICK_MOVE * Time.deltaTime);
        }
    }
    
    ////--------------------------------------------
    //// プロパティ
    ////--------------------------------------------
    //public Vector2 SoldierReturnPos_Left
    //{
    //    get { return soldierReturnPos[1]; }
    //    set { soldierReturnPos[1] = value; }
    //}

    //public Vector2 SoldierReturnPos_Right
    //{
    //    get { return soldierReturnPos[0]; }
    //    set { soldierReturnPos[0] = value; }
    //}

    void TouchTest()
    {
        string result = "";
        result += string.Format("touchCount : {0}\r\n", Input.touchCount);
        for (int i = 0; i < Input.touchCount; i++)
        {
            result += string.Format("{0} touchPos : {1} , fingerId : {2} \r\n", i, Input.touches[i].position, Input.touches[i].fingerId);
        }
        test.text = result;
    }
}