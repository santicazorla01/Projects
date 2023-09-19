using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item", menuName = "Inventory/Item" )]
public class Items : ScriptableObject
{
    new public string name = "New Item";
    public int ID;
    public Sprite icon = null;


    public virtual void Use()
    {
        Debug.Log("using item");
    }
}
