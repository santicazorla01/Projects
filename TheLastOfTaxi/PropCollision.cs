using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropCollision : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "IaCar" && collision.gameObject.tag == "Player")
        {
            rb.mass = 10f;
            rb.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
        }
    }
}