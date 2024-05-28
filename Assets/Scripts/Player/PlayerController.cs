using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed, _smoothRotation;
    [SerializeField] private float _gravityMultiplier;
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _maxJumpCount;

    private CharacterController _characterController;

    private Vector2 _input;
    private Vector3 _direction;

    private float _xEuler;
    private float _gravity = -9.8f;
    private float _velocity = -1;
    private float _jumpCount;


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        MoveForward();
        RotationForward();
    }


    private bool IsGrounded() => _characterController.isGrounded;

    private void Gravity()
    {
        if(IsGrounded() && _velocity < 0)
        {
            _velocity = -1;
            _jumpCount = 0;
        }

        else
        {
            _velocity += _gravity * _gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity;

    }

    private void MoveForward()
    {
        _characterController.Move(_direction * _speed * Time.deltaTime);

    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0, 0);
    }

    private void RotationForward()
    {
        if (_input.x > 0)
            _xEuler = 0;
        else if (_input.x < 0)
            _xEuler = -180;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _xEuler, 0), _smoothRotation * Time.deltaTime);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _jumpCount >= _maxJumpCount) return;
       
        _jumpCount++;
        _velocity = _jumpPower;
       

    }

}
