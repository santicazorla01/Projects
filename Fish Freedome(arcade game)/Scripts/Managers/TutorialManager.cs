using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject VictoryScreen;
    public GameObject Arrow;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("obama 2");
            Time.timeScale = 0;
            VictoryScreen.SetActive(true);
            Arrow.SetActive(false);
        }
    }

    public void GoToLevelScene()
    {
        SceneManager.LoadScene("Select_Level_Scene");
        Debug.Log("obama");
    }
}
