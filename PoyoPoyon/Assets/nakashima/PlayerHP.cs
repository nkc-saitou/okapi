using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public GameObject[] HP;
    int hpNo; //hp配列の番号

    public Animator endImage;
    
    void Start ()
    {
		for(int i = 0; i< HP.Length; i++)
        {
            HP[i].SetActive(false);
        }
	}

	void Update ()
    {
		if(hpNo >= HP.Length)
        {
            StartCoroutine(GameOver());
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //障害に当たったら、ダメージを１受ける（５回当たることでゲームオーバー）
        if (other.tag == "hind")
        {
            if (hpNo < HP.Length)
            {
                HP[hpNo].SetActive(true);
                hpNo++;
            }
        }
    }

    IEnumerator GameOver()
    {
        //AudioManager.Instance.FadeOutBGM();

        yield return new WaitForSeconds(1.0f);
        endImage.SetBool("endFlg", true);

        yield return new WaitForSeconds(2.0f);
        Move.soldierStartFlg = true;
        //AudioManager.Instance.PlaySE("mainEnd");

        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("gameOver");
    }
}
