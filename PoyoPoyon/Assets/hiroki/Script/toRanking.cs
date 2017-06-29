using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toRanking : MonoBehaviour {

    public void title()
    {
        //FadeManager.Instance.LoadScene("ranking", 1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("ranking");

    }

    public void credit()
    {
        //FadeManager.Instance.LoadScene("Credit", 1.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Credit");
    }
}
