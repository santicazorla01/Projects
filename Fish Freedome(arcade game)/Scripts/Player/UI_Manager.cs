using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour, ISavable
{
    public Slider s_slider;

    // COMENTARIO PARA IAN
    // Caballero aqui es donde se esta sacando la variable de cuantas monedas el pleyer recolecto en el nivel
    public int i_maxAmountofCoinsCollected; // <--- Esta es la variable, si la cambias avisame por que tambien hay que cambiarla en el codigo "Stage_Selec_Button"
    public int i_currentAmountsofCoins;
    public int currentLevel;
    public int coinCount1;
    public int coinCount2;
    public int coinCount3;

    public int currentLevelNumber;

    public RawImage[] ri_CollectedCoin;

    void Update()
    {
        switch (currentLevel)
        {
            case 1:
                coinCount1 = i_maxAmountofCoinsCollected;
                break;
            case 2:
                coinCount2 = i_maxAmountofCoinsCollected;
                break;
            case 3:
                coinCount3 = i_maxAmountofCoinsCollected;
                break;
        }
    }

    public void SetMaxSliderValue(float _health)
    {
        s_slider.maxValue = _health;
        s_slider.value = _health;
    }

    public void SetSliderValue(float _health)
    {
        s_slider.value = _health;
    }

    public void Activate_Coin_In_UI()
    {
        switch (i_currentAmountsofCoins)
        {
            case 1:
                ri_CollectedCoin[0].gameObject.SetActive(true);
                break;
            case 2:
                ri_CollectedCoin[1].gameObject.SetActive(true);
                break;
            case 3:
                ri_CollectedCoin[2].gameObject.SetActive(true);
                break;
        }
    }

    public object SaveState()
    {
        return new SaveData()
        {
            i_maxAmountofCoinsCollected = this.i_maxAmountofCoinsCollected
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        i_maxAmountofCoinsCollected = saveData.i_maxAmountofCoinsCollected;
    }

    [Serializable]
    private struct SaveData
    {
        public int i_maxAmountofCoinsCollected;
    }
}
