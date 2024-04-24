using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    private string status;
    private Vector3 contact;
    private Vector3 normal;
    [SerializeField] private GameObject explosion;
    private void OnCollisionEnter(Collision other)
    {
        status = "collision enter: " + other.gameObject.name;
        contact = other.GetContact(0).point;
        normal = other.GetContact(0).normal;
        Instantiate(explosion, contact, Quaternion.LookRotation(normal));
    }

    private void OnCollisionStay(Collision other)
    {
        status = "collision stay: " + other.gameObject.name;
    }

    private void OnCollisionExit(Collision other)
    {
        status = "collision exit: " + other.gameObject.name;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        status = "trigger enter: " + other.gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        status = "trigger stay: " + other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        status = "trigger exit: " + other.gameObject.name;
    }


    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);
        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(contact, 0.1f);
        Gizmos.DrawLine(contact, contact + normal);
    }
}
