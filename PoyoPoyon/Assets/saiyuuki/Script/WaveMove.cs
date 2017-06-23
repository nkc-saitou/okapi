using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveMove : MonoBehaviour {

    const float border = 10;

    public static bool WaveMoveEnd = false;

    public bool hurdleFlg = false; //enemyだったらfalse,障害物だったらtrue
    Vector2 wavePos;
    float waveMove;

    float LimitTime;
    public float MaxLimit;
    public static bool weveEnd = false;
    public static float timeScaleX;

    void Start()
    {
        if (hurdleFlg) waveMove = 2.5f;
        else if (hurdleFlg == false) waveMove = 1.5f;
        LimitTime = MaxLimit;
    }

    void Update()
    {

        wavePos = transform.position;
        wavePos.y -= waveMove * Time.deltaTime;

        if (weveEnd == false)
        {
            //ウェーブのＹ座標が０以下にならないように
            if (wavePos.y <= 0 && hurdleFlg == false)
            {
                WaveMoveEnd = true;
                wavePos.y = 0;
            }

            if (WaveMoveEnd == true)
            {
                LimitTime -= Time.deltaTime;
                timeScaleX = LimitTime / MaxLimit;
            }

            if (LimitTime <= 0)
            {
                weveEnd = true;
            }
        }

        transform.position = wavePos;


        if (transform.localPosition.y < -border && hurdleFlg)
        {
            Destroy(gameObject);

        }

        if (transform.position.y < -border && hurdleFlg == false)
        {
            //時間進行リセット
            LimitTime = MaxLimit;
            weveEnd = false;
            WaveMoveEnd = false;

            foreach (Transform obj in gameObject.transform)
            {
                Destroy(obj.gameObject);

            }
        }

    }
}
