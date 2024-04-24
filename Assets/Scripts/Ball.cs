using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private ForceMode forceMode;
    [SerializeField] private Rigidbody rb;
    public Color color;
    public void Launch()
    {
        rb.AddForce(force * transform.forward, forceMode);
        Destroy(this.gameObject, 15f);
    }
}
