using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public float hp = 5;
    public float hpMax = 5;
    public float attackTime = 1.0f;

    bool hpFlg = true;

    public override void EnemySetting()
    {
        ////base.EnemySetting();

        StartCoroutine(AttackTime());

        if (hpFlg)
        {
            Destroy(effectSmoke);
            hp -= 1;
            hpFlg = false;
        }

        if (hp <= 0)
        {
            Destroy(gameObject);

            Score.scoreCountFlg = true;
            memoryTime = scoreTime;

            Debug.Log(memoryTime);

            scoreTime = 0;

            PlayerMove.flickState_R = "returnMove";
            PlayerMove.flickState_L = "returnMove";
        }

        PlayerMove.flickState_R = "returnMove";
        PlayerMove.flickState_L = "returnMove";

        foreach (Transform n in gameObject.transform)
        {
            GameObject.Destroy(n.gameObject);
        }

    }

    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(attackTime);

        hpFlg = true;
    }
}