using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSelect : MonoBehaviour
{
    public int stageNo;

    public static bool filstTouch;
    //public static int rankingStageNo;

    void Start()
    {
        AudioManager.Instance.PlayBGM("StageSelect");
        filstTouch = true;
    }

    public void SceneLoad(float fadetime)
    {
        if (filstTouch)
        {
            filstTouch = false;

            //BGMフェードアウト
            AudioManager.Instance.FadeOutBGM();

            Instantiate(Resources.Load("Prefab/okapiPrefab"));

            ////アニメーション再生
            //Move.soldierStartFlg = true;

            AudioManager.Instance.PlaySE("don");

            StartCoroutine(waitTime(fadetime));

        }
    }

    IEnumerator waitTime(float fadetime)
    {
        yield return new WaitForSeconds(2.0f);

        switch (stageNo)
        {
            case 0:
                FadeManager.Instance.LoadScene("main", fadetime);
                RankingStageNo.rankingStageNo = 0;
                break;

            case 1:
                FadeManager.Instance.LoadScene("main2", fadetime);
                RankingStageNo.rankingStageNo = 1;
                break;

            case 2:
                FadeManager.Instance.LoadScene("main3", fadetime);
                RankingStageNo.rankingStageNo = 2;
                break;
        }
        Debug.Log(RankingStageNo.rankingStageNo);
    }
}