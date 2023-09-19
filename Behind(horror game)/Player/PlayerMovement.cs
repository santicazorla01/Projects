using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Variables")]
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    [Header("Coordinates/Body")]
    [SerializeField] private Transform FeetTransform;
    [SerializeField] private Rigidbody PlayerBody;
    [SerializeField] private Transform PlayerCamera;

    [Header("Movement Properties")]
    [SerializeField] private float Speed = 3;
    [SerializeField] private float Sensitivity;

    [Header("Moving audio")]
    public bool moving;
    public AudioSource footsteps;

    [Header("Stamina")]
    public float maxStamina = 100;
    public float currentStamina;
    public StaminaBar staminaBar;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;

        currentStamina = maxStamina;
        staminaBar.setMaxStamina(maxStamina);
    }

    void Update()                                //--------------Movimiento del player y la camara
    {
        PlayerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        if (PauseMenu.GameIsPause == false)
        {
            MovePlayerCamera();
        }
        

        if (Input.GetAxis("Horizontal") > 0f || (Input.GetAxis("Vertical") > 0f))   
        {          
                moving = true;
                                     //--------------footstep audio
        }
         else
         {
                moving = false;
         }
        if (moving == false)
        {
            StartCoroutine(FootSound());
        }
    }

    private void MovePlayer()
    {
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput) * Speed;
        PlayerBody.velocity = new Vector3(MoveVector.x, PlayerBody.velocity.y, MoveVector.z);

        if (Input.GetKey(KeyCode.LeftShift))               
        {     
            UseStamina();                                    //--------------Sprint       
        }
        else
        {
            Speed = 4;
        }       
    }

    private void MovePlayerCamera()
    {
        xRot -= PlayerMouseInput.y * Sensitivity;                    //Sensibilidad de la camara
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
        PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    IEnumerator FootSound()
    {     
         footsteps.Play();
         yield return null;   
    }

    void UseStamina()
    {
        if (currentStamina > 0)
        {
            Speed = 8;
            currentStamina -= 10 * Time.deltaTime;
            staminaBar.setStamina(currentStamina);
        }
        if (currentStamina <= 0)
        {
            Speed = 4;
        }
    }
}
