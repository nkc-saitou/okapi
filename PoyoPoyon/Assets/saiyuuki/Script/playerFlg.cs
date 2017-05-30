using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerFlg : MonoBehaviour {

    //--------------------------------------------------
    // public
    //--------------------------------------------------

    public int soldierNo;

    public static bool[] soldierFlg = new bool[2];

    //--------------------------------------------------
    // private
    //--------------------------------------------------

    bool waitFlg = true;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if(hit.tag == "pl_collider")
        {
            waitFlg = false;

            soldierFlg[soldierNo] = true;
            Debug.Log(soldierFlg[0]);

            //StartCoroutine(waitTime());
        }
    }

    //IEnumerator waitTime()
    //{
    //    yield return new WaitForSeconds(3.0f);
    //    waitFlg = true;
    //}
}
