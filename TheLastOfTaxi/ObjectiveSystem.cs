using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveSystem : MonoBehaviour
{

    public List<GameObject> Rutas = new List<GameObject>();

    public GameManager gameManager;
    public GameObject guideArrow;
    public int ruta = 0;
    public Transform activeObject;

    public List<Passenger> passengerList = new List<Passenger>();

    private void Awake()
    {
        UpdateObjectives(ruta);
        //guideArrow = GameObject.FindGameObjectWithTag("GuideArrow").GetComponent<GuideArrow>();
    }

    void UpdateObjectives(int Ruta)
    {
        if(Ruta < Rutas.Count)
        { 
            foreach (GameObject rutasObj in Rutas)
            {
                rutasObj.SetActive(false);
            }

            passengerList.Clear();

            Rutas[Ruta].SetActive(true);

            foreach (GameObject passengerObj in GameObject.FindGameObjectsWithTag("Passenger"))
            {
                passengerList.Add(passengerObj.gameObject.GetComponent<Passenger>());
            }
        }
    }

    private void Update()
    {
        if (activeObject)
        {
            guideArrow.transform.LookAt(activeObject);
        }
        else if (passengerList.Count >0){

            guideArrow.transform.LookAt(passengerList[0].transform);
        }
    }


    public void CompleteObjective(Passenger myPassenger)
    {
        
        Debug.Log("Objective number" + myPassenger.PassengerID + " is completed");
        activeObject = null;

        //Give Reward
        gameManager.gameScore += myPassenger.Reward;
        gameManager.timeLeft += myPassenger.Time;

        passengerList.Remove(myPassenger);    
           
        if(passengerList.Count <= 0)
        {
            Debug.Log("Objective Complete");
            ruta++;
            UpdateObjectives(ruta);
        }

        guideArrow.SetActive(false);
    }
}

    
