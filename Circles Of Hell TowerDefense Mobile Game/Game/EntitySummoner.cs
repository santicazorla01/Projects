using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySummoner : MonoBehaviour
{
    public static List<Enemy> EnemiesInGame; //Keep track of all the enemies alive within the scene
    public static List<Transform> EnemiesInGameTransform;
    public static Dictionary<int, GameObject> EnemyPrefabs; //To create multiple different types of queues for different types of enemies
    public static Dictionary<int, Queue<Enemy>> EnemyObjectsPools; 

    private static bool IsInitialized;

    public static void Init()
    {
        if (!IsInitialized)
        {
            EnemyPrefabs = new Dictionary<int, GameObject>();
            EnemyObjectsPools = new Dictionary<int, Queue<Enemy>>();
            EnemiesInGameTransform = new List<Transform>();
            EnemiesInGame = new List<Enemy>();

            EnemySummonData[] Enemies = Resources.LoadAll<EnemySummonData>("Enemies"); //Load the folder of all the enemies

            foreach (EnemySummonData enemy in Enemies)
            {
                EnemyPrefabs.Add(enemy.EnemyID, enemy.EnemyPrefab);
                EnemyObjectsPools.Add(enemy.EnemyID, new Queue<Enemy>());
            }

            IsInitialized = true;
        }
        else
        {
            Debug.Log("ENTITY SUMMONER: THIS CLASS IS ALREADY INITIALIZED");
        }

    }

    public static Enemy SummonEnemy(int EnemyID)
    {
        Enemy SummonedEnemy = null;

        if (EnemyPrefabs.ContainsKey(EnemyID))
        {
            Queue<Enemy> ReferencedQueue = EnemyObjectsPools[EnemyID];
            if(ReferencedQueue.Count > 0) //if there are enemies waiting to spawn
            {
            //Dequeue Enemy and initialize
            SummonedEnemy = ReferencedQueue.Dequeue();
            SummonedEnemy.Init();

            SummonedEnemy.gameObject.SetActive(true);

            }
            else
            {
            //Instantiate new instance of enemy and initialize
            GameObject NewEnemy = Instantiate(EnemyPrefabs[EnemyID], GameLoopManager.NodePositions[0], Quaternion.identity);
            SummonedEnemy = NewEnemy.GetComponent<Enemy>();
            SummonedEnemy.Init();

            }
        }
        else
        {
            Debug.Log($"ENTITY SUMMONER: ENEMY WITH ID OF {EnemyID} DOES NOT EXIST!");
            return null;
        }

        if(!EnemiesInGame.Contains(SummonedEnemy)) EnemiesInGame.Add(SummonedEnemy);
        if(!EnemiesInGameTransform.Contains(SummonedEnemy.transform)) EnemiesInGameTransform.Add(SummonedEnemy.transform);

        SummonedEnemy.ID = EnemyID;
        return SummonedEnemy;       
    }

    public static void RemoveEnemy(Enemy EnemyToRemove)
    {
        EnemyObjectsPools[EnemyToRemove.ID].Enqueue(EnemyToRemove);
        EnemyToRemove.gameObject.SetActive(false);
        EnemiesInGameTransform.Remove(EnemyToRemove.transform);
        EnemiesInGame.Remove(EnemyToRemove);
    }
}
