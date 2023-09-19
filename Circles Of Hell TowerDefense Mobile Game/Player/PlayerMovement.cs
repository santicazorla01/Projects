using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour { 

    private Vector3 Velocity;
    private Vector3 PlayerMovementInput;
    private Vector2 PlayerMouseInput;
    private float xRot;

    public VirtualJoystick VJoystickAnalogTest;

    [SerializeField] private Transform PlayerCamera;
    [SerializeField] private CharacterController Controller;
    [Space]
    [SerializeField] private float Speed;
    [SerializeField] private float Sensitivity;


    void Update()
    {
        VJoystickAnalogTest = GameObject.Find("VirtualJoystickBase").GetComponent<VirtualJoystick>();
        if (VJoystickAnalogTest.InputDir != Vector2.zero)
        {
            PlayerMovementInput = new Vector3(VJoystickAnalogTest.inputHorizontal(), 0f, VJoystickAnalogTest.inputVertical());
        }
        else
        {
            PlayerMovementInput = Vector3.zero;
        }

        PlayerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
      
        MovePlayer();
        MovePlayerCamera();        
    }

    public void MovePlayer()
    { 
        Vector3 MoveVector = transform.TransformDirection(PlayerMovementInput);

        Controller.Move(MoveVector * Speed * Time.deltaTime);
        Controller.Move(Velocity * Speed * Time.deltaTime);

        Velocity.y = 0f;
    }

    public void up()
    {
        Velocity.y = 8f;
    }

    public void down()
    {
        Velocity.y = -8f;
    }

    public void MovePlayerCamera()
    {
        if (Input.GetMouseButton(0))
        {
            xRot -= PlayerMouseInput.y * Sensitivity;
            transform.Rotate(0f, PlayerMouseInput.x * Sensitivity, 0f);
            PlayerCamera.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);

        }
    }  
}