using UnityEngine;

public class Climb : MonoBehaviour
{
    private Controller _controller;
    private Rigidbody2D _body;
    private float _climbSpeed = 5f;
    private float _climb;
    private bool isLadder;
    public bool isClimbing;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _controller = GetComponent<Controller>();
    }

    void Update()
    {
        //_climb = Input.GetAxis("Vertical");
        _climb = _controller.input.RetrieveClimbInput(this.gameObject);
        Debug.Log(_climb);
        if(isLadder && Mathf.Abs(_climb) > 0f)
        {
            Debug.Log("i can climb");
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            Debug.Log("im climbing");
            _body.gravityScale = 0f;
            _body.velocity = new Vector2(_body.velocity.x, _climb * _climbSpeed);
        }

        else
        {
            Debug.Log("im not climbing");
            _body.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            Debug.Log("i detect ladder");
            isLadder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Ladder"))
        {
            Debug.Log("i dont detect ladder");
            isLadder = false;
            isClimbing = false;
        }
    }
}
