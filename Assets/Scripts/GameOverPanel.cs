using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public Text Text_GameResult; // 게임의 결과를 표시해줄 Text Ui
    private void Awake()
    {
        transform.gameObject.SetActive(false); // 게임이 시작되면 GameOver 팝업 창을 보이지 않도록 한다.
    }

    public void Show()
    {
        int score = GameManager.instance.score; // ScoreText로 부터 현재 기록된 점수를 불러온다.
        transform.gameObject.SetActive(true); // GameOver 팝업 창을 화면에 표시 시키고
        Text_GameResult.text = "Score : " + score.ToString(); // 팝업의 점수 창에 현재 점수를 표시한다.
        FindObjectOfType<PlayerAttack>().Stop();
        FindObjectOfType<Bullet>().Stop();
        FindObjectOfType<PlayerController>().Stop(); 
    }

    public void OnClick_Retry() // '재도전' 버튼을 클릭하며 호출 되어질 함수
    {
        SceneManager.LoadScene("MainScene");
    }
}
