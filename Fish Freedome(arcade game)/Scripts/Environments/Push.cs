using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Push : MonoBehaviour
{
    //this function is called automatically so that it pushes it on the X axis so that they take it into account when they are going to use it
    [Header("Push Settings")]
    public float PushInterval = 3.5f;
    private bool push = false;

    private IEnumerator pushPlayer(float intreval){
        yield return new WaitForSeconds(intreval);
        push = true;
        //StartCoroutine(pushPlayer(intreval));
    }

    private void OnTriggerEnter(Collider other) {
       
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log(push);
        StartCoroutine(pushPlayer(PushInterval));
        if(push){
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.transform.right * 15);
            push = false;
        }
    }
}
