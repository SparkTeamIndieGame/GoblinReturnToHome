using UnityEngine;
using UnityEditor;
using System;

[RequireComponent(typeof(CharacterController))]
public class EnemyHook : EnemyBase
{
    public static event Action<float> DamageHit;

    [SerializeField] protected float _offsetDistance;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;
    [SerializeField] protected float _attackSpeed;

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
        {
            _targetPlayerX = Vector3.zero;
        }

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

            AudioSystem.insance._enemy_attack.Play();
        }

    }

    public virtual void Animation()
    {

        if (_distance < _offsetDistance)
        {
            Animator.speed = _attackSpeed;
            Animator.SetBool("Attack", true);
            Animator.SetBool("Run", false);

        }
        else if (_distance > _radius)
        {
            Animator.speed = 1;

            Animator.SetBool("Attack", false);
            Animator.SetBool("Run", false);
        }

        else if (_distance < _radius)
        {
            Animator.speed = 1;
            Animator.SetBool("Run", true);
            Animator.SetBool("Attack", false);

        }
    }
#if UNITY_EDITOR
    public override void OnDrawGizmos()
    {
        Handles.color = Color.yellow;
        base.OnDrawGizmos();
        Handles.color = Color.red;
        Handles.DrawWireDisc(this.transform.position, Vector3.forward, _offsetDistance);
        
    }
#endif
}

