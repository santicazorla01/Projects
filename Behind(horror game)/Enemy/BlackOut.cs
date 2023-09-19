using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    public GameObject blackOutSquare;

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, float fadeSpeed = 1.5f)
    {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack)
        {
            while (blackOutSquare.GetComponent<Image>().color.a < 1)                           //--------------ACTIVATE BLACKOUT       
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            while (blackOutSquare.GetComponent<Image>().color.a > 0)                         //--------------DEACTIVATE BLACKOUT
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            blackOutSquare.SetActive(true);
            StartCoroutine(FadeBlackOutSquare(true));                              //--------------TRIGGER
            StartCoroutine(BlackOutTime());
        }
    }
    IEnumerator BlackOutTime()
    {
        yield return new WaitForSeconds(1.5f);                                     //--------------TIME BEWTEEN ACTIVATING AND DEACT.    
        StartCoroutine(FadeBlackOutSquare(false));
    }
}
