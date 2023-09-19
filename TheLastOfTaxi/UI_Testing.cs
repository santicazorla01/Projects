using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using CodeMonkey;
using UnityEngine.SceneManagement;

public class UI_Testing : MonoBehaviour
{

    public Highscore highscore;
    static bool reloaded;

    private void Start()
    {
        if (reloaded == true)
        {
            transform.Find("SubmitScoreButton").gameObject.SetActive(false);
        }

        transform.Find("SubmitScoreButton").GetComponent<Button_UI>().ClickFunc = () =>
        {
            UI_Blocker.Show_Static();

            UI_InputWindow.Show_Static("Score", PlayerPrefs.GetInt("HighScore"), () =>
            {
                // Clicked Cancel
                UI_Blocker.Hide_Static();
            }, (int score) =>
            {
                // Clicked Ok
                UI_InputWindow.Show_Static("Player Name", "", "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVXYWZ", 3, () =>
                {
                    // Cancel
                    UI_Blocker.Hide_Static();
                }, (string nameText) =>
                {
                    // Ok
                    UI_Blocker.Hide_Static();
                    highscore.GetComponent<Highscore>().AddHighscoreEntry(score, nameText);
                    Reload();                   
                });
            });
        };
        
    }
    
    public void Reload()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Time.timeScale = 2;
        reloaded = true;
    }
}

