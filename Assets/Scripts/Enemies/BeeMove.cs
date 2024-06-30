using System;
using System.Collections;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    public static Action<float> DamageBee;

    [SerializeField] private float _speed, _speedRotation;
    [SerializeField] private float _health, _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _delayStart;
    [SerializeField] private float _stopDistance;
    [SerializeField] private Transform _target, _skin;
    [SerializeField] private Transform _hpParent;
    [SerializeField] private GameObject _healhBarFront;

    private float _xEuler;
    private bool _active;
    private bool _left;
    private Animator _animator;



    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if(_delayStart != 0)
        {
            StartCoroutine(DelayStart());
        }

        _maxHealth = _health;
    }

    private void Update()
    {
        Move();

        //Rotation();
        RotationForward();

        CheckDirection();

        CheckHealt();

    }

    private void Rotation()
    {

        if(_left)
        {
            if (_skin.localScale.z < 0)
            {

                _skin.localScale = new Vector3(_skin.localScale.x, _skin.localScale.y, _skin.localScale.z * -1);
            }
        }

        else if(!_left)
        {
            if (_skin.localScale.z > 0)
            {

                _skin.localScale = new Vector3(_skin.localScale.x, _skin.localScale.y, _skin.localScale.z * -1);
            }
        }
    }

    private void RotationForward()
    {
        if (_left)
        {
            _xEuler = -90;
        }

        else if (!_left)
        {
            _xEuler = 90;
        }


        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _xEuler, 0), _speedRotation * Time.deltaTime);
        _hpParent.localRotation = Quaternion.Lerp(_hpParent.localRotation, Quaternion.Euler(0, _xEuler, 0), _speedRotation * Time.deltaTime);
    }

     private float GetDistance
    {
        get
        {
            return Vector3.Distance(_target.position, transform.position);
        }
    }

    private void CheckDirection()
    {
        if (_target.position.x < transform.position.x)
        {
            _left = true;
        }

        else if (_target.position.x > transform.position.x)
        {
            _left = false;
        }

    }

    private void CheckHealt()
    {
        if(_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
    public void Damage()
    {
        if (GetDistance < _stopDistance)
        {
            DamageBee?.Invoke(_damage);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    private void Move()
    {
        if (GetDistance < _stopDistance)
        {
            _active = false;
            _animator.applyRootMotion = false;
            _animator.SetTrigger("Attack");
        }

        else if (_active)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BulletCharacter damage))
        {
            _health -= damage._damage;

            var healthProcent = (_health / _maxHealth) * 100.0f;
            var healthBarProcent = healthProcent / 100.0f;

            _healhBarFront.transform.localScale = new Vector3(healthBarProcent, 1.0f, 1.0f);

            AudioSystem.insance._enemy_damage.Play();
        }
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(_delayStart);
        _active = true;
        StopCoroutine("DelayStart");
    }
}
