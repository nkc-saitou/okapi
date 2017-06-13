using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    List<GameObject> hitList = new List<GameObject>();

    void OnTriggerEnter2D(Collider2D hit)
    {
        //当たったオブジェクトが左右のおかっぴきだったら
        if(hit.tag == "rPlayer" || hit.tag == "lPlayer")
        {
            //リストに追加されていないオブジェクトの場合のみリストに追加
            if(!hitList.Contains(hit.gameObject))
            {
                hitList.Add(hit.gameObject);
            }
        }
    }

    void OnTriggerExit2D(Collider2D hit)
    {
        if(hit.tag == "rPlayer" || hit.tag == "lPlayer")
        {
            if(hitList.Contains(hit.gameObject))
            {
                hitList.Remove(hit.gameObject);
            }
        }
    }

    void Update()
    {
        if (hitList.Count == 2)
        {
            if (hitList[0].tag == "rPlayer" || hitList[0].tag == "lPlayer")
            {
                if (hitList[1].tag == "rPlayer" || hitList[1].tag == "lPlayer")
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}