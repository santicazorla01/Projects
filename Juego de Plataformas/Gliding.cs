using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gliding : MonoBehaviour
{
    public Movement Player;
    //La velocidad al planear
    [SerializeField]
    private float m_FallSpeed = 2f;

    private Rigidbody2D m_Rigidbody2D = null;

    // Awake is called before Start function
    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGliding && m_Rigidbody2D.velocity.y < 0f && Mathf.Abs(m_Rigidbody2D.velocity.y) > m_FallSpeed)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, Mathf.Sign(m_Rigidbody2D.velocity.y) * m_FallSpeed);
        }
        //Planear al presionar "G" 
        if (Input.GetKey(KeyCode.G))
        {
            StartGliding();
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            StopGliding();
        }
        
    }

    public void StartGliding()
    {
        IsGliding = true;
        Player.isGliding = true;
    }
    public void StopGliding()
    {
        IsGliding = false;
        Player.isGliding = false;
    }

    // Confirmar si esta planeando el personaje
    public bool IsGliding { get; set; } = false;

    
}
