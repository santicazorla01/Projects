using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindArea : MonoBehaviour
{
    public float strength;
    public Vector3 direction;

    public bool inWindZone = false;

    private void OnTriggerStay(Collider _col)
    {
        if (_col.tag == "Player")
        {
            _col.gameObject.GetComponentInParent<Rigidbody>().AddForce(direction * strength, ForceMode.Impulse);
            inWindZone = true;
        }
    }
}
