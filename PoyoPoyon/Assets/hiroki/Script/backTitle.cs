using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backTitle : MonoBehaviour
{

    public void TitleLoad()
    {
        SceneManager.LoadScene("title");
    }

    public void StageSelectLoad()
    {
        SceneManager.LoadScene("stageSelect");
    }
}