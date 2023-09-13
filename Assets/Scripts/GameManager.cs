using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemyObjs;

    PlayerController player_scr;

    public PoolManager poolManager;
    public static GameManager instance;

    public Transform[] spawnPoints;

    public float maxSpawnDelay;
    public float minSpawnDelay;
    public float SpawnDelay_sub_persec;

    public float curSpawnDelay;

    public int score = 0;


    public static bool isGameEnd = false;

    public float enemy_speed_add_persec;
    public static float enemy_speed = 1;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        enemy_speed += Time.deltaTime * enemy_speed_add_persec;
        maxSpawnDelay -= Time.deltaTime * SpawnDelay_sub_persec;
        maxSpawnDelay = Mathf.Max(maxSpawnDelay, minSpawnDelay);
        if (!GameManager.isGameEnd)
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
            enemy_speed = 1f;
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
        instance = this;
        player_scr = player.GetComponent<PlayerController>();
    }
}

