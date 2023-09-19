using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [Header("CheckPoint Load/Reference")]
    private static GameMaster instance;
    public Vector2 LastCheckpoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);                //--------------Saves last checkpoint
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
