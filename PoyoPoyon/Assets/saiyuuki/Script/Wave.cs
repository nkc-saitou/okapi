using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wave : MonoBehaviour {

    //-----------------------------------------
    // public
    //-----------------------------------------

    public GameObject[] wave;
    public GameObject[] hurdle;

    public GameObject hurdleManager;

    public Animator endImage;
    public int limitWave;

    public WaveMove waveMove;

    public Slider slider;

    public static bool limitResetFlg = false; //WaveMove

    //-----------------------------------------
    // private
    //-----------------------------------------

    int waveNo = 0;
    int nowWave = 0;

    float LimitTime;

	void Start ()
    {
        StartCoroutine(WaveStart());
    }

    void Update()
    {
        if (WaveMove.WaveMoveEnd)
        {
            slider.value = WaveMove.timeScaleX;
        }
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
            yield return new WaitForSeconds(1.0f);

            //５回ウェーブ来るまで続ける
            if (limitWave > nowWave)
            {
                //ウェーブ生成
                GameObject waves = Instantiate(wave[waveNo], wave[waveNo].transform.localPosition,wave[waveNo].transform.rotation);
                GameObject hurdles = Instantiate(hurdle[waveNo], wave[waveNo].transform.localPosition, wave[waveNo].transform.rotation);

                //生成したウェーブを指定したオブジェクトの子にする
                waves.transform.parent = transform;
                hurdles.transform.parent = hurdleManager.transform;

                //子オブジェクトの数が０になるまで処理を止める
                while (waves.transform.childCount != 0)
                {
                    yield return new WaitForEndOfFrame();
                }


                //子オブジェクトが０になったらウェーブを削除
                Destroy(waves);

                WaveMove.WaveMoveEnd = false;
                limitResetFlg = true;

                //ウェーブの配列の要素
                waveNo++;
                //現在のウェーブ数
                nowWave++;

                //ウェーブの上限数がきたらリザルトシーンに遷移
                if (limitWave == nowWave)
                {
                    AudioManager.Instance.FadeOutBGM();

                    yield return new WaitForSeconds(1.0f);
                    endImage.SetBool("endFlg", true);

                    yield return new WaitForSeconds(2.0f);
                    Move.soldierStartFlg = true;
                    AudioManager.Instance.PlaySE("mainEnd");

                    yield return new WaitForSeconds(3.0f);
                    SceneManager.LoadScene("result");
                }
                
                //ウェーブ数が配列の要素数を超えたらウェーブ数を０に戻す
                if (wave.Length <= waveNo)
                {
                    waveNo = 0;
                }
            }
        }
    }
}
