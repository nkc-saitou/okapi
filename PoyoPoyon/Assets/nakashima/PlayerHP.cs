using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    public GameObject[] HP;
    int hpNo; //hp配列の番号

    public int soldierNo;

    public GameObject effect;

    Animator animator;

    public Animator endImage;

    bool filstGameOverFlg;
    
    void Start ()
    {
		for(int i = 0; i< HP.Length; i++)
        {
            HP[i].SetActive(false);
        }

        filstGameOverFlg = true;
        animator = GetComponent<Animator>();

        effect.SetActive(false);

    }

	void Update ()
    {
		if(hpNo >= HP.Length && filstGameOverFlg == true)
        {
            StartCoroutine(GameOver());
            filstGameOverFlg = false;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //障害に当たったら、ダメージを１受ける（５回当たることでゲームオーバー）
        if (other.tag == "hind")
        {
            if (hpNo < HP.Length)
            {
                if (PlayerMove.flickState_R != "returnMove" && soldierNo == 1)
                {
                    HP[hpNo].SetActive(true);
                    StartCoroutine(Damager());
                    hpNo++;
                }
                else if(PlayerMove.flickState_L != "returnMove" && soldierNo == 0)
                {
                    HP[hpNo].SetActive(true);
                    StartCoroutine(Damager());
                    hpNo++;
                }
            }
        }
    }

    IEnumerator Damager()
    {
        animator.SetBool("Damage", true);

        yield return new WaitForSeconds(1.0f);

        animator.SetBool("Damage", false);
    }

    IEnumerator GameOver()
    {
        //AudioManager.Instance.FadeOutBGM();
        effect.SetActive(true);
        AudioManager.Instance.FadeOutBGM();

        yield return new WaitForSeconds(1.0f);
        endImage.SetBool("endFlg", true);

        yield return new WaitForSeconds(2.0f);
        Move.soldierStartFlg = true;
        AudioManager.Instance.PlaySE("mainEnd");
        //AudioManager.Instance.PlaySE("mainEnd");

        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("gameOver");
    }
}
