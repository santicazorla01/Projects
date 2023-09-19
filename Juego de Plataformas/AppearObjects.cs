using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearObjects : MonoBehaviour
{
    public GameObject Enemy, Flag1, Flag2, Flag3, Flag4, Flag5, Flag6, Door, Door2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Enemy.gameObject.SetActive(true);
            Flag1.gameObject.SetActive(true);
            Flag2.gameObject.SetActive(true);
            Flag3.gameObject.SetActive(true);
            Flag4.gameObject.SetActive(true);
            Flag5.gameObject.SetActive(true);
            Flag6.gameObject.SetActive(true);
            Door.gameObject.SetActive(true);
            Door2.gameObject.SetActive(true);
        }
    }
}
