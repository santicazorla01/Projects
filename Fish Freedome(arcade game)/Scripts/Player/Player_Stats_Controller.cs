using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stats_Controller : MonoBehaviour
{

    public float f_maxPlayerHP;
    private float f_currentPlayerHP;
    public bool b_gameStarted;
    public bool b_playerExitSafeArea;

    private UI_Manager _uiManagerScript;
    private Game_Manager _gameManagerScript;

    private void OnEnable()
    {
        _gameManagerScript = GameObject.Find("Game_Manager").GetComponent<Game_Manager>();
        _uiManagerScript = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
        _uiManagerScript.SetMaxSliderValue(f_maxPlayerHP);
        f_currentPlayerHP = f_maxPlayerHP;
    }

    private void Update()
    {
        b_gameStarted = _gameManagerScript.b_enableControlls;
        if (b_gameStarted)
        {
            if (b_playerExitSafeArea)
            {
                if (f_currentPlayerHP > 0)
                {
                    _uiManagerScript.SetSliderValue(f_currentPlayerHP);
                    f_currentPlayerHP -= Time.deltaTime;
                }
                else if (f_currentPlayerHP <= 0)
                {
                    _gameManagerScript.b_playerDied = true;
                }
            }
            else if (!b_playerExitSafeArea)
            {
                if(f_currentPlayerHP > 0)
                {
                    if(f_currentPlayerHP <= f_maxPlayerHP)
                    {
                        _uiManagerScript.SetSliderValue(f_currentPlayerHP);
                        f_currentPlayerHP += Time.deltaTime;
                    }
                }
            }
        }
    }
}
