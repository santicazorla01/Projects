using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_Rotator : MonoBehaviour
{

    public Vector3 v3_rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(v3_rotationSpeed * Time.deltaTime);
    }
}
