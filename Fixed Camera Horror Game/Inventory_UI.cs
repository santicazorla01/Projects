using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{

    public Transform itemParent;

    Inventory inventory;

    SlotInven[] slot;
    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;

        inventory.OnItemCall += UpdateUI;

        slot = itemParent.GetComponentsInChildren<SlotInven>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for(int i = 0; i<slot.Length; i++)
        {
            if(i< inventory.items.Count)
            {
                slot[i].AddItem(inventory.items[i]);
            }
            else
            {
                slot[i].ClearSlot();
            }
        } 
    }
}
