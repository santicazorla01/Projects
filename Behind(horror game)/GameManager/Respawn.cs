using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    private GameMaster gm;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Respawn")                            //--------------Switch for Respawns of all levels and FADE/BLACKOUT
        {         
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();           
            StartCoroutine(BlackOutTime());
            StartCoroutine(Reposition());

        }
        if (collision.gameObject.tag == "Respawn2")
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            StartCoroutine(BlackOutTime2());
            StartCoroutine(Reposition());

        }
        if (collision.gameObject.tag == "Respawn3")
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            StartCoroutine(BlackOutTime3());
            StartCoroutine(Reposition());

        }
        if (collision.gameObject.tag == "Respawn4")
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            StartCoroutine(BlackOutTime4());
            StartCoroutine(Reposition());
        }
    }

    IEnumerator BlackOutTime()                                            //--------------Switch for Loading scenes
    {       
        yield return new WaitForSeconds(2.5f);        
        SceneManager.LoadScene(1);
    }

    IEnumerator BlackOutTime2()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    IEnumerator BlackOutTime3()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(3);
    }

    IEnumerator BlackOutTime4()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(4);
    }
    IEnumerator Reposition()
    {
        yield return new WaitForSeconds(1.2f);                          //--------------Repositions player in checkpoint after "x" time
        transform.position = gm.LastCheckpoint;
    }
}
