using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponents : MonoBehaviour
{
    public GameObject enableTargetObject;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Debug.Log("component added");

            enableTargetObject.GetComponent<Gliding>().enabled = true;

        }
    }
}
