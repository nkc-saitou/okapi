using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingStageNo : MonoBehaviour {

    public int buttonNo;
    public static int rankingStageNo;

    public Image[] button_a;

    Color a_color;
    Color color;

	void Start ()
    {
        a_color.a = 0.5f;
        color.a = 1;

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
        }
    }
}
