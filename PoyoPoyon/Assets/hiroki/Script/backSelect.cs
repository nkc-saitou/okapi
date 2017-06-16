using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backSelect : MonoBehaviour
{

    public void SceneLoad()
    {
        SceneManager.LoadScene("stageSelect");
    }
}
