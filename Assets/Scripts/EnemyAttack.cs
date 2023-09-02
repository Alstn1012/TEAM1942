using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bulletPrefab; // ���� �߻��� �Ѿ��� ������
    public float fireRate = 2f; // �� �ʸ��� �Ѿ��� �߻��� ������
    private float nextFireTime;

    private Transform playerTransform; // �÷��̾��� ��ġ

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // "Player" �±׸� ���� ������Ʈ�� ��ġ�� ã���ϴ�.
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
        bullet.GetComponent<Bullet>().SetTarget(playerTransform.position); // �Ѿ˿� ��ǥ ��ġ�� �����մϴ�.
    }
}

