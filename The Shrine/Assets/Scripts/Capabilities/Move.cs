using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Controller), typeof(CollisionDataRetriever), typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _maxSpeed = 4f;
    [SerializeField, Range(0f, 100f)] private float _maxAcceleration = 35f;
    [SerializeField, Range(0f, 100f)] private float _maxAirAcceleration = 20f;

    private Controller _controller;
    private GrabObject _grabObject;
    private Vector2 _direction, _desiredVelocity, _velocity;
    private Rigidbody2D _body;
    private CollisionDataRetriever _collisionDataRetriever;

    private float _maxSpeedChange, _acceleration;
    private bool _onGround;
    private bool _facingRight = true;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collisionDataRetriever = GetComponent<CollisionDataRetriever>();
        _controller = GetComponent<Controller>();
        _grabObject = GetComponent<GrabObject>();
    }

    private void Update()
    {
        _direction.x = _controller.input.RetrieveMoveInput(this.gameObject);
        _desiredVelocity = new Vector2(_direction.x, 0f) * Mathf.Max(_maxSpeed - _collisionDataRetriever.Friction, 0f);
    }

    private void FixedUpdate()
    {
        _onGround = _collisionDataRetriever.OnGround;
        _velocity = _body.velocity;

        _acceleration = _onGround ? _maxAcceleration : _maxAirAcceleration;
        _maxSpeedChange = _acceleration * Time.deltaTime;
        _velocity.x = Mathf.MoveTowards(_velocity.x, _desiredVelocity.x, _maxSpeedChange);

        _body.velocity = _velocity;

        if(!_grabObject._grabbing)
        {
            if (_direction.x > 0 && !_facingRight)
            {
                Flip();
            }
            else if (_direction.x < 0 && _facingRight)
            {
                Flip();
            }
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}