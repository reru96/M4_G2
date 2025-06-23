using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    private Rigidbody rb;
    public float speed = 5.0f;
    private Vector3 dir;

    public Vector3 Dir => dir;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        rb.velocity = dir * speed;
    }

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, v).normalized;
        rb.velocity = dir;
       
    }
}
