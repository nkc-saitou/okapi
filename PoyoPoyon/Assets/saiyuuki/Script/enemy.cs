using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //-------------------------------------------------
    // public
    //-------------------------------------------------

    //-------------------------------------------------
    // private
    //-------------------------------------------------

    List<GameObject> hitList = new List<GameObject>();

    //GameObject[] soldier = new GameObject[2]; //0がRight,1がLeft
    //Ray2D[] ray = new Ray2D[2];
    //RaycastHit2D[] hit = new RaycastHit2D[2];

    //float dis = 3;

    void Start()
    {
        //soldier[0] = GameObject.FindGameObjectWithTag("rPlayer");
        //soldier[1] = GameObject.FindGameObjectWithTag("lPlayer");
    }



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
        //for (int i = 0; i < soldier.Length; i++)
        //{
        //    ray[i] = new Ray2D(transform.position, soldier[i].transform.position);

        //    hit[i] = Physics2D.Raycast(ray[i].origin, ray[i].direction, dis);


        //    if (hit[0].collider && hit[1].collider)
        //    {

        //        if (hit[0].collider.tag == "rPlayer" && hit[1].collider.tag == "lPlayer")
        //        {
        //            Destroy(gameObject);
        //        }
        //        else if (hit[1].collider.tag == "rPlayer" && hit[0].collider.tag == "lPlayer")
        //        {
        //            Destroy(gameObject);
        //        }
        //    }
        //}

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