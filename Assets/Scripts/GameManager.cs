using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemyObjs;

    private PlayerController _playerScr;
    
    public PoolManager poolManager;
    public static GameManager Instance;

    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float minSpawnDelay;
    [FormerlySerializedAs("SpawnDelay_sub_parsec")] public float spawnDelaySubPersec;

    public float curSpawnDelay;

    public int score = 0;


    public static bool IsGameEnd = false;

    [FormerlySerializedAs("enemy_speed_add_persec")] public float enemySpeedAddPersec;
    public static float EnemySpeed = 1;

    private void Start()
    {
        Instance = this;
    }

    void Update()
    {
        EnemySpeed += Time.deltaTime * enemySpeedAddPersec;
        maxSpawnDelay -= Time.deltaTime * spawnDelaySubPersec;
        maxSpawnDelay = Mathf.Max(maxSpawnDelay, minSpawnDelay);
        if (!GameManager.IsGameEnd)
        {
            curSpawnDelay += Time.deltaTime;

            if (curSpawnDelay > maxSpawnDelay)
            {
                SpawnEnemy();
                curSpawnDelay = 0;
            }
        }
        else
        {
            EnemySpeed = 1f;
            Destroy(gameObject);
            
        }

        if (score >= 4000)
        {
            SceneManager.LoadScene("ClearScene");
        }
    }

    void SpawnEnemy()
    {
        int ranEnemy = Random.Range(0, 1);
        int ranPoint = Random.Range(0, 4);
        poolManager.UsePool(1 + ranEnemy, spawnPoints[ranPoint].position, spawnPoints[ranPoint].rotation);
    }

    private void Awake()
    {
        Instance = this;
        _playerScr = player.GetComponent<PlayerController>();
    }
}

