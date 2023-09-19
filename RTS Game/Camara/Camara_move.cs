using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara_move : MonoBehaviour
{
    [Header("Move Settings")]
    public float Speed = 5f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Scroll Settings")]
    [SerializeField]private Camera cam;
    private float targetZoom;
    private float zoomFactor = 3;
    private float zoomLerpSpeed = 10;

    private void Start() {
        //cam = Camera.main;
        targetZoom = cam.orthographicSize;
    }

    private void Update() {
        //-----------------------*inputs to interract
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //------------------------------*scroll
        float scrollData;
        scrollData = Input.GetAxis("Mouse ScrollWheel");
        targetZoom -= scrollData * zoomFactor;
        targetZoom = Mathf.Clamp(targetZoom, 4.5f, 8);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomLerpSpeed);
    }


    private void FixedUpdate() {
        //----------------------movment more accurate
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }
}
