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
        if (collision.CompareTag("Player")) // 가정: 플레이어에게 "Player" 태그가 부여되어 있습니다.
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                player.hp -= 20; // 플레이어의 체력을 3 깎습니다.

                // 체력이 0 이하로 떨어진 경우 추가적인 처리 (예: 게임 오버 로직)를 구현할 수 있습니다.
                if (player.hp <= 0)
                {
                    player.hp = 0;
                    // 플레이어 죽는 로직 등
                }
            }
        }
    }

}
