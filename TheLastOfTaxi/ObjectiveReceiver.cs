using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveReceiver : MonoBehaviour
{
    public Passenger myPassenger;
    public ObjectiveSystem objectiveSystem;
    public GameObject DropOffZone;

    private void OnTriggerEnter(Collider col)
    {
        if (myPassenger.inCar)
        {
            DropOffZone.GetComponent<MeshRenderer>().enabled = true;

            if (col.CompareTag("Player"))
            {
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<MeshRenderer>().enabled = false;
                objectiveSystem.CompleteObjective(myPassenger);
            }
        }
         
    }
}
