using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Collision_Detector : MonoBehaviour
{
    public bool b_playerTouchingFloor;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Floor" || collision.collider.tag == null)
        {
            b_playerTouchingFloor = true;
        }
    }
}
