using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backTitle : MonoBehaviour
{

    public void SceneLoad()
    {
        SceneManager.LoadScene("title");
    }
}