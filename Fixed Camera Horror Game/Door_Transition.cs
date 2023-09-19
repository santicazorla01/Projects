using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Transition : MonoBehaviour
{
    [Header("Door TP")]
    [SerializeField] private GameObject TPin;
    [SerializeField] private GameObject TPout;
    bool is_inside = false;
    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            anim.SetBool("Door_touch", true);

            if (is_inside == false)
            {
                other.transform.position = TPin.transform.position;
                is_inside = !is_inside;
            }
            else
            {
                other.transform.position = TPout.transform.position;
                is_inside = !is_inside;
            }
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.SetBool("Door_touch", false);

        }
    }

}
