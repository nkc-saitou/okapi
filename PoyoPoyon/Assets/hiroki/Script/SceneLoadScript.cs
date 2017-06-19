using System.Collections;
using UnityEngine;

public class SceneLoadScript : MonoBehaviour
{

    public int SceneSpeed = 4;

    void Start()
    {
        AudioManager.Instance.PlayBGM("title");
        Move.soldierStartFlg = false;
    }
    void Update()
    {
        //画面のどこかをクリックしたときにゲーム開始
        if (Input.GetMouseButtonDown(0))
        {
            Move.soldierStartFlg = true;
            AudioManager.Instance.PlaySE("hit");
            Invoke("title", SceneSpeed);

        }
    }
    void title()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("stageSelect");

    }
}