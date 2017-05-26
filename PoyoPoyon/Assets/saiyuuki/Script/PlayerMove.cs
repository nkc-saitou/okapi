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

    //-------------------------------------
    // public
    //-------------------------------------

    public GameObject[] soldier = new GameObject[2]; //0がRight,1がLeft
    public Text test;

    //-------------------------------------
    // private
    //-------------------------------------

    Ray ray;
    RaycastHit2D hit;

    //List<GameObject> touchObj = new List<GameObject>();
    GameObject[] touchObj = new GameObject[10];
    GameObject clickObj;

    Vector3[] soldierStartPos = new Vector3[2]; //初期位置
    Vector3 clickPos;
    float clickStartPos;
    float clickEndPos;

    ClickState clickState = 0;

    void Start()
    {
        soldierStartPos[0] = soldier[0].transform.position;
        soldierStartPos[1] = soldier[1].transform.position;
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

        if(hit.collider.tag == "rPlayer" || hit.collider.tag == "lPlayer")
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
            //rayが当たったオブジェクトを保存
            clickObj = hit.collider.gameObject;

            clickStartPos = Input.mousePosition.x;
            Debug.Log("OK");

            //状態をドラッグに
            clickState = ClickState.Drag;
        }
    }

    void MouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            for (int soldierNo = 0; soldierNo < 2; soldierNo++)
            {
                clickPos = Input.mousePosition;
                clickPos.z = 10;

                if (clickObj == soldier[soldierNo])
                {
                    //クリックした位置へ移動させる
                    Vector3 soilderPos = Camera.main.ScreenToWorldPoint(clickPos);
                    soilderPos.x = soldierStartPos[soldierNo].x;
                    soldier[soldierNo].transform.localPosition = soilderPos;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //状態をクリック待ちにする
            clickState = ClickState.Click;

            clickEndPos = Input.mousePosition.x;
            GetDirection();
        }
    }

    void GetDirection()
    {
        float dir = clickEndPos - clickStartPos;
        Debug.Log(dir);

        //右フリック
        if(FLICK_DIRECTION < dir)
        {
            //LeftObjがRightObjの方にいく処理
            
            Debug.Log("Right");
        }
        //左フリック
        else if(-FLICK_DIRECTION > dir)
        {
            //RightObjがLeftObjの方に行く処理

            Debug.Log("Left");
        }
    }


    enum ClickState
    {
        Click = 0,
        Drag
    }

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