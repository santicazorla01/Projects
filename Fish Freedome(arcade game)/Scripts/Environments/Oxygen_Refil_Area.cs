using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen_Refil_Area : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<Player_Stats_Controller>().b_playerExitSafeArea = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<Player_Stats_Controller>().b_playerExitSafeArea = true;
        }
    }
}
