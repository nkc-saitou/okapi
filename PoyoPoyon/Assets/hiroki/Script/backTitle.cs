using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backTitle : MonoBehaviour
{

    //public GameObject sceneChangeObj;

    public void TitleLoad()
    {
        //Move.soldierStartFlg = true;

        //FadeManager.Instance.LoadScene("title", 1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }

    public void StageSelectLoad()
    {
        //FadeManager.Instance.LoadScene("stageSelect", 1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("stageSelect");
    }

    public void FadeTitleLoad()
    {
        StartCoroutine(FadeTitleWait());
    }

    public void FadeStageSelectLoad()
    {
        StartCoroutine(FadeStageSelectWait());
    }

    IEnumerator FadeTitleWait()
    {
        Instantiate(Resources.Load("Prefab/okapiPrefab"));

        yield return new WaitForSeconds(2.0f);

        FadeManager.Instance.LoadScene("title", 1.0f);
    }

    IEnumerator FadeStageSelectWait()
    {
        Instantiate(Resources.Load("Prefab/okapiPrefab"));

        yield return new WaitForSeconds(2.0f);

        FadeManager.Instance.LoadScene("stageSelect", 1.0f);
    }
}