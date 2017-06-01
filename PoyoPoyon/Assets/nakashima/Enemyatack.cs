using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyatack : MonoBehaviour
{
    public GameObject bulletPrefab;

    private float attackInterval = 2f;
    private float turretRotationSmooth = 0.8f;
    private float lastAttackTime;

    private Transform player;

    // Use this for initialization
    void Start ()
    {
        // 始めにプレイヤーの位置を取得できるようにする
        player = GameObject.FindWithTag("Player").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // 一定間隔で弾丸を発射する
        if (Time.time > lastAttackTime + attackInterval)
        {
            Instantiate(bulletPrefab);
            lastAttackTime = Time.time;
        }
    }
}
