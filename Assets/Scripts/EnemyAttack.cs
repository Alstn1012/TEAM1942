using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // 적이 발사할 총알의 프리팹
    public float fireRate = 2f; // 몇 초마다 총알을 발사할 것인지
    private float nextFireTime;

    private Transform playerTransform; // 플레이어의 위치

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // "Player" 태그를 가진 오브젝트의 위치를 찾습니다.
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetTarget(playerTransform.position); // 총알에 목표 위치를 설정합니다.
    }
}

