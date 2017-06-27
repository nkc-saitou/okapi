using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRankImage : MonoBehaviour {

    public Image scoreRank;

    public Sprite[] rankImage; //0が一番悪い

	void Start ()
    {
		
	}
	
	void Update ()
    {
		if(ScoreManager.Instance.DoseScore < 1)
        {
            scoreRank.sprite = rankImage[0];
        }
        else if(ScoreManager.Instance.DoseScore >= 1 && ScoreManager.Instance.DoseScore <=5)
        {
            scoreRank.sprite = rankImage[1];
        }
        else if(ScoreManager.Instance.DoseScore > 5 && ScoreManager.Instance.DoseScore <=9)
        {
            scoreRank.sprite = rankImage[2];
        }
        else if(ScoreManager.Instance.DoseScore > 9)
        {
            scoreRank.sprite = rankImage[3];
        }
	}
}
