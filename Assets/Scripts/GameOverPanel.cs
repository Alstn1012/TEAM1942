using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public Text Text_GameResult; // ������ ����� ǥ������ Text Ui
    private void Awake()
    {
        transform.gameObject.SetActive(false); // ������ ���۵Ǹ� GameOver �˾� â�� ������ �ʵ��� �Ѵ�.
    }

    public void Show()
    {
        int score = GameManager.instance.score; // ScoreText�� ���� ���� ��ϵ� ������ �ҷ��´�.
        transform.gameObject.SetActive(true); // GameOver �˾� â�� ȭ�鿡 ǥ�� ��Ű��
        Text_GameResult.text = "Score : " + score.ToString(); // �˾��� ���� â�� ���� ������ ǥ���Ѵ�.
        FindObjectOfType<PlayerAttack>().Stop();
        FindObjectOfType<Bullet>().Stop();
        FindObjectOfType<PlayerController>().Stop(); 
    }

    public void OnClick_Retry() // '�絵��' ��ư�� Ŭ���ϸ� ȣ�� �Ǿ��� �Լ�
    {
        SceneManager.LoadScene("MainScene");
    }
}
