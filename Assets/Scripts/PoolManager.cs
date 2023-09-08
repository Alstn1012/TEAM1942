using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public Transform bulletpool;
    public Transform enemypool;
    public Transform[] pools;

    public GameObject bullet;

    public GameObject player;


    private void Awake()
    {
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < pools.Length; j++)
            {
                Transform newBullet = Instantiate(pools[j].GetComponent<PoolInfo>().prefab.transform, transform.position, gameObject.transform.rotation,
                    pools[j].transform);
                newBullet.gameObject.SetActive(false);
            }
        } 
    }

    public void UsePool(int poolObject,Vector3 spawnPos, quaternion spawnRot)
    {
        for (int i = 0; i < 25; i++)
        {

            Transform thisPool = pools[poolObject].GetChild(i);

            if (thisPool.gameObject.activeSelf == false)
            {
                thisPool.gameObject.SetActive(true);
                thisPool.position = spawnPos;
                thisPool.rotation = spawnRot;
                return;
            }
            
        }
    }
}
