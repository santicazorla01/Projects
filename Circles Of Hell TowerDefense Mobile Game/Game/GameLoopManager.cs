using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class GameLoopManager : MonoBehaviour
{
    public static List<TowerBehaviour> TowersInGame;
    public static Vector3[] NodePositions;
    public static float[] NodeDistances;

    private static Queue<EnemyDamageData> DamageData;
    private static Queue<Enemy> EnemiesToRemove;
    private static Queue<int> EnemyIDsToSummon;

    private PlayerStats PlayerStatistics;

    public Transform NodeParent;
    public bool LoopShouldEnd;

    public static int spawnerCount = 0;
    public int wave;

    private void Start()
    {
        PlayerStatistics = FindObjectOfType<PlayerStats>();
        DamageData = new Queue<EnemyDamageData>();
        TowersInGame = new List<TowerBehaviour>();
        EnemyIDsToSummon = new Queue<int>();
        EnemiesToRemove = new Queue<Enemy>();
        EntitySummoner.Init();

        NodePositions = new Vector3[NodeParent.childCount];
        for (int i = 0; i < NodePositions.Length; i++)
        {
            NodePositions[i] = NodeParent.GetChild(i).position;
        }

        NodeDistances = new float[NodePositions.Length - 1];
        for (int i = 0; i < NodeDistances.Length; i++)
        {
            NodeDistances[i] = Vector3.Distance(NodePositions[i], NodePositions[i + 1]);
        }

        StartCoroutine(GameLoop());
        InvokeRepeating("SummonTest", 5f, 1f); //Beggins the waves, with each interval of time, and how much time will enemies appear between them


    }

    void SummonTest()
    {
        EnqueueEnemyIDToSummon(1); //The ID of the EnemySummonData (1)
    }

    void SummonTest2()
    {
        EnqueueEnemyIDToSummon(1); //The ID of the EnemySummonData (1)
    }

    IEnumerator GameLoop()
    {
        while(LoopShouldEnd == false)
        {
            //Spawn Enemies
            Enemy.EnemyCanSpawn = true;
         
                if (EnemyIDsToSummon.Count > 0 /*&& spawnerCount <= 10*/)
                {
                    for (int i = 0; i < EnemyIDsToSummon.Count; i++)
                    {
                         Debug.Log("se movio "+spawnerCount);
                         spawnerCount += 1;
                         EntitySummoner.SummonEnemy(EnemyIDsToSummon.Dequeue()); //Summon enemies in our game                
                    }
                } 

            //Spawn Towers

            //Move Enemies

            StartCoroutine(Enemy.MoveLoop());
                    
            //Tick Towers
            foreach (TowerBehaviour tower in TowersInGame)
            {
                tower.Target = TowerTargeting.GetTarget(tower, TowerTargeting.TargetType.First);
                tower.Tick();
            }

            //Damage Enemies
            if (DamageData.Count > 0)
            {
                for (int i = 0; i < DamageData.Count; i++)
                {
                    EnemyDamageData CurrentDamageData = DamageData.Dequeue();
                    CurrentDamageData.TargetedEnemy.Health -= CurrentDamageData.TotalDamage / CurrentDamageData.Resistance;
                    PlayerStatistics.AddMoney((int)CurrentDamageData.TotalDamage);

                    if (CurrentDamageData.TargetedEnemy.Health <= 0f)
                    {
                        EnqueueEnemyToRemove(CurrentDamageData.TargetedEnemy);
                    }
                }
            }

            //Remove Enemies    
            if (EnemiesToRemove.Count > 0)
            {
                    for (int i = 0; i < EnemiesToRemove.Count; i++)
                    {
                        EntitySummoner.RemoveEnemy(EnemiesToRemove.Dequeue());
                    }             
            }

            //Remove Towers
            yield return null;
            
        }
    }

    IEnumerator GameLoop2()
    {    

            //Spawn Enemies
            Enemy.EnemyCanSpawn = true;

            if (EnemyIDsToSummon.Count > 0 && spawnerCount == 10)
            {
                for (int i = 0; i < EnemyIDsToSummon.Count; i++)
                {
                    Debug.Log("se movio " + spawnerCount);
                    spawnerCount += 1;
                    EntitySummoner.SummonEnemy(EnemyIDsToSummon.Dequeue()); //Summon enemies in our game

                }
            }

            //Spawn Towers

            //Move Enemies

            StartCoroutine(Enemy.MoveLoop());

            //Tick Towers
            foreach (TowerBehaviour tower in TowersInGame)
            {
                tower.Target = TowerTargeting.GetTarget(tower, TowerTargeting.TargetType.First);
                tower.Tick();
            }

            //Damage Enemies
            if (DamageData.Count > 0)
            {
                for (int i = 0; i < DamageData.Count; i++)
                {
                    EnemyDamageData CurrentDamageData = DamageData.Dequeue();
                    CurrentDamageData.TargetedEnemy.Health -= CurrentDamageData.TotalDamage / CurrentDamageData.Resistance;
                    PlayerStatistics.AddMoney((int)CurrentDamageData.TotalDamage);

                    if (CurrentDamageData.TargetedEnemy.Health <= 0f)
                    {
                        EnqueueEnemyToRemove(CurrentDamageData.TargetedEnemy);
                    }
                }
            }

            //Remove Enemies    
            if (EnemiesToRemove.Count > 0)
            {
                for (int i = 0; i < EnemiesToRemove.Count; i++)
                {
                    EntitySummoner.RemoveEnemy(EnemiesToRemove.Dequeue());
                }
            }


            //Remove Towers
            yield return null;

    }

    public static void EnqueueDamageData(EnemyDamageData damageData)
    {
        DamageData.Enqueue(damageData);
    }

    public static void EnqueueEnemyIDToSummon(int ID)
    {
        EnemyIDsToSummon.Enqueue(ID);
    }

    public static void EnqueueEnemyToRemove(Enemy EnemyToRemove)
    {
        EnemiesToRemove.Enqueue(EnemyToRemove);
    }
}

public struct EnemyDamageData
{
    public EnemyDamageData(Enemy target, float damage, float resistance)
    {
        TargetedEnemy = target;
        TotalDamage = damage;
        Resistance = resistance;
    }

    public Enemy TargetedEnemy;
    public float TotalDamage;
    public float Resistance;
}
