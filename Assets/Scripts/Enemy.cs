using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public PlayerController Player;


    public HPManager HPManager;


    public float speed = 3f;

    float speed2 = 1f;

    float angd = 0f;

    float pang = 0f;

    Rigidbody2D rigid;
    GameObject pl;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        pl = GameObject.FindGameObjectWithTag("Player");
        HPManager = FindObjectOfType<HPManager>();

    }

    void Update()
    {
        if (!GameManager.IsGameEnd)
        { 
            Move();
            FacePlayer();
        }
    }

    void Move()
    {
        Vector3 dir = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (pang)), Mathf.Sin((pang) * Mathf.Deg2Rad), 0).normalized;
        rigid.velocity = dir * speed* GameManager.EnemySpeed* speed2;


    }

    void FacePlayer()
    {
        Vector3 direction = (pl.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        float[] dum1 = new float[3];
        Vector3 dumv;
        RaycastHit2D hit;

        for (int i = 0; i < 3; i++) {
            dumv = new Vector3(Mathf.Cos(Mathf.Deg2Rad * (pang+(-45+i*45))), Mathf.Sin((pang + (-45 + i * 45)) * Mathf.Deg2Rad), 0).normalized;
            hit = Physics2D.RaycastAll(rigid.position+ new Vector2(Mathf.Cos(Mathf.Deg2Rad * (pang + (-45 + i * 45))), Mathf.Sin((pang + (-45 + i * 45)) * Mathf.Deg2Rad)).normalized*1, dumv * 10).Where(h => h.transform.tag == "Planet" || h.transform.tag == "Enemy").FirstOrDefault();
            Debug.DrawRay(rigid.position, dumv * 10, Color.red);
            dum1[i] = 100;
            if (hit.collider != null)
            {
                dum1[i] = hit.distance;
            }

        }
        angd *= 0.995f;
        if (dum1[1] < 1)
        {
            speed2 *= 0.95f;
        }
        else
        {
            speed2 += (1- speed2)/10;
        }
        if (dum1[0] < dum1[2])
        {
            angd += 0.5f;
        }
        else if (dum1[0] > dum1[2])
        {
            angd -= 0.5f;
        }
        else if (dum1[1] < 1)
        {
            angd += 2f;
        }
        pang = angle + angd;

        transform.rotation = Quaternion.Euler(0, 0, angle + 90 + angd);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            HPManager.TakeDamage(1);
        }
    }
}
