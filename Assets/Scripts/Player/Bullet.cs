using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _life;
    Vector3 _direction;
    Rigidbody _rigidbody;
    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _direction = GameObject.FindGameObjectWithTag("PointBullet").transform.forward;
    }
    void Start()
    {
        Destroy(gameObject, _life);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       _rigidbody.velocity = _direction * _speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject.name);
        Destroy(gameObject);
    }

    

}
