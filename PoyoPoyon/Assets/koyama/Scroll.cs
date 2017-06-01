using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour{

    //--------------------------------------
    // 定数
    //--------------------------------------

    const float WARP_POS =10.4f;

    //--------------------------------------
    // public
    //--------------------------------------
    [SerializeField,Range(0,0.04f)]
    public float speed = 0.04f;
    public GameObject[] stage;
	

	void Update ()
    {
        for(int i=0; i<stage.Length;i++)
        {
            stage[i].transform.Translate(0, -speed, 0);

            if (stage[i].transform.position.y < -WARP_POS)
            {
                stage[i].transform.position = new Vector3(0, WARP_POS, 0);
            }
        }
	}

}
