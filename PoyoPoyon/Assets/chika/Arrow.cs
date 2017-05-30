//-------------------------------------------------------------------------------------------------------
// アタッチしたオブジェクトをクリックした位置に向かせるスクリプト
//-------------------------------------------------------------------------------------------------------
using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{

    Vector3 position;
    Vector3 clickposition;
    Vector3 Arrowposition;
    Vector3 diff;
    Vector3 ArrowAngle;
    float angle;

    float z;
    void Update()
    {
        position = Input.mousePosition;

        Arrowposition = Camera.main.WorldToScreenPoint(transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            clickposition = position;

            diff = clickposition - Arrowposition;

            angle = Mathf.Atan2(diff.y, diff.x);

            ArrowAngle = new Vector3(0, 0, angle * Mathf.Rad2Deg);
        }

        z = Mathf.LerpAngle(transform.eulerAngles.z, ArrowAngle.z, 0.1f);

        transform.eulerAngles = new Vector3(0, 0, z);
    }

}