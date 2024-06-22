using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBig : MonoBehaviour
{
    [SerializeField] private float _speed, _speedRortation;
    [SerializeField] private Transform _point;
    private Vector3 _leftPoint;
    void Start()
    {
        _leftPoint = _point.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _leftPoint, _speed * Time.deltaTime);

        Rotation();

    }

    private void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, 1 * _speedRortation));
    }

}
