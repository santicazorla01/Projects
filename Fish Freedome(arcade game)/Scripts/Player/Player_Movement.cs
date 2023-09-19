using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    public AudioSource _audioSource;

    public Material m_redColor;
    public Material m_darkRedColor;

    public Rigidbody go_playerModel;
    public GameObject go_directionArrow;
    public Player_Collision_Detector script_collisionDetector;

    public float f_jumpForce;

    private Player_Stats_Controller _playerStatsController;

    private Color c_greenColor;
    private Color c_darkGreenColor;

    private float f_holdDownJumpButton;

    private void OnEnable()
    {
        //_audioSource.Play();
        _playerStatsController = this.gameObject.GetComponent<Player_Stats_Controller>();
        c_greenColor = go_directionArrow.GetComponent<Renderer>().materials[1].color;
        c_darkGreenColor = go_directionArrow.GetComponent <Renderer>().materials[0].color;
    }

    void Update()
    {
        if (_playerStatsController.b_gameStarted)
        {
            if (script_collisionDetector.b_playerTouchingFloor == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    f_holdDownJumpButton = Time.time;
                }
                if (Input.GetKey(KeyCode.Space))
                {
                    float f_holdDownTime = Time.time - f_holdDownJumpButton;
                    Launch_Strenght_Meter(f_holdDownTime);
                }
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    //_audioSource.Play();
                    script_collisionDetector.b_playerTouchingFloor = false;
                    Reset_Direction_Arrow_Color();
                    float f_holdDownTime = Time.time - f_holdDownJumpButton;
                    Jump(f_holdDownTime);
                }
            }
        }
    }

    private float Apply_Jump_Force(float f_holdTime)
    {
        float maxHoldDownTime = 10.0f;
        float holdTimeNormalized = Mathf.Clamp01(f_holdTime / maxHoldDownTime);
        float f_finalJumpForce = holdTimeNormalized * f_jumpForce;
        return f_finalJumpForce;
    }

    void Jump(float f_holdTime) => go_playerModel.AddForce(go_directionArrow.transform.forward * Apply_Jump_Force(f_holdTime), ForceMode.Impulse);

    private void Launch_Strenght_Meter(float f_holdTime)
    {
        float maxHoldDownTime = 120.0f;
        float holdTimeNormalized = Mathf.Clamp01(f_holdTime / maxHoldDownTime);
        float f_finalJumpForce = holdTimeNormalized * f_jumpForce;
        go_directionArrow.GetComponent<Renderer>().materials[1].color = Color.Lerp(c_greenColor, m_redColor.color, f_finalJumpForce);
        go_directionArrow.GetComponent<Renderer>().materials[0].color = Color.Lerp(c_darkGreenColor, m_darkRedColor.color, f_finalJumpForce);
    }

    private void Reset_Direction_Arrow_Color()
    {
        go_directionArrow.GetComponent<Renderer>().materials[0].color = c_darkGreenColor;
        go_directionArrow.GetComponent<Renderer>().materials[1].color = c_greenColor;
    }
}
