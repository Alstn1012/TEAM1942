using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    public int maxHP = 3; // 최대 체력
    public int currentHP; // 현재 체력

    public Text hpText; // 화면에 표시할 텍스트
    public GameObject[] hearts; // Heart 오브젝트 배열

    public GameOverPanel gameOver;

    public void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
        Debug.Log(hearts.Length);
        
    }

    public void Update()
    {
        if (currentHP <= 0)
        {
            gameOver.GetComponent<GameOverPanel>().Show();
        }
    }


    public void TakeDamage(int damageAmount)
    {
        print(currentHP);
        currentHP -= damageAmount;
        UpdateHPText();

        for (int i = 0; i < hearts.Length; i++)
        { 
            hearts[i].SetActive(false);
        }
        // HP가 감소할 때마다 Heart 오브젝트를 숨김
        for (int i = 0; i < currentHP; i++)
        {
            hearts[i].SetActive(false);
        }
        for (int i = 0; i < currentHP; i++)
        {
            if (i >= currentHP)
            {
                hearts[i].SetActive(false);
            }
            hearts[i].SetActive(true);

               hearts[i].SetActive(true);
        }
    }

    public int GetCurrentHP()
    {
        return currentHP;
    }

    private void UpdateHPText()
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + GetCurrentHP().ToString();
        }
    }
}
