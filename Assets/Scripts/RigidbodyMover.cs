using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMover : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private Vector3 force;
    [SerializeField] private ForceMode forceMode;
    [SerializeField] private Vector3 torque;
    [SerializeField] private ForceMode torqueMode;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            rb.AddForce(Vector3.up, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(force, forceMode);
            rb.AddTorque(torque, torqueMode);
        }
        
    }
}
