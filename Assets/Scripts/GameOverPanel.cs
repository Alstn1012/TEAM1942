using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public Text Text_GameResult;

    

    public void Show()
    {

        GameManager.isGameEnd = true;
        int score = GameManager.instance.score;
        transform.gameObject.SetActive(true);
        Text_GameResult.text = "Score : " + score.ToString();
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}

