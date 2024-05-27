using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speedGround, _jump, _speedAir;
    private CharacterController characterController;
    private float move, speed;
    private int doubleJump = 0;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");

        if(characterController.isGrounded)
        {
            doubleJump = 0;
            speed = _speedGround;
        }

        Jump(Input.GetKeyDown(KeyCode.Space));
            

    }

    private void FixedUpdate()
    {
        characterController.SimpleMove(new Vector3(move * speed, 0, 0));
        
    }

    private void Jump(bool space)
    {
        if (space && doubleJump < 2)
        {
            characterController.Move(Vector3.up * _jump);
            speed = _speedAir;
            doubleJump++;
        }
        else return;


    }
}
