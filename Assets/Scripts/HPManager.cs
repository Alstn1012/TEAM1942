using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{
    public int maxHP = 3; // �ִ� ü��
    public int currentHP; // ���� ü��

    public Text hpText; // ȭ�鿡 ǥ���� �ؽ�Ʈ
    public GameObject[] hearts; // Heart ������Ʈ �迭

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
        // HP�� ������ ������ Heart ������Ʈ�� ����
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