using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    bool alive = true;

    void Start()
    {
        
    }

    void Update()
    {
        if(!alive)
        {
            Destroy(gameObject);
        }
    }
}
