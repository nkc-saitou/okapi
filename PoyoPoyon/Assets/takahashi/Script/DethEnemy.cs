using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DethEnemy : MonoBehaviour
{
    void Update()
    {
        Vector3 m_pos = transform.localPosition;
        m_pos.y -= 0.05f;
        transform.localPosition = m_pos;

        Vector3 tmp = gameObject.transform.position;
        gameObject.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);

        if (tmp.y <= -7)
        {
            Destroy(gameObject);
        }
    }
}