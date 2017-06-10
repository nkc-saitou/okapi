using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //-------------------------------------------------
    // public
    //-------------------------------------------------
    public GameObject[] soldier = new GameObject[2]; //0がRight,1がLeft

    //-------------------------------------------------
    // private
    //-------------------------------------------------

    Ray2D[] ray = new Ray2D[2];
    RaycastHit2D[] hit = new RaycastHit2D[2];

    float dis = 3;

    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < soldier.Length; i++)
        {
            ray[i] = new Ray2D(transform.position, soldier[i].transform.position);

            hit[i] = Physics2D.Raycast(ray[i].origin, ray[i].direction,dis);


            if (hit[0].collider && hit[1].collider)
            {
                Debug.Log(hit[0].collider.gameObject +"  "+hit[1].collider.gameObject);

                if (hit[0].collider.tag == "rPlayer" && hit[1].collider.tag == "lPlayer")
                {
                    Destroy(gameObject);
                }
                else if(hit[1].collider.tag == "rPlayer" && hit[0].collider.tag == "lPlayer")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}