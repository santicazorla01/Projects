using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            source.enabled = true;
            source.loop = true;
        }
        else
        {
            source.enabled = false;
            source.loop = false;
        }
    }
}
