using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : MonoBehaviour {

    const float border = 15;

    public static bool WaveMoveEnd = false;

    public bool hurdleFlg = false; //enemyだったらfalse,障害物だったらtrue
    Vector2 wavePos;
    float waveMove;

    void Start()
    {
        if (hurdleFlg) waveMove = 2.5f;
        else if (hurdleFlg == false) waveMove = 1.5f;
    }

    void Update()
    {

        wavePos = transform.position;
        wavePos.y -= waveMove * Time.deltaTime;

        //ウェーブのＹ座標が０以下にならないように
        if (wavePos.y <= 0 && hurdleFlg == false)
        {
            WaveMoveEnd = true;
            wavePos.y = 0;
        }

        transform.position = wavePos;

        if (transform.localPosition.y < -border)
        {
            Destroy(gameObject);
        }
    }
}
