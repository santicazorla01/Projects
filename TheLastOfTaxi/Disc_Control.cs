using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disc_Control : MonoBehaviour
{
   public List<GameObject> DiscList;

    public int Score ;
    private int P_Score ;
    public List<int> Numbers = new List<int>();
    public float FFA = 90f; //Forward Facing Angle

    public GameManager gameManager;

 

    private void Update()
    {
         ReadScore();
    }

    void ReadScore()
    {
        int Value;
        P_Score = gameManager.gameScore;
        //Debug.Log(P_Score);
        //Debug.Log(gameManager.gameScore);
        Numbers.Clear();
        while (P_Score > 0)
        {
            Value = P_Score % 10;
            P_Score /= 10;
            Numbers.Add(Value);
        }
        UpdateScore();
    }

    void UpdateScore()
    {
        int n;

        for (n = 0; n < Numbers.Count; n++)
        {
            if (Numbers[n] == 0) DiscList[n].transform.localEulerAngles = new Vector3(100f, 0, FFA);
            else if (Numbers[n] == 1) DiscList[n].transform.localEulerAngles = new Vector3(64f, 0, FFA);
            else if (Numbers[n] == 2) DiscList[n].transform.localEulerAngles = new Vector3(40f, 0, FFA);
            else if (Numbers[n] == 3) DiscList[n].transform.localEulerAngles = new Vector3(2.4f, 0, FFA);
            else if (Numbers[n] == 4) DiscList[n].transform.localEulerAngles = new Vector3(-31f, 0, FFA);
            else if (Numbers[n] == 5) DiscList[n].transform.localEulerAngles = new Vector3(-82f, 0, FFA);
            else if (Numbers[n] == 6) DiscList[n].transform.localEulerAngles = new Vector3(-114f, 0, FFA);
            else if (Numbers[n] == 7) DiscList[n].transform.localEulerAngles = new Vector3(-140f, 0, FFA);
            else if (Numbers[n] == 8) DiscList[n].transform.localEulerAngles = new Vector3(-173f, 0, FFA);
            else if (Numbers[n] == 9) DiscList[n].transform.localEulerAngles = new Vector3(-216f, 0, FFA);
        }
    }
}
