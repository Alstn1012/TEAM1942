using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonPlayerAttack : MonoBehaviour
{
    public GameObject pre_bullet;
    [SerializeField] float curtime;
    public float cooltime;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (curtime <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Instantiate(pre_bullet, transform.position, gameObject.transform.rotation,
                    MoonGameManager.instance.poolManager.bulletpool);
                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;
    }
}
