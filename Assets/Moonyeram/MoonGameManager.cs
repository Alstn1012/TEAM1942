using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGameManager : MonoBehaviour
{
    public GameObject player;
    MoonPlayerController player_scr;//플레이어 스크립트 가져옴
    public static MoonGameManager instance;
    public MoonPoolManager poolManager;

    public int score = 0;

    private void Awake()
    {
        instance = this;
        player_scr = player.GetComponent<MoonPlayerController>();//플레이어 스크립트 가져옴
    }

    private void Start()
    {
        player_scr.Init();
    }


}
