using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static Score instance;

    public int iSupplies = 1000;
    //public int HighScore = 0;

    public Text scoreText;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    //public Text HighScoreText;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //HighScore = PlayerPrefs.GetInt("highScore", 0);

        iSupplies = PlayerPrefs.GetInt("highScore", 1000);

        scoreText.text = iSupplies.ToString();
        //HighScoreText.text = HighScore.ToString() + " HIGHSCORE";
    }

    public void RemovePoint()
    {
        iSupplies -= 30;
        scoreText.text = iSupplies.ToString();
        /*if (HighScore < score)
        {
            PlayerPrefs.SetInt("highScore", score);
        }*/
    }

    
}
