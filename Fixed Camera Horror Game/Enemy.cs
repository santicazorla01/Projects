using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public float fCooldown = 3;
    public float fCooldownTimer;
    public float fMoveSpeed = 1f;
    public float fMindDist;

    public GameObject DamagePlayer;
 
    Transform Player;

    void Start()
    {
        Player = GameObject.Find("Player").transform;

        transform.LookAt(Player);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= fMindDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, Time.deltaTime * fMoveSpeed);
            
        }

        if (fCooldownTimer > 0)
        {
            fCooldownTimer -= Time.deltaTime;
        }
        else if (fCooldownTimer < 0)
        {
            fCooldownTimer = 0;
        }
        if(fCooldownTimer == 0)
        {
            DamagePlayer.gameObject.SetActive(true);


        }

    }
}
