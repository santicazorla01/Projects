using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject playerMovement;

    public GameObject CameraOn;
    public GameObject CameraOff;


    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        CameraOn.SetActive(true);
        CameraOff.SetActive(false);

        if(other.gameObject.tag == "Player")
        {
            playerMovement.GetComponent<PlayerMovement>().cam = CameraOn.GetComponent<Camera>();
        }
    }
}
