using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int gameScore = 0;
    public int timeLeft = 80;
    public Text timeText;

    private void Start()
    {
        gameScore = 0;
        timeLeft = 80;

        if(gameScore == 0)
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        StartCoroutine("LoseTime");
    }

    void Update()
    {
        if (timeLeft <= 0)
        {
            timeText.text = "TIMES UP!";
            StopGame();
        }
        else
        {
            timeText.text = "" + timeLeft;
        }
       
        if (gameScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", gameScore);
        }
    }

    public void StopGame()
    {
        StopCoroutine("LoseTime");
        Invoke("SceneLoader", 3);   
    }

    private void SceneLoader()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}