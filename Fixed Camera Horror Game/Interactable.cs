using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 2f;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void InteractDiffItem()
    {

    }

    private void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, transform.position);

            if(distance <= radius)
            {
                Debug.Log("interact");
                hasInteracted = true;
            }
        }
    }
    public void ONfocused(Transform playertransform)
    {
        isFocus = true;
        player = playertransform;
        hasInteracted = false;
    }

    public void OnDeFocus()
    {
        isFocus = false;
        hasInteracted = false;
    }

    

    private void OnDrawGizmosSelected()
    { 
       
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
