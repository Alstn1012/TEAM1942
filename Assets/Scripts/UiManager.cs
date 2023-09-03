using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Image[] hearts; // Heart 오브젝트 배열
    private int currentLives;


    private void Start()
    {
        currentLives = hearts.Length;
    }
    private void Update()
    {
        scoreText.text = "SCORE : " + GameManager.instance.score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Enemy"))  // 충돌한 오브젝트가 적인지 확인
        {
            DecreaseLife();
        }
    }

    private void DecreaseLife()
    {
        currentLives--;

        if (currentLives >= 0)
        {
            Destroy(hearts[currentLives]);  // 현재 목숨에 해당하는 GameObject 삭제
        }

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("GameOverScene"); // 게임 오버 로직 (플레이어 사망, 씬 리로드 등)
        }
    }
}
