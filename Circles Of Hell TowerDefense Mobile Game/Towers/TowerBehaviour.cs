using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{
    public LayerMask EnemiesLayer; 

    public Enemy Target; //refer to target
    public Transform TowerPivot; //rotate tower to enemy

    public int SummonCost = 100;
    public float Damage;
    public float Firerate;
    public float Range;
    private float Delay; //Time before perform an action (do damage to an enemy)

    private IDamageMethod CurrentDamageMethodClass;

    // Start is called before the first frame update
    void Start()
    {
        CurrentDamageMethodClass = GetComponent<IDamageMethod>();

        if(CurrentDamageMethodClass == null)
        {
            Debug.LogError("TOWERS No damage class attached to given tower!");
        }
        else
        {
            CurrentDamageMethodClass.Init(Damage, Firerate);
        }

        Delay = 1 / Firerate;
    }

    public void Tick()
    {
        CurrentDamageMethodClass.DamageTick(Target);

        if(Target != null) //if target exist rotate tower pivot to enemy
        {
            TowerPivot.transform.rotation = Quaternion.LookRotation(Target.transform.position - transform.position);
        }
    }

}
