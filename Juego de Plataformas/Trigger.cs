using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trigger : MonoBehaviour
{
    public GameObject enableTargetObject, enableTargetObject2;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
                Debug.Log("trigger entered"); 

            enableTargetObject.gameObject.SetActive(true);
            enableTargetObject2.gameObject.SetActive(true);

        }
    }

}
