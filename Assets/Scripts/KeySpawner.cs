using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    [SerializeField] private KeyCode key;
    [SerializeField] private GameObject spawnable;
    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(key))
        Instantiate(spawnable, transform.position, transform.rotation);
    }
}
