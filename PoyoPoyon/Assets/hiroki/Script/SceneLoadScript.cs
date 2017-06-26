using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SceneLoadScript : MonoBehaviour
{

    public int SceneSpeed = 4;

    void Start()
    {
        AudioManager.Instance.PlayBGM("title");
        Move.soldierStartFlg = false;
    }
    //void Update()
    //{
    //    //画面のどこかをクリックしたときにゲーム開始
    //    if (Input.GetMouseButtonDown(0))
    //    {

    //        Move.soldierStartFlg = true;
    //        AudioManager.Instance.PlaySE("iyoo");
    //        Invoke("title", SceneSpeed);
    //        AudioManager.Instance.FadeOutBGM();

    //    }
    //}

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

        List<RaycastResult> results = new List<RaycastResult>();

        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!IsPointerOverUIObject())
            {
                // タップ位置に何も存在しない
                Move.soldierStartFlg = true;
                AudioManager.Instance.PlaySE("iyoo");
                Invoke("title", SceneSpeed);
                AudioManager.Instance.FadeOutBGM();
            }
        }
    }

    void title()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("stageSelect");
    }
}