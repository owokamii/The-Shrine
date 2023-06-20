using UnityEngine;
using UnityEngine.Events;

public class Crouch : MonoBehaviour
{
    [SerializeField] private Collider2D _crouchDisableCollider;
    [SerializeField] private Transform _ceilingCheck;

    private Controller _controller;
    private Rigidbody2D _body;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }
    
    public BoolEvent OnCrouchEvent;

    const float _ceilingRadius = .2f;

    private bool _crouch;
    private bool _wasCrouching = false;

    void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _controller = GetComponent<Controller>();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    // Update is called once per frame
    void Update()
    {
        _crouch = _controller.input.RetrieveCrouchInput(this.gameObject);
    }

    private void FixedUpdate()
    {
        if (!_crouch)
        {
            if (Physics2D.OverlapCircle(_ceilingCheck.position, _ceilingRadius))
            {
                _crouch = true;
            }
        }

        if (_crouch)
        {
            if (!_wasCrouching)
            {
                _wasCrouching = true;
                OnCrouchEvent.Invoke(true);
            }

            if (_crouchDisableCollider != null)
                _crouchDisableCollider.enabled = false;
        }
        else
        {
            if (_crouchDisableCollider != null)
                _crouchDisableCollider.enabled = true;

            if (_wasCrouching)
            {
                _wasCrouching = false;
                OnCrouchEvent.Invoke(false);
            }
        }
    }
}
