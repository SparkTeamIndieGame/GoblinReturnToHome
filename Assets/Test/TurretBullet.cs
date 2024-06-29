using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    [SerializeField] float _damage = 2.0f;
    [SerializeField] float _lifeTime = 2.0f;
    [SerializeField] float _speed = 30.0f;

    [SerializeField] Rigidbody _rigidbody;

    void Start()
    {
        if (_rigidbody == null) _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.right * _speed;

        Destroy(gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
