using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Collectables_Coins : MonoBehaviour
{
    private UI_Manager _uiManagerScript;

    private void OnEnable()
    {
        _uiManagerScript = GameObject.Find("UI_Manager").GetComponent<UI_Manager>();
    }

    private void OnTriggerEnter(Collider _collider)
    {
        if(_collider.tag == "Player")
        {
            _uiManagerScript.i_currentAmountsofCoins += 1;
            _uiManagerScript.Activate_Coin_In_UI();
            Destroy(this.gameObject);
        }
    }

   
}
