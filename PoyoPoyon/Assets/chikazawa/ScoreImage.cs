using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreImage : MonoBehaviour {


    public Sprite[] scoreNum;

    public Image[] scoreNUMImage;

    int score;

    Color a_color;

    public List<int> Lis = new List<int>();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FilstRankingImage();

    }

    void FilstRankingImage()
    {
        score = Mathf.FloorToInt(ScoreManager.Instance.Score);

        if (score <= 10)
        {
            a_color.a = 0;
            scoreNUMImage[1].color = a_color;
        }
        else
        {
            a_color.a = 1;
            scoreNUMImage[1].color = a_color;
        }

        Lis = new List<int>();

        int digit = score;

        while (digit != 0)
        {
            score = digit % 10;
            digit = digit / 10;
            Lis.Add(score);
        }


        for (int i = 0; i < Lis.Count; i++)
        {
            scoreNUMImage[i].sprite = scoreNum[Lis[i]];
        }
    }

}
