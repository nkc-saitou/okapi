using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backTitle : MonoBehaviour
{

    public void TitleLoad()
    {
        FadeManager.Instance.LoadScene("title", 1.0f);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("title");
    }

    public void StageSelectLoad()
    {
        FadeManager.Instance.LoadScene("stageSelect", 1.0f);
        //UnityEngine.SceneManagement.SceneManager.LoadScene("stageSelect");
    }
}