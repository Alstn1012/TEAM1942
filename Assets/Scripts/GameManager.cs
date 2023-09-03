using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemyObjs;

    PlayerController player_scr;//플레이어 스크립트 가져옴
   
    public PoolManager poolManager;
    public static GameManager instance;
    
    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float curSpawnDelay;

    public int score = 0;

    void Update()
    {
        curSpawnDelay += Time.deltaTime;

        if (curSpawnDelay > maxSpawnDelay)
        {
            SpawnEnemy();
            maxSpawnDelay = Random.Range(0.5f, 2f);
            curSpawnDelay = 0;
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 1);
        int ranPoint = Random.Range(0, 4);
        Instantiate(enemyObjs[ranEnemy],
                    spawnPoints[ranPoint].transform.position,
                    spawnPoints[ranPoint].transform.rotation);
    }

    private void Awake()
    {
        instance = this;
        player_scr = player.GetComponent<PlayerController>();//플레이어 스크립트 가져옴
    }

    private void Start()
    {

    }
}
