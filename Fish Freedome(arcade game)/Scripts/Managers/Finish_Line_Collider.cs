using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish_Line_Collider : MonoBehaviour
{
    public bool b_playerCrossedFinishLine;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            b_playerCrossedFinishLine = true;
        }
    }
}
