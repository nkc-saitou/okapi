using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toRanking : MonoBehaviour {

    public void title()
    {
        SceneManager.LoadScene("ranking");

    }

    public void credit()
    {
        SceneManager.LoadScene("Credit");
    }
}
