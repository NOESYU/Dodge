using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float surviveTime;
    public bool isGameOver;

    public GameObject gameOverText;
    public Text timeText;
    public Text recordText;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0f;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int)surviveTime;
        }

        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameOver = true;

        // Active GameOverText
        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if (bestTime < surviveTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        recordText.text = "Best Record : " + (int)bestTime;
    }

    public void Restart()
    {
        
    }
}
