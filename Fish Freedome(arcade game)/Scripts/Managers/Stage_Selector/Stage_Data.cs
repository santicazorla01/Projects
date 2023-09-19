using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Level_Data", menuName = "Levels")]
public class Stage_Data : ScriptableObject
{
    public int levelNumber;
    public int coinsCollected;

    private Stage_Data()
    {
        levelNumber = 0;
        coinsCollected = 0;
    }
}
