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

    Color color; //a値１
    Color color_a; //a値０

    public List<int> filstLis = new List<int>();
    public List<int> secondLis = new List<int>();
    public List<int> thildLis = new List<int>();

    public Image stageImage;
    public Sprite[] stageRankingImage; //0初級

    void Start()
    {
        color.a = 1;
        color_a.a = 0;
    }

    void Update ()
    {
        FilstRankingImage();
        SecondRankingImage();
        ThildRankingImage();

        stageImage.sprite = stageRankingImage[RankingStageNo.rankingStageNo];
    }

    //--------------------------------------------
    // 一番上
    //--------------------------------------------
    void FilstRankingImage()
    {
        rank[0] = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[0]);

        if (rank[0] < 10)
        {
            filstNUMImage[1].color = color_a;
            filstNUMImage[2].color = color_a;
        }
        else if(rank[0] >= 10 && rank[0] < 100)
        {
            filstNUMImage[1].color = color;
            filstNUMImage[2].color = color_a;
        }
        else
        {
            filstNUMImage[1].color = color;
            filstNUMImage[2].color = color;
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

        if(filstLis.Count == 0)
        {
            filstNUMImage[0].sprite = scoreNum[0];
        }
    }

    //--------------------------------------
    // にばんめ
    //---------------------------------------
    void SecondRankingImage()
    {
        rank[1] = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[1]);

        if (rank[1] < 10)
        {
            secondNIMImage[1].color = color_a;
            secondNIMImage[2].color = color_a;
        }
        else if (rank[1] >= 10 && rank[1] < 100)
        {
            secondNIMImage[1].color = color;
            secondNIMImage[2].color = color_a;
        }
        else
        {
            secondNIMImage[1].color = color;
            secondNIMImage[2].color = color;
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

        if (secondLis.Count == 0)
        {
            secondNIMImage[0].sprite = scoreNum[0];
        }
    }

    void ThildRankingImage()
    {
        rank[2] = Mathf.FloorToInt(rankingDate[RankingStageNo.rankingStageNo].score[2]);

        if (rank[2] < 10)
        {
            thildNUMImage[1].color = color_a;
            thildNUMImage[2].color = color_a;
        }
        else if (rank[2] >= 10 && rank[2] < 100)
        {
            thildNUMImage[1].color = color;
            thildNUMImage[2].color = color_a;
        }
        else
        {
            thildNUMImage[1].color = color;
            thildNUMImage[2].color = color;
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

        if (thildLis.Count == 0)
        {
            thildNUMImage[0].sprite = scoreNum[0];
        }
    }
}
