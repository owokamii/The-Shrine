using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GrabObject : MonoBehaviour
{
    public float distance = 0.7f;
    public LayerMask boxMask;

    public bool _grabbing;

    GameObject box;

    void Update()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);
        if (hit.collider != null && hit.collider.gameObject.tag == "Objects" && Input.GetKeyDown(KeyCode.LeftControl))
        {
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<ObjectPhysics>().beingPushed = true; //not so optimized
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            _grabbing = true;
        }
        else if(Input.GetKeyUp(KeyCode.LeftControl))
        {
           box.GetComponent<FixedJoint2D>().enabled = false;
           box.GetComponent<ObjectPhysics>().beingPushed = false; //not so optimized
            _grabbing = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }
}