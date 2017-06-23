using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    //public Text scoreText;
    public static float memoryTime;

    GameObject soldierAttackEffect;
    protected GameObject effectSmoke;

    protected float scoreTime;

    bool scoreFlg = false;
    protected bool weaponFlg = true; //オブジェクトがあったらtrue,既に消えていたらfalse

    List<GameObject> hitList = new List<GameObject>();

    void Start()
    {
        //soldierAttackEffect = Resources.Load("Smoke",typeof(GameObject)) as GameObject;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        //当たったオブジェクトが左右のおかっぴきだったら
        if(hit.tag == "rPlayer" || hit.tag == "lPlayer")
        {
            scoreFlg = true;
            //リストに追加されていないオブジェクトの場合のみリストに追加
            if(!hitList.Contains(hit.gameObject))
            {
                effectSmoke = Instantiate((GameObject)Resources.Load("Prefab/Smoke"), gameObject.transform);

                hitList.Add(hit.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if(hit.tag == "rPlayer" || hit.tag == "lPlayer")
        {
            scoreTime = 0;
            scoreFlg = false;

            if(hitList.Contains(hit.gameObject))
            {
                Destroy(effectSmoke);
                hitList.Remove(hit.gameObject);
            }
        }
    }

    void Update()
    {
        EnemyDec();
    }

    public void EnemyDec()
    {
        if (scoreFlg)
        {
            scoreTime += 1 * Time.deltaTime;
            if (scoreTime >= 1) scoreTime = 1;
        }

        if(hitList.Count >= 1)
        {
            if(hitList[0].tag == "rPlayer" || hitList[0].tag == "lPlayer")
            {
                if(weaponFlg) transform.FindChild("Attack/Attack").gameObject.SetActive(false);
            }
        }

        if(hitList.Count == 0)
        {
            if(weaponFlg)
            {
                transform.FindChild("Attack/Attack").gameObject.SetActive(true);
            }
        }

        //リストに両方のおかっぴきさんが格納されていたらオブジェクト消去
        if (hitList.Count == 2)
        {
            if (hitList[0].tag == "rPlayer" || hitList[0].tag == "lPlayer")
            {
                if (hitList[1].tag == "rPlayer" || hitList[1].tag == "lPlayer")
                {
                    Destroy(effectSmoke);
                    weaponFlg = false;
                    EnemySetting();
                }
            }
        }
    }

    public virtual void EnemySetting()
    {
        Score.scoreCountFlg = true;
        memoryTime = scoreTime;
        Debug.Log(memoryTime);
        scoreTime = 0;

        PlayerMove.flickState_R = "returnMove";
        PlayerMove.flickState_L = "returnMove";

        Destroy(gameObject);
    }
}