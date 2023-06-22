using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hide : MonoBehaviour
{
    public GameObject bird;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bird.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Code to handle the collision with the detector
            Debug.Log("Player kill");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
