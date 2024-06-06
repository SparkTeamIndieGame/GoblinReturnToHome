using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        Jump();
    }

    private void Move(float input)
    {
        if (input > 0 || input < 0)
            _animator.SetBool("Run", true);
        else
            _animator.SetBool("Run", false);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _animator.SetTrigger("Jump");
    }

}
