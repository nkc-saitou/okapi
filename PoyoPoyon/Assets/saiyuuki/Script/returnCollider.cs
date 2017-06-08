using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnCollider : MonoBehaviour {

    Ray ray;
    RaycastHit2D hit;

    public GameObject soldier;
    [SerializeField,Range(5,10)]
    int dis = 5;

    public int colNo;

	void Start ()
    {
		
	}

    void Update()
    {

        hit = Physics2D.Raycast(this.transform.position, soldier.transform.position, dis);

        Debug.DrawRay(transform.position, soldier.transform.position * dis,Color.red);

        if (colNo == 0 && hit.collider.tag == "rPlayer")
        {
            playerFlg.soldierFlg[colNo] = false;
            Debug.Log("nakaji");
        }
        else if (colNo == 1 && hit.collider.tag == "lPlayer")
        {
            playerFlg.soldierFlg[colNo] = false;
        }
    }
}
