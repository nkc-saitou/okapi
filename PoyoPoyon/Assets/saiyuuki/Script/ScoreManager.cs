using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{

    private float m_score;

    public float Score
    {
        set
        {
            m_score = value;
        }
        get
        {
            return m_score;
        }
    }

    public void ScoreReset()
    {
        m_score = 0;
    }
}
