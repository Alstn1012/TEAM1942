using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public PlayerController player;

    [Header("Player ����")]
    public int hp = 100;
    public HPManager hpManager; // HPManager ��ũ��Ʈ ����

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
        hp = hpManager.maxHP; // HPManager�� maxHP�� �����ͼ� �ʱ�ȭ
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            hpManager.TakeDamage(1);
            hp = hpManager.currentHP;

            if (hp <= 0)
            {
                Debug.LogError("���� ����");
                // ���� ���� �Ǵ� �ٸ� ���� ó���� �����ϸ� �˴ϴ�.
                // ���� ��� Application.Quit(); �� ����Ͽ� ���� ���� ����
                Application.Quit(); // �� ���ÿ����� ������ �����Ŵ
            }
        }
    }
}
