using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    PlayerController player_scr;//플레이어 스크립트 가져옴
    public static GameManager instance;
    public PoolManager poolManager;

    public int score = 0;

    private void Awake()
    {
        instance = this;
        player_scr = player.GetComponent<PlayerController>();//플레이어 스크립트 가져옴
    }

    private void Start()
    {
        player_scr.Init();
    }


}
