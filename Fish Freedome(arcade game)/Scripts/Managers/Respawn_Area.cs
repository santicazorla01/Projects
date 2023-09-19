using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Area : MonoBehaviour
{
    public Transform t_respawnPoint;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {   
        if(other.tag == "Player")
        {
            other.transform.position = t_respawnPoint.position;
        }
    }
}
