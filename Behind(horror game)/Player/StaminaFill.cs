using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaFill : MonoBehaviour
{
    [Header("Object Render")]
    public GameObject render;

    [Header("Movement Reference")]
    public PlayerMovement playerMovement;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")                //-----------------Stamina fill to 100 with the pill object
        {
            Debug.Log("stamina fill");

            playerMovement.currentStamina = 100;
            render.gameObject.SetActive(false);
        }
    }
}
