using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    [SerializeField] private float _distance;
    [SerializeField] private float _speed;
    [SerializeField] private List<Transform> _point;
    private Vector3 _leftPoint, _rightPoint;
    private bool _left;
    // Start is called before the first frame update
    void Start()
    {
        //_leftPoint = new Vector3(transform.position.x + _distance, transform.position.y, transform.position.z);
        //_rightPoint = new Vector3(transform.position.x - _distance, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < _point[0].position.x)
            _left = false;

        else if (transform.position.x > _point[1].position.x)
            _left = true;

        if(_left)
            transform.position = Vector3.MoveTowards(transform.position, _point[0].position, _speed * Time.deltaTime);
        else if(_left)
            transform.position = Vector3.MoveTowards(transform.position, _point[1].position, _speed * Time.deltaTime);



    }
}
