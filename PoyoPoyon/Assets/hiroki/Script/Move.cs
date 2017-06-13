using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed;
    public static bool soldierStartFlg;

    void Start()
    {

    }
    void Update()
    {
        if (soldierStartFlg == true)
        {
            Vector2 soldierPos = transform.position;
            soldierPos.y += moveSpeed * Time.deltaTime;
            transform.position = soldierPos;
        }
    }
}