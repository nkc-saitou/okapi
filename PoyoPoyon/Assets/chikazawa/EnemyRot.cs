using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRot : MonoBehaviour
{

    public Transform playerL;    //プレイヤーを代入
    public Transform playerR;
    public bool swichtarget = false;
    public Transform target; // 追いかける対象

    //Vector3 eWpos;

    // Use this for initialization
    void Start()
    {
        playerL = GameObject.FindGameObjectWithTag("lPlayer").transform;
        playerR = GameObject.FindGameObjectWithTag("rPlayer").transform;
    }


    void Update()
    {
        Vector3 p2 = target.position;
        Vector3 p1 = transform.position;
        if (swichtarget == false)
        {
            target = playerL;
        }
        else
        {
            target = playerR;
        }
        float dx = p2.x - p1.x;
        float dy = p2.y - p1.y;
        float rad = Mathf.Atan2(dy, dx);

        Vector3 ArrowAngle = new Vector3(0, 0, rad * Mathf.Rad2Deg);
        float z = Mathf.LerpAngle(transform.eulerAngles.z, ArrowAngle.z, 0.1f);
        transform.eulerAngles = new Vector3(0, 0, z);
    }
}
