using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private  Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Transform _tight;
    [SerializeField] private float _view1 = 60, _view2 = 75;

    private Vector3 _offset; // x =9.2; y = 7.3; z = -14;
    private float _posXLeft, _posXRight;
    private bool _forward = true;
    private float _direction;
    private Vector3 _currentVelocity = Vector3.zero;
    private Vector3 _targetPosition;

    private void Awake()
    {
        _offset = transform.position - _target.position;

        _posXLeft = -_offset.x;
        _posXRight = _offset.x;
    }

    private void Update()
    {
        _direction = _tight.localPosition.x;

        UpView();

        if (_direction > 0)
        {
            _forward = true;
        }

        else if (_direction < 0)
        {
            _forward = false;
        }

        if (_forward)
        {
            _offset.x = _posXRight;
        }

        else
        {
            _offset.x = _posXLeft;
        }

    }

    private void UpView()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(Camera.main.fieldOfView == _view1)
            {
               Camera.main.fieldOfView = _view2;
            }

            else
               Camera.main.fieldOfView = _view1;
        }
    }
    private void LateUpdate()
    {
        if (_target != null)
        {
           _targetPosition = _target.position + _offset;
           transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _currentVelocity, _speed);
        }

    }
}
