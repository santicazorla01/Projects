using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doortesting : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        
    }
    public void openDoor()
    {
        animator.SetBool("isOpen", true);
    }
}
