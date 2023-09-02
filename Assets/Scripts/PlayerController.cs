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
        float Vertical = Input.GetAxis("Vertical");
        Vector2 direction2 = new Vector2(Horizontal, Vertical);
        rigid.velocity = direction2 * speed;

        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);

    }

    public void Init()
    {
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
