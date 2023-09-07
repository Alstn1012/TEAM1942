using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 여기에는 초기화 로직만 넣어주세요.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}

