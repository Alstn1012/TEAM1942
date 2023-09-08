using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public Transform bulletpool;
    public Transform enemypool;

    public GameObject pre_bullet;
    public GameObject pre_enemy;

    public GameObject player;


    private void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject newBullet = Instantiate(pre_bullet, transform.position, gameObject.transform.rotation,
                    bulletpool);
            newBullet.gameObject.SetActive(false);

        }
        for (int i = 0; i < 15; i++)
        {
            GameObject newEnemy = Instantiate(pre_enemy, transform.position, gameObject.transform.rotation,
                    enemypool);
            newEnemy.gameObject.SetActive(false);
        }
    }

    public void UsePool(string PoolObject)
    {
        if (PoolObject == "bullet")
        {
            for (int i = 0; i < 15; i++)
            {
                Transform thisPool = bulletpool.GetChild(i);

                if (thisPool.gameObject.activeSelf == false)
                {
                    thisPool.gameObject.SetActive(true);
                    thisPool.position = player.transform.position;
                    thisPool.rotation = player.transform.rotation;
                    return;
                }
            }
        }
    }
}
