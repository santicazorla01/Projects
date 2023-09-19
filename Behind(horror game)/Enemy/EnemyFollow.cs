using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [Header("Player Position")]
    public NavMeshAgent enemy;
    public Transform Player;

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(Player.position);              //--------------Sets enemy destination to the player (FOLLOW)
    }
}
