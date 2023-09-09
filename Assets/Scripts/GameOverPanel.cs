using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverPanel : MonoBehaviour
{
    public Text Text_GameResult;
    public Text Text_GameMaxResult;

    private string KeyName = "bestScore";
    public int highScore = 0;

    void Awake()
    {
        highScore = PlayerPrefs.GetInt(KeyName, 0);
        Text_GameMaxResult.text = $"HIGH SCORE : {highScore.ToString()}";
    }

    public void Show()
    {
        GameManager.isGameEnd = true;
        int score = GameManager.instance.score;
        transform.gameObject.SetActive(true);
        
        if (score > highScore)
        {
            PlayerPrefs.SetInt(KeyName, score);
        }

        Text_GameResult.text = "SCORE : " + score.ToString();
        Text_GameMaxResult.text = "HIGH SCORE : " + highScore.ToString();
    }

    public void OnClick_Retry()
    {
        SceneManager.LoadScene("MainScene");
        GameManager.isGameEnd = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
