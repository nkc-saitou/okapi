using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //-------------------------------------------------
    // public
    //-------------------------------------------------
    public GameObject[] soldier = new GameObject[2]; //0がRight,1がLeft

    //-------------------------------------------------
    // private
    //-------------------------------------------------

    Ray[] ray = new Ray[2];
    RaycastHit2D[] hit = new RaycastHit2D[2];

    float dis = 2;



    void Start()
    {

    }

    void Update()
    {
        for (int i = 0; i < soldier.Length; i++)
        {
            hit[i] = Physics2D.Raycast(transform.position, soldier[i].transform.position,dis);

            Debug.DrawRay(transform.position, soldier[i].transform.position * dis);

            if (hit[0].collider && hit[1].collider)
            {

                if (hit[0].collider.tag == "rPlayer" && hit[1].collider.tag == "lPlayer")
                {
                    Destroy(gameObject);
                }

            }
        }
    }
}
