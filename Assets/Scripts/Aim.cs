using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    [SerializeField] private float speed = 3;
    private Vector3 rotation = Vector3.zero;
    private Vector2 prevAxis = Vector3.zero;
    [SerializeField] private float limit = 40.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        prevAxis.x = -Input.GetAxis("Mouse Y");
        prevAxis.y = Input.GetAxis("Mouse X");
    }

    private void Update()
    {
        Vector3 axis = Vector3.zero;
        axis.x = -Input.GetAxis("Mouse Y") - prevAxis.x;
        axis.y = Input.GetAxis("Mouse X") - prevAxis.y;

        rotation.x += axis.x * speed;
        rotation.y += axis.y * speed;
        
        rotation.x = Mathf.Clamp(rotation.x, -limit, limit);
        rotation.y = Mathf.Clamp(rotation.y, -limit, limit);
        

        Quaternion qYaw = Quaternion.AngleAxis(rotation.y, Vector3.up);
        Quaternion qPitch = Quaternion.AngleAxis(rotation.x, Vector3.right);
        
        transform.rotation = qYaw * qPitch;
    }
}
