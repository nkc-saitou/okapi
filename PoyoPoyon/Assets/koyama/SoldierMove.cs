using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMove : MonoBehaviour {

    const float SOLDIER_WARP = 20.0f;

    Vector2 soldierPos;
    public float speed = 1.0f;

	void Start ()
    {

	}

    void Update()
    {

        soldierPos = transform.position;
        soldierPos.y += speed;

        if (soldierPos.y > SOLDIER_WARP)
        {
            soldierPos.y = -SOLDIER_WARP;
        }
        transform.position = soldierPos;


    }
}
