using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //-------------------------------------
    // 定数
    //-------------------------------------

    const float FLICK_DIRECTION = 20; //フリックする距離

    //-------------------------------------
    // public
    //-------------------------------------

    public GameObject[] soldier;

    //-------------------------------------
    // private
    //-------------------------------------

    Ray ray;
    RaycastHit2D hit;

    GameObject[] touchObj = new GameObject[2]; //0がRight,1がLeft
    GameObject clickObj;

    Vector3[] soldierStartPos = new Vector3[2]; //初期位置
    Vector3 touchStartPos;
    Vector3 touchEndPos;

    bool[] touchFlg = new bool[2];

    ClickState clickState = 0;

    void Start()
    {
        for(int i =0;i<2;i++)
        {
            soldierStartPos[i] = soldier[i].transform.position;
            touchFlg[i] = false;
        }
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            foreach (Touch t in Input.touches)
            {

                switch (t.phase)
                {
                    //タッチしたとき
                    case TouchPhase.Began:
                        Touch(t.fingerId);
                        break;

                    //タッチされているとき
                    case TouchPhase.Moved:
                        TouchDrag(t.fingerId);
                        break;

                    //タッチされていないとき
                    case TouchPhase.Ended:
                        TouchEnd(t.fingerId);
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
    void Touch(int id)
    {
        //rayを生成
        ray = Camera.main.ScreenPointToRay(Input.touches[id].position);
        //rayの衝突判定
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        for (int i = 0; i < 2; i++)
        {
            if (hit.collider)
            {
                ////rayがあたったオブジェクトを保存
                //touchObj[id] = hit.collider.gameObject;
                if (hit.collider.gameObject == soldier[i])
                {
                    touchFlg[i] = true;
                }

                //else if(hit.collider.gameObject == soldier[1])
                //{
                //    touchFlg[1] = true;
                //}
            }
        }
    }

    void TouchDrag(int id)
    {
        //タッチした位置を保存
        Vector3 TouchPos = Input.touches[id].position;
        TouchPos.z = 10;
        //タッチした位置をワールド座標へ変換
        Vector3 soldierObjPos = Camera.main.ScreenToWorldPoint(TouchPos);

        if (touchFlg[id])
        {
            soldierObjPos.x = soldierStartPos[id].x;
            soldier[id].transform.position = soldierObjPos;
        }

        if (hit.collider == null && touchFlg[id])
        {
            touchFlg[id] = false;
        }
        

        //if(touchFlg[1])
        //{
        //    soldierObjPos.x = soldierStartPos[1].x;
        //    soldier[1].transform.position = soldierObjPos;
        //}
    }

    void TouchEnd(int id)
    {

        //if (hit.collider == null && touchFlg[id])
        //{
        //    touchFlg[id] = false;
        //}
        
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
            //状態をドラッグに
            clickState = ClickState.Drag;
        }
    }

    void MouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            for (int soilderNo = 0; soilderNo < 2; soilderNo++)
            {
                Vector3 clickPos = Input.mousePosition;
                clickPos.z = 10;

                if (clickObj == soldier[soilderNo])
                {
                    //クリックした位置へ移動させる
                    Vector3 soilderPos = Camera.main.ScreenToWorldPoint(clickPos);
                    soilderPos.x = soldierStartPos[soilderNo].x;
                    soldier[soilderNo].transform.localPosition = soilderPos;
                    Flick();
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //状態をクリック待ちにする
            clickState = ClickState.Click;
        }
    }

    void Flick()
    {
        //マウスをクリックしたポジションの保存
        if(Input.GetMouseButtonDown(0))
        {
            touchStartPos = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Input.mousePosition.z);
        }
        //マウスから指を離したポジションの保存
        else if(Input.GetMouseButtonUp(0))
        {
            touchEndPos = new Vector3(
                Input.mousePosition.x,
                Input.mousePosition.y,
                Input.mousePosition.z);
        }

        GetDirection();
    }

    void GetDirection()
    {
        float dir = touchEndPos.x - touchStartPos.x;
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
}