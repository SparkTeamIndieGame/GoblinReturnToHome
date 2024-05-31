using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof())]
public class EnemyHook : EnemyBase
{
    [SerializeField] float _offsetDistance;
    [SerializeField] float _speed;
    //private NavMeshAgent _navMeshAgent;
    //private new Rigidbody rigidbody;
    //private Vector3 _targetRigidbody;

    public override void Awake()
    {
        base.Awake();
        //_navMeshAgent = GetComponent<NavMeshAgent>();
        //rigidbody = GetComponent<Rigidbody>();
    }
    public override void Update()
    {
        base.Monitoring();
        if(_distance < _radius)
        Pursuit();
        //_targetRigidbody = _playerTransform.position - transform.position;
    }

    //private void FixedUpdate()
    //{
    //    if (_distance < _radius)
    //    {
    //        Pursuit();
    //    }
    //}

    private void Pursuit()
    {
        if (_distance < _offsetDistance) return;

        transform.Translate((_playerTransform.position - transform.position) * _speed * Time.deltaTime);
        //rigidbody.AddForce(_targetRigidbody * _speed, ForceMode.VelocityChange);


    }

}
