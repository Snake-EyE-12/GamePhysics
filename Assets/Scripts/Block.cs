using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int points;
    private bool scored = false;

    private void Start()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground") && !scored)
        {
            ScoreKeeper.onScoreChange?.Invoke(points);
            scored = true;
        }
    }
}
