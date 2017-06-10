using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMove : MonoBehaviour {

    Vector2 wavePos;
    float waveMove = 1.5f;

	void Update ()
    {
        wavePos = transform.position;
        wavePos.y -= waveMove * Time.deltaTime;

        //ウェーブのＹ座標が０以下にならないように
        if (wavePos.y <= 0) wavePos.y = 0;

        transform.position = wavePos;
    }
}
