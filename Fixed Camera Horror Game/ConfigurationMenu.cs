using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfigurationMenu : MonoBehaviour
{
    List<int> widths = new List<int>() { 568, 960, 1280, 1920 };
    List<int> heights = new List<int>() { 320, 540, 800, 1080 };

    [SerializeField] Slider volumeSlider;

    public GameObject menu;
    public Dropdown ResolutionDrop;

    public GameObject DeathScreen;
    public PlayerMovement Player;

    Resolution[] resolutions;
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;

            }
            else
            {
                Time.timeScale = 1;
            }
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetVolume(float volume)
    {
        AudioListener.volume = volumeSlider.value;
        Save();

    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetScreenSize(int Index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[Index];
        int height = heights[Index];
        Screen.SetResolution(width, height, fullscreen);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenuEsc()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;

        }
        else
        {
            Time.timeScale = 0;
        }
        menu.gameObject.SetActive(!menu.gameObject.activeSelf);
    }

    void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
    }

    public void StopDeathScreen()
    {
        Time.timeScale = 1;

        DeathScreen.gameObject.SetActive(false);

        Player.fcurrentHealt = 100;

        Player.Health.value = Player.fcurrentHealt;


    }
}
