using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    //-------------------------------------
    // public
    //-------------------------------------
    public GameObject[] soilder;
    //-------------------------------------
    // private
    //-------------------------------------
    Ray ray;
    RaycastHit2D hit;

    GameObject clickObj;

    Vector3[] soilderStartPos = new Vector3[2]; //初期位置

    ClickState state = 0;

    void Start()
    {
        for(int i =0;i<2;i++)
        {
            soilderStartPos[i] = soilder[i].transform.position;
        }
    }

    void Update()
    {
        if (Input.touchSupported)
        {
            foreach (Touch t in Input.touches)
            {
                int id = t.fingerId;

                switch (t.phase)
                {
                    //タッチしたとき
                    case TouchPhase.Began:
                        break;

                    //タッチされているとき
                    case TouchPhase.Moved:
                        break;

                    //タッチされていないとき
                    case TouchPhase.Ended:
                        break;
                }
            }
        }
        else
        {
            switch (state)
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
            state = ClickState.Drag;
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

                if (clickObj == soilder[soilderNo])
                {
                    //クリックした位置へ移動させる
                    Vector3 soilderPos = Camera.main.ScreenToWorldPoint(clickPos);
                    soilderPos.x = soilderStartPos[soilderNo].x;
                    soilder[soilderNo].transform.localPosition = soilderPos;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //状態をクリック待ちにする
            state = ClickState.Click;
        }
        
    }


    enum ClickState
    {
        Click = 0,
        Drag
    }
}