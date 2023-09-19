using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private UI_Inventory uiInventory;
    private Inventory inventory;

    public int iSupplies = 1000;
    public int iRandomint;
    public int iRandoSpawn;

    public float fSpeed;
    public float fSpeedRotation;
    public float fcurrentHealt;
    public float fMaxHealth;
    public float fSpawnDelay = 3;
    public float fNextSpawnTime;

    public bool bHasKey = false;
    public bool bHasWrench = false;

    public Score supp;

    public Slider Health;

    public GameObject PlayerPos;
    public GameObject DeathScreen;
    public GameObject EnemyPrefab;

    public Transform TransPlayerFront;
    public Transform TransPlayerBack;

    public ParticleSystem Ps;

    private GameMaster gm;

    public Doortesting door, door2;

    // Cached reference to the rigidbody component (required)
    Rigidbody _rigidBody;


    [Tooltip("The speed of movement for the cube")]
    public float speed = 17f;

    [Tooltip("The camera that will provide the source forward and right vectors used to calculate player movement")]
    public Camera cam;

    void Start()
    {
        fcurrentHealt = fMaxHealth;
        Health.value = fcurrentHealt;
        Health.maxValue = fMaxHealth;


    }

    private void Awake()
    {
        inventory = new Inventory();
        //Inventory.SetInventory(inventory);

        _rigidBody = GetComponent<Rigidbody>();

        // Check to see if the cam has been set
        if (cam == null)
        {
            // Grab the main camera in the scene
            cam = Camera.main;
        }
    }

    void Update()
    {
        iRandomint = Random.Range(1, 6);
        iRandoSpawn = Random.Range(1, 3);

        // Keep a local copy of the camera's right vector to save typing later on
        Vector3 right = cam.transform.right;

        // Calculate the forward vector for the player based on the world up and the camera's
        // right vector
        Vector3 forward = Vector3.Cross(right, Vector3.up);

        // Calculate the forces to be applied to the player based on player input, the speed,
        // the forward/right vectors
        Vector3 movement = Vector3.zero;
        
        movement += right.normalized * (Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        movement += forward.normalized * (Input.GetAxis("Vertical") * speed * Time.deltaTime);


        // Apply the forces to the player's rigidbody component
        _rigidBody.AddForce(movement, ForceMode.VelocityChange);
       
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, fSpeedRotation * Time.deltaTime);
        }

          if (bHasKey == true)
          {
              if (Input.GetMouseButtonDown(0))
              {
                  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  RaycastHit hit;
                  if (Physics.Raycast(ray, out hit))
                  {
                      if (hit.collider.GetComponent<BoxCollider>() != null)
                      {
                          if(hit.collider.tag == ("Block"))
                          {
                              door.openDoor();

                              bHasKey = false;
                          }

                          if (hit.collider.tag == ("Block2"))
                          {
                              door2.openDoor();

                              bHasKey = false;
                          }
                      }
                  }
              }
          }

          if (bHasWrench == true)
          {
              if (Input.GetMouseButtonDown(0))
              {
                  Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                  RaycastHit hit;
                  if (Physics.Raycast(ray, out hit))
                  {
                      if (hit.collider.GetComponent<BoxCollider>() != null)
                      {
                          if (hit.collider.tag == ("Block"))
                          {
                              Destroy(hit.collider.GetComponent<BoxCollider>());

                              bHasWrench = false;
                          }
                      }
                  }
              }
          }

          if(fcurrentHealt <= 0)
          {
              Time.timeScale = 0;
              DeathScreen.gameObject.SetActive(true);

              gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
              transform.position = gm.LastCheckpoint;
          }

          if (ShouldSpawn())
          {
              Spawn();
          }
    }
    /*private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Pickable")
        {
            Debug.Log("ENter");
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();

                    if (interactable != null)
                    {
                        interactable.ONfocused(transform);
                        interactable.InteractDiffItem();
                    }
                }
            }
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hurt")
        {
            fcurrentHealt -= 10;
            Health.value = fcurrentHealt;
            //Ps.Play();

            supp.RemovePoint();
        }
        if(other.gameObject.tag == "PanelA")
        {
            gm.PanelA = true;
        }
        if (other.gameObject.tag == "PanelB")
        {
            gm.PanelB = true;
        }
        if (other.gameObject.tag == "PanelC")
        {
            gm.PanelC = true;
        }
        if (other.gameObject.tag == "PanelD")
        {
            gm.PanelD = true;
        }

        if (other.gameObject.tag == "Pickable")
        {
            Interactable interactable = other.gameObject.GetComponent<Interactable>();
            
            if (interactable != null)
            {
                interactable.ONfocused(transform);
                interactable.InteractDiffItem();
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Hurt")
        {
            fcurrentHealt -= 10 ;
            Health.value = fcurrentHealt;
            Ps.Play();

            supp.RemovePoint();
        }
    }

    void Spawn()
    {
        fNextSpawnTime = Time.time + fSpawnDelay;

        if (iRandoSpawn == 2)
        {
            PlayerPos = (GameObject)Instantiate(EnemyPrefab, TransPlayerFront.transform.position, transform.rotation);
            
        }
        else if (iRandoSpawn == 1)
        {
            PlayerPos = (GameObject)Instantiate(EnemyPrefab, TransPlayerBack.transform.position, transform.rotation);
        }
        
        
        if(iRandomint >= 4)
        {
            Destroy(PlayerPos, 5f);
            Debug.Log("5s");
        }
        else if (iRandomint == 3)
        {
            Destroy(PlayerPos, 3f);
            Debug.Log("3s");
        }
        else if (iRandomint == 1)
        {
            Destroy(PlayerPos, 1f);
            Debug.Log("1s");
        }
        else
        {
            Destroy(PlayerPos, 0.3f);
            Debug.Log("0.3s");
        }
    }

    private bool ShouldSpawn()
    {
        return Time.time >=  fNextSpawnTime;
    }
}
