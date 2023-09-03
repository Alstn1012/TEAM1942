using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Image[] hearts; // Heart ������Ʈ �迭
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
        if (gameObject.CompareTag("Enemy"))  // �浹�� ������Ʈ�� ������ Ȯ��
        {
            DecreaseLife();
        }
    }

    private void DecreaseLife()
    {
        currentLives--;

        if (currentLives >= 0)
        {
            Destroy(hearts[currentLives]);  // ���� ����� �ش��ϴ� GameObject ����
        }

        if (currentLives <= 0)
        {
            SceneManager.LoadScene("GameOverScene"); // ���� ���� ���� (�÷��̾� ���, �� ���ε� ��)
        }
    }
}
