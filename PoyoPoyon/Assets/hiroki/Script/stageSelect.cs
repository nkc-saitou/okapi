using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stageSelect : MonoBehaviour
{
    public int stageNo;

    public void SceneLoad()
    {
        switch (stageNo)
        {
            case 1:
                SceneManager.LoadScene("main");
                break;

            case 2:
                SceneManager.LoadScene("main2");
                break;

            case 3:
                SceneManager.LoadScene("main");
                break;

            case 4:
                SceneManager.LoadScene("main");
                break;

            case 5:
                SceneManager.LoadScene("main");
                break;

            case 6:
                SceneManager.LoadScene("main");
                break;
        }
    }
}