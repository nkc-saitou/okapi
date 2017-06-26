using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingStageNo : MonoBehaviour {

    public int buttonNo;
    public static int rankingStageNo;

	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public void StageRankings()
    {
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

            case 3:
                rankingStageNo = 3;
                break;

            case 4:
                rankingStageNo = 4;
                break;

            case 5:
                rankingStageNo = 5;
                break;
        }
    }
}
