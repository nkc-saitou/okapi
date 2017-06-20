using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSelect : MonoBehaviour
{
    public int stageNo;
    public static int rankingStageNo;

    void Start()
    {
        AudioManager.Instance.PlayBGM("StageSelect");
    }

    public void SceneLoad()
    {
        //BGMフェードアウト
        AudioManager.Instance.FadeOutBGM();

        //アニメーション再生
        Move.soldierStartFlg = true;

        StartCoroutine(waitTime());
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(2.0f);

        switch (stageNo)
        {
            case 0:
                SceneManager.LoadScene("main");
                rankingStageNo = 0;
                break;

            case 1:
                SceneManager.LoadScene("main2");
                rankingStageNo = 1;
                break;

            case 2:
                SceneManager.LoadScene("main3");
                rankingStageNo = 2;
                break;

            case 3:
                SceneManager.LoadScene("main4");
                rankingStageNo = 3;
                break;

            case 4:
                SceneManager.LoadScene("main5");
                rankingStageNo = 4;
                break;

            case 5:
                SceneManager.LoadScene("main6");
                rankingStageNo = 5;
                break;
        }

    }
}