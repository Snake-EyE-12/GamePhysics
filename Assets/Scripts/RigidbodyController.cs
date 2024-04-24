using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyController : MonoBehaviour
{

    // Update is called once per frame
    [SerializeField] private float speed;
    [SerializeField] private Space space = Space.World;
    [SerializeField] private ForceMode forceMode = ForceMode.Force;
    
    private Rigidbody rb;

    private Vector3 force;
    private Vector3 torque;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Vector3 direction = Vector3.zero;
        float rotation = 0;
        if(space == Space.World) direction.x = Input.GetAxis("Horizontal");
        else rotation = Input.GetAxis("Horizontal");
        
        direction.z = Input.GetAxis("Vertical");
        direction = Vector3.ClampMagnitude(direction, 1);


        force = direction * speed;
        torque = new Vector3(0, rotation * speed, 0);
        


    }


    private void FixedUpdate()
    {
        rb.AddRelativeForce(force, forceMode);
        rb.AddTorque(torque, forceMode);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.right);
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.up);
    }
}
