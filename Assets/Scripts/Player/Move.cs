using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    //[SerializeField] private float _speedGround, _jump, _speedAir, _gravity;
    //private float move, speed;
    //private int doubleJump = 0;
    [SerializeField] private float _speed;
    private CharacterController _characterController;
    private Vector2 _input;
    private Vector3 _direction;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move(_direction * _speed * Time.deltaTime);
        //move = Input.GetAxis("Horizontal");

        //if (characterController.isGrounded)
        //{
        //    doubleJump = 0;
        //    speed = _speedGround;
        //}
        //else if (!characterController.isGrounded)
        //    characterController.Move(new Vector3(0, _gravity, 0) * Time.fixedDeltaTime);

        //Jump(Input.GetKeyDown(KeyCode.Space));


    }

    //private void FixedUpdate()
    //{
    //    characterController.Move(new Vector3(move, 0, 0) * _speedGround * Time.deltaTime);

    //}

    //private void Jump(bool space)
    //{
    //    if (space && doubleJump < 2)
    //    {
    //        characterController.Move(Vector3.up * _jump * Time.fixedDeltaTime);
    //        speed = _speedAir;
    //        doubleJump++;
    //    }
    //    else return;


    //}

    public void Moved(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0, 0);
    }
}
