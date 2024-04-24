using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform pos1;
    [SerializeField] private Transform pos2;
    [SerializeField] private Transform pos3;
    [SerializeField] private Camera cam;

    [SerializeField] private float delay1;
    [SerializeField] private float delay2;
    [SerializeField] private float delay3;


    private float elapsedTime;
    private void Update()
    {
        elapsedTime += Time.deltaTime;


        if (elapsedTime >= delay1 && elapsedTime < delay2)
        {
            cam.gameObject.transform.position = pos1.position;
            cam.gameObject.transform.rotation = pos1.rotation;
        }
        if (elapsedTime >= delay2 && elapsedTime < delay3)
        {
            cam.gameObject.transform.position = pos2.position;
            cam.gameObject.transform.rotation = pos2.rotation;
        }
        if (elapsedTime >= delay3)
        {
            cam.gameObject.transform.position = pos3.position;
            cam.gameObject.transform.rotation = pos3.rotation;
        }
    }
}
