using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingStageNo : MonoBehaviour {

    public int buttonNo;
    public static int rankingStageNo;

    //public Image stageImage;
    //public Sprite stageRankingImage; //0初級

	void Start ()
    {
        //stageImage.sprite = stageRankingImage;
    }
	
	void Update ()
    {
		
	}

    public void StageRankings()
    {
        //stageImage.sprite = stageRankingImage;

        switch (buttonNo)
        {
            case 0:
                rankingStageNo = 0;
                break;

            case 1:
                rankingStageNo = 1;
                break;

            case 2:
                rankingStageNo = 2;
                break;
        }
    }
}
