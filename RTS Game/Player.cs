using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;

    public HealthBar healthBar;   
    
    // Start is called before the first frame update
    void Start()
    {              
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("PlayerControlledUnits"))
        {
            TakeDamage(10f);
        }
    }

    void TakeDamage(float damage)
    {       
        Debug.Log("Dealing Damage");
        currentHealth -= damage * Time.deltaTime;
        healthBar.setHealth(currentHealth);
    }
}
