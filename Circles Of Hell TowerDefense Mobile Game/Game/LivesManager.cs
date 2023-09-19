using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI LivesDisplayText;
    [SerializeField] private int StartingLives;
    private int CurrentLives;

    // Start is called before the first frame update
    void Start()
    {
        CurrentLives = StartingLives;
        LivesDisplayText.SetText($"Lives = {StartingLives}");
    }

    void OnTriggerEnter(Collider other)
    {
        if (CurrentLives >= 1)
        {
            if (other.CompareTag("LoseLive"))
            {
                Debug.Log("You lose a life");
                CurrentLives -= 1;
                LivesDisplayText.SetText($"Lives = {CurrentLives}");
            }
        }
        else
        {
            //GameLoopManager.LoopShouldEnd = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
        }
    }
}
