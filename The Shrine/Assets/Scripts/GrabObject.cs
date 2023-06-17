using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrabObject : MonoBehaviour
{
    public CharacterController2D controller;

    public float distance = 1f;
    public LayerMask boxMask;

    GameObject box;

    void Start()
    {
        
    }

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "Objects" && Input.GetKeyDown(KeyCode.LeftControl))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPhysics>().beingPushed = true; //not so optimized
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
           box.GetComponent<FixedJoint2D>().enabled = false;
           box.GetComponent<BoxPhysics>().beingPushed = false; //not so optimized
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}
