using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject pre_bullet;
    [SerializeField] float curtime;
    public float cooltime;
    public GameManager gameManager;

    public PoolManager poolManager;

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (curtime <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                poolManager.UsePool(0, this.transform.position, this.transform.rotation);
                curtime = cooltime;
            }
        }
        curtime -= Time.deltaTime;
    }

    public void Stop()
    {
        StopAllCoroutines();
    }
}
