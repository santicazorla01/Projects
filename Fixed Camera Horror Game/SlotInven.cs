using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class SlotInven : MonoBehaviour
{
    public Button removeButton;
    Items item;
    public Image ItemIcon;
    public PlayerMovement player;

    public void AddItem(Items newItem)
    {
        item = newItem;

        ItemIcon.sprite = item.icon;
        ItemIcon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        ItemIcon.sprite = null;
        ItemIcon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnremoveItems()
    {
        Inventory.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        if(item != null)
        {
            if(item.name == "Food")
            {
                player.fcurrentHealt += 40;
                player.Health.value = player.fcurrentHealt;

                Inventory.instance.RemoveItem(item);
            }
            if(item.name == "Jeringa")
            {
                StartCoroutine("PrimerCoutine");

                Debug.Log("your speed is now double");

                Inventory.instance.RemoveItem(item);
            }

            if(item.name == "Key")
            {
               player.bHasKey = true;

                Inventory.instance.RemoveItem(item);
            }
            if (item.name == "Wrench")
            {
                player.bHasWrench = true;
            }
            
        }
    }

    IEnumerator PrimerCoutine()
    {

        player.fSpeed = 6f;

        yield return new WaitForSeconds(4.0f);

        player.fSpeed = 3f;
    }
}
