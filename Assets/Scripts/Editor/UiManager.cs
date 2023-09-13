using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;
    public Image[] hearts;


    private void Start()
    {
        
    }
    private void Update()
    {
        scoreText.text = "SCORE : " + GameManager.instance.score.ToString();
    }

}
