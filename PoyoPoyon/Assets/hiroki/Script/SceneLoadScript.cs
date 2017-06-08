using System.Collections;
using UnityEngine;

public class SceneLoadScript : MonoBehaviour
{

    public int SceneSpeed = 4;
    void Start()
    {
        Move.soldierStartFlg = false;
    }
    void Update()
    {
        //画面のどこかをクリックしたときにゲーム開始
        if (Input.GetMouseButtonDown(0))
        {
            Move.soldierStartFlg = true;
            Invoke("title", SceneSpeed);
        }
    }
    void title()
    {
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("main");
    }
}