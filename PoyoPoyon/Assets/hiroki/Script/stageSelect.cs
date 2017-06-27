using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSelect : MonoBehaviour
{
    public int stageNo;
    public float sceneLoadSpeed = 5.0f;

    public static bool filstTouch;
    //public static int rankingStageNo;

    void Start()
    {
        AudioManager.Instance.PlayBGM("StageSelect");
        filstTouch = true;
    }

    public void SceneLoad()
    {
        if (filstTouch)
        {
            filstTouch = false;

            //BGMフェードアウト
            AudioManager.Instance.FadeOutBGM();

            //アニメーション再生
            Move.soldierStartFlg = true;

            StartCoroutine(waitTime());
            AudioManager.Instance.PlaySE("don");
            AudioManager.Instance.FadeOutBGM();
        }
    }

    IEnumerator waitTime()
    {
        yield return new WaitForSeconds(2.0f);


        switch (stageNo)
        {
            case 0:
                SceneManager.LoadScene("main");
                RankingStageNo.rankingStageNo = 0;
                break;

            case 1:
                SceneManager.LoadScene("main");
                RankingStageNo.rankingStageNo = 1;
                break;

            case 2:
                SceneManager.LoadScene("main");
                RankingStageNo.rankingStageNo = 2;
                break;

        }
    }
}