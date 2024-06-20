using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    //[SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _point;
    private Vector3 _leftPoint, _rightPoint;
    private bool _left;
    // Start is called before the first frame update
    void Start()
    {
        _leftPoint = _point[0].position;
        _rightPoint = _point[1].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= _leftPoint.x)
            _left = false;

        else if (transform.position.x >= _rightPoint.x)
            _left = true;

        if(_left)
            transform.position = Vector3.MoveTowards(transform.position, _leftPoint, _speed * Time.deltaTime);
        else if(!_left)
            transform.position = Vector3.MoveTowards(transform.position, _rightPoint, _speed * Time.deltaTime);



    }
}
