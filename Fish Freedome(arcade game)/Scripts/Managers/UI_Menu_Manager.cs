using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Menu_Manager : MonoBehaviour
{
    private Game_Manager manager;

    public GameObject go_pauseMenu;
    public GameObject go_victoryScreen;
    public GameObject go_gameoverScreen;

    private bool b_gamePaused;

    // Start is called before the first frame update
    void Start()
    {

        b_gamePaused = false;
        manager = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        manager.acticateWinScreen.AddListener(Enable_Victory_Screen);
        manager.activateGameOverScreen.AddListener(Enable_GameOver_Screen);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!b_gamePaused)
            {
                Enable_Pause_Menu();
            }
            else Enable_Pause_Menu();
        }
    }

    public void Enable_Pause_Menu()
    {
        b_gamePaused = true;
        go_pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Disable_Pause_Menu()
    {
        b_gamePaused = false;
        Time.timeScale = 1;
        go_pauseMenu.SetActive(false);
    }

    public void Enable_Victory_Screen()
    {
        go_victoryScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Enable_GameOver_Screen()
    {
        go_gameoverScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Return_to_Main_Menu()
    {
        SceneManager.LoadScene("Main_Screen");
        Time.timeScale = 1;
    }

    public void Quit_Game()
    {
        Application.Quit();
    }

    public void Start_Game()
    {
        SceneManager.LoadScene("Level_01_Scene");
        Time.timeScale = 1;

    }
}
