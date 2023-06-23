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
        //StartCoroutine(Drain());

        if (currentThirst < 0)
        {
            Die();
        }
    }

    IEnumerator Drain()
    {
        Dehydration(1);
        yield return new WaitForSeconds(5);
    }

    void Dehydration(int damage)
    {
        currentThirst -= damage;
        thirstBar.SetThirst(currentThirst);
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sunlight")
        {
            Debug.Log("dehydrating");
            Dehydration(1);
        }
        if(collision.tag == "Enemy")
        {
            Die();
        }
        if(collision.transform.tag == "Checkpoint")
        {
            spawnPoint = transform.position;
        }
    }
    */
    /*
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Sunlight")
        {
            InvokeRepeating("Dehydration", 1, 1);
        }
    }
    */
    void Die()
    {
        Respawn();
    }

    void Respawn()
    {
        transform.position = spawnPoint;
    }
}
