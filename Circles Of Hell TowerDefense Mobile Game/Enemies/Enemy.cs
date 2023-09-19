using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using UnityEngine.Jobs;

public class Enemy : MonoBehaviour
{
    public int NodeIndex;

    public Transform RootPart;
    public float DamageResistance = 1f;
    public float MaxHealth;
    public float Health;
    public float Speed;
    public int ID;

    public int EnemyCounter;
    public static bool EnemyCanSpawn;

    bool eventTrigger, eventTrigger2, eventTrigger3, eventTrigger4, eventTrigger5;

    public void Init()
    {
        Health = MaxHealth;
        transform.position = GameLoopManager.NodePositions[0];
        NodeIndex = 0;

    }

    private void Update()
    {
        if (GameLoopManager.spawnerCount == 25)
        {
            Debug.Log("orueba");
            MyEvent();
        }

        if (GameLoopManager.spawnerCount == 50)
        {
            Debug.Log("orueba");
            MyEvent2();
        }

        if (GameLoopManager.spawnerCount == 75)
        {
            Debug.Log("orueba");
            MyEvent3();
        }

        if (GameLoopManager.spawnerCount == 100)
        {
            Debug.Log("orueba");
            MyEvent4();
        }

        if (GameLoopManager.spawnerCount == 150)
        {
            Debug.Log("orueba");
            MyEvent5();
        }

        if (GameLoopManager.spawnerCount == 250)
        {
            Application.Quit();
        }
    }

    public void MyEvent()
    {
        if (!eventTrigger)
        {
            eventTrigger = true;
            Speed += 2;
            DamageResistance += DamageResistance;
        }
    }
    public void MyEvent2()
    {
        if (!eventTrigger2)
        {
            eventTrigger2 = true;
            DamageResistance += DamageResistance;
            MaxHealth += MaxHealth;
        }
    }

    public void MyEvent3()
    {
        if (!eventTrigger3)
        {
            eventTrigger3 = true;
            Speed += 4;
            DamageResistance += DamageResistance;
        }
    }
    public void MyEvent4()
    {
        if (!eventTrigger4)
        {
            eventTrigger4 = true;
            MaxHealth += MaxHealth;
            DamageResistance += DamageResistance;
        }
    }
    public void MyEvent5()
    {
        if (!eventTrigger5)
        {
            eventTrigger5 = true;
            Speed += 8;
            DamageResistance += DamageResistance;
            MaxHealth += MaxHealth;
        }
    }

    static public IEnumerator MoveLoop()
    {
        if (EnemyCanSpawn == true)
        {
            NativeArray<Vector3> NodesToUse = new NativeArray<Vector3>(GameLoopManager.NodePositions, Allocator.TempJob);
            NativeArray<float> EnemySpeeds = new NativeArray<float>(EntitySummoner.EnemiesInGame.Count, Allocator.TempJob);
            NativeArray<int> NodeIndices = new NativeArray<int>(EntitySummoner.EnemiesInGame.Count, Allocator.TempJob);
            TransformAccessArray EnemyAccess = new TransformAccessArray(EntitySummoner.EnemiesInGameTransform.ToArray(), 2);

            for (int i = 0; i < EntitySummoner.EnemiesInGame.Count; i++)
            {
                EnemySpeeds[i] = EntitySummoner.EnemiesInGame[i].Speed;
                NodeIndices[i] = EntitySummoner.EnemiesInGame[i].NodeIndex;
              
            }

            MoveEnemiesJob MoveJob = new MoveEnemiesJob
            {
                NodePositions = NodesToUse,
                EnemySpeed = EnemySpeeds,
                NodeIndex = NodeIndices,
                deltaTime = Time.deltaTime
            };

            JobHandle MoveJobHandle = MoveJob.Schedule(EnemyAccess);
            MoveJobHandle.Complete();

            for (int i = 0; i < EntitySummoner.EnemiesInGame.Count; i++)
            {
                EntitySummoner.EnemiesInGame[i].NodeIndex = NodeIndices[i];

                if (EntitySummoner.EnemiesInGame[i].NodeIndex == GameLoopManager.NodePositions.Length)
                {
                    GameLoopManager.EnqueueEnemyToRemove(EntitySummoner.EnemiesInGame[i]);
                }
            }

            EnemySpeeds.Dispose();
            NodeIndices.Dispose();
            EnemyAccess.Dispose();
            NodesToUse.Dispose();

            yield return null;
        }
    }

    public struct MoveEnemiesJob : IJobParallelForTransform
    {
        [NativeDisableParallelForRestriction]
        public NativeArray<Vector3> NodePositions;

        [NativeDisableParallelForRestriction]
        public NativeArray<float> EnemySpeed;

        [NativeDisableParallelForRestriction]
        public NativeArray<int> NodeIndex;

        public float deltaTime;

        public void Execute(int index, TransformAccess transform)
        {
            if (NodeIndex[index] < NodePositions.Length)
            {
                Vector3 PositionToMoveTo = NodePositions[NodeIndex[index]];
                transform.position = Vector3.MoveTowards(transform.position, PositionToMoveTo, EnemySpeed[index] * deltaTime);

                if (transform.position == PositionToMoveTo)
                {
                    NodeIndex[index]++;
                }
            }
        }
    }

}
