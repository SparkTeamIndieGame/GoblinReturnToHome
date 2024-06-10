using UnityEngine;
using System;

[RequireComponent(typeof(CharacterController))]
public class EnemyHook : EnemyBase
{
    public static event Action<float> DamageHit;
    [SerializeField] protected float _offsetDistance;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;
    protected Vector3 _targetPlayerX;
    protected CharacterController _characterControler;
    protected Animator Animator;

    public override void Awake()
    {
        base.Awake();

        _characterControler = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
    }
    public override void Update()
    {
        base.Update();

        if (!_characterControler.isGrounded)
            _targetPlayerX = Vector3.zero;

        Pursuit();
        Animation();

    }

    private void FixedUpdate()
    {
        _characterControler.SimpleMove(_targetPlayerX * _speed);
    }

    public virtual void Pursuit()
    {
        if(_distance < _offsetDistance)
        {
            _targetPlayerX = Vector3.zero;

        }
       else if (_distance > _radius)
        {
            _targetPlayerX = Vector3.zero;
        }

        else if (_distance < _radius)
        {
            _targetPlayerX = new Vector3(_playerTransform.position.x - transform.position.x, 0, 0);

        }
    }

    public void Hit()
    {
        if(_distance < _offsetDistance)
        {
            DamageHit?.Invoke(_damage);
            print($"{name} ударил игрока, урон составил {_damage} и у игрорка осталось {_playerTransform.gameObject.GetComponent<PlayerController>().Health}");

        }

    }

    public virtual void Animation()
    {
        if (_distance < _offsetDistance)
        {
            Animator.SetBool("Attack", true);
            Animator.SetBool("Run", false);

        }
        else if (_distance > _radius)
        {
            Animator.SetBool("Attack", false);
            Animator.SetBool("Run", false);
        }

        else if (_distance < _radius)
        {
            Animator.SetBool("Run", true);
            Animator.SetBool("Attack", false);

        }
    }
}

