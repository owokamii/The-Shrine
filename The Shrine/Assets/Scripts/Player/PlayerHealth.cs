using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxThirst = 100;
    public int currentThirst;

    public ThirstBar thirstBar;

    private Transform currentCheckpoint;
    Vector2 spawnPoint;

    void Start()
    {
        spawnPoint = transform.position;
        currentThirst = maxThirst;
        thirstBar.SetMaxThirst(maxThirst);
    }

    void Update()
    {
        if(currentThirst < 0)
        {

        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Dehydration(10);
        }
    }

    void Dehydration(int damage)
    {
        currentThirst -= damage;
        thirstBar.SetThirst(currentThirst);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Die();
        }
        if(collision.transform.tag == "Checkpoint")
        {
            spawnPoint = transform.position;
        }
    }

    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = spawnPoint;
    }
}
