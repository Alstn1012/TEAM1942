using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Text scoreText;



    private void Update()
    {
        scoreText.text = "SCORE : " + GameManager.instance.score.ToString();
    }
}
