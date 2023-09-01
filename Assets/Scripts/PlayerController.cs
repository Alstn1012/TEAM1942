using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    [Header("Player 세팅")]
    public int hp;
    public HPManager hpManager; // HPManager 스크립트 참조

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Init();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        Vector2 direction1 = new Vector2(Horizontal, 0);
        transform.position = (Vector2)transform.position + direction1 * speed * Time.deltaTime;

        float Vertical = Input.GetAxis("Vertical");
        Vector2 direction2 = new Vector2(0, Vertical);
        transform.position = (Vector2)transform.position + direction2 * speed * Time.deltaTime;
    }

    public void Init()
    {
        speed = 6f;
        hp = hpManager.maxHP; // HPManager의 maxHP를 가져와서 초기화
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hpManager.TakeDamage(1);
            hp = hpManager.currentHP;

            if (hp <= 0)
            {
                Debug.LogError("게임 종료");
                // 게임 종료 또는 다른 종료 처리를 수행하면 됩니다.
                // 예를 들어 Application.Quit(); 을 사용하여 게임 종료 가능
                Application.Quit(); // 이 예시에서는 게임을 종료시킴
            }
        }
    }
}
