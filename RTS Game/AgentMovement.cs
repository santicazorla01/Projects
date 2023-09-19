using UnityEngine;
using UnityEngine.AI;

public class AgentMovement : MonoBehaviour
{
    GameObject[] UnitsToDisable;//----------------
                                //unit selection variables
    public bool selected = false;//--------------

    private Vector3 target;
    NavMeshAgent agent;

    [SerializeField]
    private float rotationSpeed;

    public Attack attack;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    //when collider is clicked--------------------------------------------------
    void OnMouseDown()
    {
        if (selected == false)   //activates and deactivates player units
        {
            UnselectUnits();
            selected = true;
            Debug.Log("on");
        }
        else if (selected == true)
        {
            selected = false;
            Debug.Log("off");
        }
    }
    //------------------------------------------------------------------------------
    // Update is called once per frame
    void Update()
    {
        if(selected == true)
        {
        SetTargetPosition();
        SetAgentPosition();
        }
        


    }

    void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(1))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        }
    }

    void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        if (attack.in_Combat == false)
        {
            Vector3 Look = transform.InverseTransformPoint(target);
            float Angle = Mathf.Atan2(Look.y, Look.x) * Mathf.Rad2Deg - 90;

            transform.Rotate(0, 0, Angle);

        }
    }

    void UnselectUnits()
    {
        UnitsToDisable = GameObject.FindGameObjectsWithTag("PlayerControlledUnits");

    
        foreach (GameObject unit in UnitsToDisable)
        {
            Debug.Log("Iwork");
            unit.GetComponent<AgentMovement>().selected = false;
            Debug.Log("units disabled");
        }

    }
}
