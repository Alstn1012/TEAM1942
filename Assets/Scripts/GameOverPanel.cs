using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public Text Text_GameResult;
    public Text Text_GameMaxResult;

    private GameObject planet;

    private string KeyName = "bestScore";
    public int highScore = 0;

    void Awake()
    {

    }

    public void Show()
    {

        GameObject[] planet = GameObject.FindGameObjectsWithTag("Planet");
        
        foreach (GameObject obj in planet)
        {
            Destroy(obj);
        }
        

        GameManager.isGameEnd = true;
        int score = GameManager.instance.score;
        transform.gameObject.SetActive(true);

        // 최고 점수 불러오기
        highScore = PlayerPrefs.GetInt(KeyName, 0);

        if (score > highScore)
        {
            PlayerPrefs.SetInt(KeyName, score);
            highScore = score; // 최고 점수 갱신
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
