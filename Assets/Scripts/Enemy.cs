using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float speed;

    public int hp;


    public PlayerController Player; 

    Rigidbody2D rigid;
    GameObject pl;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Move();
        FacePlayer();
    }

    void Move()
    {
        Vector3 dir = (pl.transform.position - transform.position).normalized;
        rigid.velocity = dir * speed;
    }

    void FacePlayer()
    {
        Vector3 direction = pl.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 90);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // ����: �÷��̾�� "Player" �±װ� �ο��Ǿ� �ֽ��ϴ�.
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.hp -= 20; // �÷��̾��� ü���� 3 ����ϴ�.

                // ü���� 0 ���Ϸ� ������ ��� �߰����� ó�� (��: ���� ���� ����)�� ������ �� �ֽ��ϴ�.
                if (player.hp <= 0)
                {
                    player.hp = 0;
                    // �÷��̾� �״� ���� ��
                }
            }
        }
    }

}
