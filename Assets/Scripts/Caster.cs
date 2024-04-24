using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caster : MonoBehaviour
{
    public enum CasterType
    {
        Ray,
        Sphere,
        Box
    }
    [SerializeField] private CasterType type;
    [SerializeField] private float size = 1;
    [SerializeField] private float distance = 2;
    [SerializeField] private LayerMask layer = Physics.AllLayers;

    private RaycastHit[] hits;
    
    private void Update()
    {
        switch (type)
        {
            case CasterType.Ray:
                hits = Physics.RaycastAll(transform.position, transform.forward, distance, layer);
                break;
            case CasterType.Sphere:
                hits = Physics.SphereCastAll(transform.position, size, transform.forward, distance, layer);
                break;
            case CasterType.Box:
                hits = Physics.BoxCastAll(transform.position, Vector3.one * (size * 0.5f), transform.forward, transform.rotation, distance, layer);
                break;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * distance);
        switch (type)
        {
            case CasterType.Sphere:
                Gizmos.DrawWireSphere(transform.position + transform.forward * distance, size);
                break;
            case CasterType.Box:
                Gizmos.DrawWireCube(transform.position+ transform.forward * distance, Vector3.one * size);
                break;
        }
        
        Gizmos.color = Color.blue;
        if (hits != null)
        {
            foreach (var h in hits)
            {
                Gizmos.DrawWireCube(h.collider.transform.position, h.collider.bounds.size);
            }
            
        }
    }
}
