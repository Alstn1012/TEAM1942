using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public PlayerController Player;

    public float speed = 3f;

    Rigidbody2D rigid;
    GameObject pl;
    public MoonHPManager HPManager;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pl = GameObject.FindGameObjectWithTag("Player");
        HPManager = FindObjectOfType<MoonHPManager>();

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
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            HPManager.TakeDamage(1);
        }
    }
}
