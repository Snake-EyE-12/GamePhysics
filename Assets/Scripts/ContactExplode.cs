using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactExplode : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private float radius;
    [SerializeField] private LayerMask layerToExplode;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject explosionEffect;
    private bool hit = true;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 11 && hit)
        {
            Debug.Log("DIE");   
            //rb.AddExplosionForce(force, transform.position, radius);
            foreach (var collider in Physics.OverlapSphere(transform.position, radius, layerToExplode))
            {
                if (collider.TryGetComponent(out Rigidbody body))
                {
                    body.AddExplosionForce(force, transform.position, radius);
                }
            }
            hit = false;
            Instantiate(explosionEffect, transform.position, transform.rotation);
        }
    }
}
