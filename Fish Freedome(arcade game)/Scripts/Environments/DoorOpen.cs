using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [Header("References")]
    public Animator anim;
    //press A or B to Open or Close de Door
    // you can use OnCollisionEnter but you have to make the reference from this same script
    //inside the door and if you do it prefab you must use the funtion this.GameObject
    private void Update() {
        if(Input.GetKeyDown(KeyCode.A)){
            anim.SetBool("OpenDoor", true);
        }
        if(Input.GetKeyDown(KeyCode.B)){
            anim.SetBool("OpenDoor", false);
        }
    }
    
}
