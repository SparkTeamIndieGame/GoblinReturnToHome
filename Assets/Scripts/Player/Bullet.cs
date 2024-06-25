using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _life;
    private Vector3 _direction;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _direction = GameObject.FindGameObjectWithTag("PointBullet").transform.forward;
    }

    private void Start()
    {
        Destroy(gameObject, _life);
    }

    private void FixedUpdate()
    {
       _rigidbody.velocity = _direction * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        Destroy(gameObject);
    }

    

}
