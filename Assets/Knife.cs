using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private GameObject knife;
    [SerializeField] private GameObject destroy;
    [SerializeField] private FixedJoint joint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == knife)
        {
            Destroy(destroy);
            Destroy(joint);
        }
    }
}
