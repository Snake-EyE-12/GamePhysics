using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenImageTarget : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private Image image;
    [SerializeField] private Camera cam;

    private void LateUpdate()
    {
        Vector3 screen = image.transform.position;
        screen.z = distance;

        Vector3 world = cam.ScreenToWorldPoint(screen);
        transform.position = world;
    }
}
