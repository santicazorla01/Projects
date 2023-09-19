using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game_Manager : MonoBehaviour
{
    public UnityEvent activateGameOverScreen;
    public UnityEvent acticateWinScreen;

    public bool b_enableControlls = false;
    public bool b_playerDied;

    public Finish_Line_Collider finish_Line_Collider;

    private void OnEnable()
    {
        b_playerDied = false;
        finish_Line_Collider = GameObject.Find("Finish_Line_Collider").GetComponent<Finish_Line_Collider>();
        StartCoroutine(Game_Start_Timer());
    }

    private void Update()
    {
        if (finish_Line_Collider.b_playerCrossedFinishLine)
        {
            acticateWinScreen.Invoke();
        }
        if (b_playerDied)
        {
            activateGameOverScreen.Invoke();
        }
    }

    private IEnumerator Game_Start_Timer()
    {
        WaitForSeconds wait = new WaitForSeconds(3.0f);
        while (true)
        {
            yield return wait;
            b_enableControlls = true;
        }
    }

    

}
