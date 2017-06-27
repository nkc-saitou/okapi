using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingImage : MonoBehaviour {

    public RankingDate[] rankingDate;

    public Sprite[] scoreNum;

    public Image[] filstNUMImage;
    public Image[] secondNIMImage;
    public Image[] thildNUMImage;

    int[] rank = new int[3];

    Color a_color;

    public List<int> filstLis = new List<int>();
    public List<int> secondLis = new List<int>();
    public List<int> thildLis = new List<int>();

    void Start()
    {

    }

    void Update ()
    {
        FilstRankingImage();
        SecondRankingImage();
        ThildRankingImage();
    }

    //--------------------------------------------
    // 一番上
    //--------------------------------------------
    void FilstRankingImage()
    {
        rank[0] = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[0]);

        if (rank[0] <= 10)
        {
            a_color.a = 0;
            filstNUMImage[1].color = a_color;
        }
        else
        {
            a_color.a = 1;
            filstNUMImage[1].color = a_color;
        }

        filstLis = new List<int>();

        int digit = rank[0];

        while (digit != 0)
        {
            rank[0] = digit % 10;
            digit = digit / 10;
            filstLis.Add(rank[0]);
        }


        for(int i = 0; i< filstLis.Count; i++)
        {
            filstNUMImage[i].sprite = scoreNum[filstLis[i]];
        }
    }

    //--------------------------------------
    // にばんめ
    //---------------------------------------
    void SecondRankingImage()
    {
        rank[1] = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[1]);

        if (rank[1] <= 10)
        {
            a_color.a = 0;
            secondNIMImage[1].color = a_color;
        }
        else
        {
            a_color.a = 1;
            secondNIMImage[1].color = a_color;
        }

        secondLis = new List<int>();

        int digit = rank[1];

        while (digit != 0)
        {
            rank[1] = digit % 10;
            digit = digit / 10;
            secondLis.Add(rank[1]);
        }


        for (int i = 0; i < secondLis.Count; i++)
        {
            secondNIMImage[i].sprite = scoreNum[secondLis[i]];
        }
    }

    void ThildRankingImage()
    {
        rank[2] = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[2]);

        if (rank[2] <= 10)
        {
            a_color.a = 0;
            thildNUMImage[1].color = a_color;
        }
        else
        {
            a_color.a = 1;
            thildNUMImage[1].color = a_color;
        }

        thildLis = new List<int>();

        int digit = rank[2];

        while (digit != 0)
        {
            rank[2] = digit % 10;
            digit = digit / 10;
            thildLis.Add(rank[2]);
        }

        for (int i = 0; i < thildLis.Count; i++)
        {
            thildNUMImage[i].sprite = scoreNum[thildLis[i]];
        }
    }
}
