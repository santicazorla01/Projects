using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection_on_click : MonoBehaviour
{
    GameObject[] UnitsToDisable ;
    GameObject unit;
    public bool selected = false;

    void UnselectUnits()
    {
        UnitsToDisable = GameObject.FindGameObjectsWithTag("PlayerControlledUnits");

        int counter;
        counter = UnitsToDisable.Length;
       
       
        foreach (GameObject unit in UnitsToDisable)
        {
            unit.GetComponent<Selection_on_click>().selected = false;
            Debug.Log("units disabled");
        }

    }


    void OnMouseDown()
    {
       


        if (selected == false)
        {
            UnselectUnits();

            selected = true;
            
            Debug.Log("on");
        }
        else if (selected == true)
        {
            selected = false;
            
            Debug.Log("off");

            
        }

    }


}
