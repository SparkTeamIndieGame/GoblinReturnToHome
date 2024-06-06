using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _reboot;

    private Animator _animator;
    private PlayerController _player;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _player.Damage += DamageAnim;
    }

    private void OnDisable()
    {
        _player.Damage -= DamageAnim;
    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        Jump();

        if(_player.Health <= 0)
        {
            DeadAnim();
        }
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

    private void DamageAnim()
    {
        _animator.SetTrigger("Damage");
    }

    private void DeadAnim()
    {
        _animator.SetBool("Dead", true);
        StartCoroutine("Dead");

    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(_delay);
        _reboot.SetActive(true);
        Destroy(transform.parent.gameObject);
    }



}
