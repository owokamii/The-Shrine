using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCheckpoint;
    //private PlayerHealth playerHealth;

    private void Awake()
    {
        //playerHealth = GetComponent<PlayerHealth>();
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint.position;
        //playerHealth.Respawn();

        //Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
        }
    }
}
