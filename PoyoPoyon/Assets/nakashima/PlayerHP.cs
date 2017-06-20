using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject[] HP;
    int hpNo; //hp配列の番号
    
    void Start ()
    {
		for(int i = 0; i< HP.Length; i++)
        {
            HP[i].SetActive(false);
        }
	}

	void Update ()
    {
		
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
}
