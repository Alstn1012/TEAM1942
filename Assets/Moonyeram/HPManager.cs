using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public int maxHP = 3; // 최대 체력
    public int currentHP; // 현재 체력

    public Text hpText; // 화면에 표시할 텍스트
    public GameObject[] hearts; // Heart 오브젝트 배열

    public void Start()
    {
        currentHP = maxHP;
        UpdateHPText();
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        UpdateHPText();

        // HP가 감소할 때마다 Heart 오브젝트를 숨김
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i >= currentHP)
            {
                hearts[i].SetActive(false);
            }
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
