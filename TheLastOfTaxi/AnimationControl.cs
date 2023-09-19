using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    public GameObject car;
    ArcadeVehicleController carController;

    void Update()
    {
        if (Input.GetButtonDown("Brake"))
        {
            car.GetComponent<Animator>().SetTrigger("Brake");
        }
    }
}