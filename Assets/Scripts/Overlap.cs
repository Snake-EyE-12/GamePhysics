using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap : MonoBehaviour
{
    public enum OverlapType
    {
        BoundingBox,
        Sphere
    }

    [SerializeField] private OverlapType type;
    [SerializeField] private float size;
    [SerializeField] private LayerMask layer = Physics.AllLayers;

    private Collider[] colliders;

    private void Update()
    {
        switch (type)
        {
            case OverlapType.BoundingBox:
                colliders = Physics.OverlapBox(transform.position, Vector3.one * (size * 0.5f), transform.rotation, layer);
                break;
            case OverlapType.Sphere:
                colliders = Physics.OverlapSphere(transform.position, size * 0.5f, layer);
                break;
            
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Physics.gravity = new Vector3(0, 10, 0);
            
        }
        else Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        switch (type)
        {
            case OverlapType.BoundingBox:
                Gizmos.DrawWireCube(transform.position, Vector3.one * size);
                break;
            case OverlapType.Sphere:
                Gizmos.DrawWireSphere(transform.position, size * 0.5f);
                break;
            
        }

        Gizmos.color = Color.red;
        if (colliders != null)
        {
            foreach (var c in colliders)
            {
                Gizmos.DrawWireCube(c.bounds.center, c.bounds.size);
            }
        }
    }
}
