using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton

    public static Inventory instance;

    private void Awake()
    {
        if(instance != null)
        {
            return;
        }

        instance = this;
    }

    #endregion


    public delegate void OnItemchanged();
    public OnItemchanged OnItemCall;

    public int space = 8;

    public List<Items> items = new List<Items>();

    public bool Add(Items item)
    {
        if(items.Count >= space)
        {
            return false;
        }
        items.Add(item);

        if(OnItemCall != null)
        {
            OnItemCall.Invoke();
        }

        return true;
    }

    public void RemoveItem(Items item)
    {
        items.Remove(item);
        if (OnItemCall != null)
        {
            OnItemCall.Invoke();
        }
    }
}
