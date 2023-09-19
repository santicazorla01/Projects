using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public ObjectiveSystem objectiveSystem;
    public GameObject dropPoint;
    public GameObject Arrow;
    public GameObject PickUpZone;
    public int Time;
    public int Reward;
    public int PassengerID = 0;
    public bool inCar = false;
    public bool nearPlayer = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            nearPlayer = true;
            StartCoroutine(WaitForPickup());
            Debug.Log("Picking up passenger");
        }
    }

    private void OnTriggerExit(Collider col)
    {
        nearPlayer = false;
       // this.GetComponent<MeshRenderer>().enabled = true;
    }

    IEnumerator WaitForPickup()
    {

        yield return new WaitForSeconds(2.5f);
        if (nearPlayer)
        {
            this.GetComponent<MeshRenderer>().enabled = false;//desaparece al pasajero.
            Arrow.GetComponent<MeshRenderer>().enabled = false;
            PickUpZone.GetComponent<MeshRenderer>().enabled = false;

            //  AddObjective();
            Debug.Log("Picked Up Passenger!!");

            inCar = true;
            objectiveSystem.activeObject = dropPoint.transform;
            dropPoint.GetComponent<BoxCollider>().enabled = true;
            dropPoint.GetComponent<MeshRenderer>().enabled = true;
            objectiveSystem.guideArrow.SetActive(true);

        }
    }
}
