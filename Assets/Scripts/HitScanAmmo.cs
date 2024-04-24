using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanAmmo : MonoBehaviour
{
    [SerializeField] private float distance = 10;
    [SerializeField] private GameObject hitPrefab;
    [SerializeField] private LayerMask mask = -1;

    private void Start()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, distance, mask))
        {
            if (hitPrefab != null) 
            { 
                Instantiate(hitPrefab, raycastHit.point, Quaternion.LookRotation(raycastHit.normal));
            }
        }
        
 
        Destroy(gameObject);
    }
}
