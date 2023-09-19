using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_Select_Button : MonoBehaviour
{

    public RawImage[] ri_stageCardCollectedCoin;
    public GameObject go_stage_Lock;

    public int amountOfCoinToUnlock;
    private int totalAmountOfCoins;

    int i_currentAmountsofCoins;// <- Esta variable tiene que ser la que esta conectada en el save system

    public void Start()
    {
        go_stage_Lock = GetComponent<GameObject>();
    }

    public void Update()
    {
        Unlock_Button();
    }

    public void Unlock_Button()
    {
        if(totalAmountOfCoins >= amountOfCoinToUnlock)
        {
            go_stage_Lock.SetActive(false);
        }
    }

    public void Activate_Coin_In_UI()
    {
        switch (i_currentAmountsofCoins)
        {
            case 1:
                ri_stageCardCollectedCoin[0].gameObject.SetActive(true);
                break;
            case 2:
                ri_stageCardCollectedCoin[1].gameObject.SetActive(true);
                break;
            case 3:
                ri_stageCardCollectedCoin[2].gameObject.SetActive(true);
                break;
        }
    }

    /*public object SaveState()
    {
        return new SaveData()
        {
            i_currentAmountsofCoins = Stage_Select_Button.i_currentAmountsofCoins
        };
    }

    public void LoadState(object state)
    {
        var saveData = (SaveData)state;
        i_currentAmountsofCoins = saveData.i_currentAmountsofCoins;
    }

    [Serializable]
    private struct SaveData
    {
        public int i_currentAmountsofCoins;
    }¨*/

}
