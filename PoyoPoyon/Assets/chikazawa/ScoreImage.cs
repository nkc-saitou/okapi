using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreImage : MonoBehaviour {


    public Sprite[] scoreNum;

    public Image[] scoreNUMImage;

    int score;

    Color color_a;
    Color color;

    public List<int> Lis = new List<int>();

    // Use this for initialization
    void Start ()
    {
        color_a.a = 0;
        color.a = 1;
	}
	
	// Update is called once per frame
	void Update ()
    {
        FilstRankingImage();

    }

    void FilstRankingImage()
    {
        score = Mathf.FloorToInt(ScoreManager.Instance.Score);

        if (score < 10)
        {
            scoreNUMImage[1].color = color_a;
            scoreNUMImage[2].color = color_a;
        }
        else if (score >= 10 && score < 100)
        {
            scoreNUMImage[1].color = color;
            scoreNUMImage[2].color = color_a;
        }
        else
        {
            scoreNUMImage[1].color = color;
            scoreNUMImage[2].color = color;
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

        if (Lis.Count == 0)
        {
            scoreNUMImage[0].sprite = scoreNum[0];
        }
    }

}
