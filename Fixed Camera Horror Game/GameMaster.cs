using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector3 LastCheckpoint;

    public bool PanelA, PanelB, PanelC, PanelD = false;
    public GameObject LockEnding;

    void Start()
    {

    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PanelA == true && PanelB == true && PanelC == true && PanelD == true)
        {
            LockEnding.gameObject.SetActive(false);
        }
    }

}
