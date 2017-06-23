using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour {

    public float maxtime;//最大値
    float nowtime;//現在値

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update () {

        //nowtime = WaveMove.LimitTime;
        if (WaveMove.WaveMoveEnd == true)
        {

        }
    }
}
