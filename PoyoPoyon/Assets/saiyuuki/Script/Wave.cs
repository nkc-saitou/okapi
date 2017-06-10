using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    //-----------------------------------------
    // public
    //-----------------------------------------

    public GameObject[] wave;

    //-----------------------------------------
    // private
    //-----------------------------------------

    private int waveNo = 0;


	void Start ()
    {
        StartCoroutine(WaveStart());
	}
	
    IEnumerator WaveStart()
    {
        //ウェーブの配列に何も格納されていなかったら終了
        if(wave.Length == 0)
        {
            yield break;
        }
        
        while(true)
        {
            yield return new WaitForSeconds(5.0f);

            //ウェーブ生成
            GameObject waves = Instantiate(wave[waveNo], wave[waveNo].transform);

            //生成したウェーブをアタッチしたオブジェクトの子にする
            waves.transform.parent = transform;

            //子オブジェクトの数が０になるまで処理を止める
            while (waves.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }

            //子オブジェクトが０になったらウェーブを削除
            Destroy(waves);

            //現在のウェーブ数
            waveNo++;

            //ウェーブ数が配列の要素数を超えたらウェーブ数を０に戻す
            if(wave.Length <= waveNo)
            {
                waveNo = 0;
            }
        }

    }
}
