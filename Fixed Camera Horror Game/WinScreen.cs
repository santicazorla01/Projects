using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public Score supp;
    public GameObject A;
    public GameObject B;
    public GameObject C;
    public GameObject D;

    public int iLetter;

    void Start()
    {
        iLetter = supp.iSupplies;
    }

    // Update is called once per frame
    void Update()
    {
        Result();
    }

    public void Result()
    {
        if (iLetter >= 800)
        {
            A.gameObject.SetActive(true);
        }
        else if(iLetter >= 400)
        {
            B.gameObject.SetActive(true);
        }
        else if (iLetter >= 200)
        {
            C.gameObject.SetActive(true);
        }
        else
        {
            D.gameObject.SetActive(true);
        }
    }
}
