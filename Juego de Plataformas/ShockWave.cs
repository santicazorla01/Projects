using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour
{
    
    public GameObject ShockWaves;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject Spawn = Instantiate(ShockWaves, transform.position, Quaternion.identity) as GameObject;

            Destroy(Spawn, 0.5f);


        }
    }
}
