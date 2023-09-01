using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGameManager : MonoBehaviour
{
    public GameObject player;
    MoonPlayerController player_scr;//�÷��̾� ��ũ��Ʈ ������
    public static MoonGameManager instance;
    public MoonPoolManager poolManager;

    public int score = 0;

    private void Awake()
    {
        instance = this;
        player_scr = player.GetComponent<MoonPlayerController>();//�÷��̾� ��ũ��Ʈ ������
    }

    private void Start()
    {
        player_scr.Init();
    }


}
