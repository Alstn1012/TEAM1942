using UnityEngine;
using UnityEngine.UI;

public class MoonUIManager : MonoBehaviour
{
    public Text scoreText;



    private void Update()
    {
        scoreText.text = "SCORE : " + MoonGameManager.instance.score.ToString();
    }
}
