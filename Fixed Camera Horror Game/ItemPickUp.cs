using UnityEngine;

public class ItemPickUp : Interactable
{
    public Items items;
    public override void InteractDiffItem()
    {
        base.InteractDiffItem();

        PickUP();
    }

    void PickUP()
    {
        bool wasPickup = Inventory.instance.Add(items);

        Debug.Log("u pick upo item");

        if (wasPickup)
        {
            Destroy(gameObject);
        }
        
    }
}
