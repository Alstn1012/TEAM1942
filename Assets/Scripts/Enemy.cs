using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float speed;

    public int hp;

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
    }

    void Move()
    {
        Vector3 dir = pl.transform.position - transform.position;
        rigid.velocity = dir * speed;
    }
}
