using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    //[SerializeField] private float _distance;
    [SerializeField] private float _speed, _speedRortation;
    [SerializeField] private List<Transform> _point;
    private Vector3 _leftPoint, _rightPoint;
    private bool left;
    // Start is called before the first frame update
    private void Start()
    {
        _leftPoint = _point[0].position;
        _rightPoint = _point[1].position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.position == _leftPoint)
        {
            left = false;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);

            _speedRortation *= -1;
        }

        else if (transform.position == _rightPoint)
        {
            left = true;
            if (transform.localScale.y < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
            }
            if (_speedRortation < 0)
            {
                _speedRortation *= -1;
            }
        }

        TransformPosition();
        Rotation();
    }

    private void TransformPosition()
    {
        if (left)
        {
            transform.position = Vector3.MoveTowards(transform.position, _leftPoint, _speed * Time.deltaTime);
        }
        else if (!left)
        {
            transform.position = Vector3.MoveTowards(transform.position, _rightPoint, _speed * Time.deltaTime);
        }
    }

    private void Rotation()
    {
        transform.Rotate(new Vector3(0, 0, 1 * _speedRortation));
    }

}
