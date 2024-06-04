using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Tight : MonoBehaviour
{

    [SerializeField] private Transform _hand, _playerSkin;
    [SerializeField] private float _speed = 5f, _smoothRotation;
    private Camera _camera;
    private Vector3 mousePos;
    private float _xEuler;
    //private Ray ray;
    //public Camera _mousePos;
    private void Awake()
    {
        _camera = Camera.main;
    }
    private void Update()
    {
        RotationForward();
        RotateHand();
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        mousePos = context.ReadValue<Vector2>();
        mousePos.z = -_camera.transform.position.z;

        transform.position = _camera.ScreenToWorldPoint(mousePos);

        //ray = new Ray(transform.position, Vector3.forward);
        //Debug.DrawRay(transform.position, Vector3.forward * 100f, Color.yellow);
        //print(ray.direction);


    }

    private void RotateHand()
    {
        //_hand.rotation = Quaternion.Slerp(_hand.rotation, Quaternion.LookRotation(transform.position - _hand.position), _speed * Time.deltaTime);
        Vector3 angle = transform.position - _hand.position;
        Vector3 angleXY = new Vector3(angle.x, angle.y, 0);
        _hand.rotation = Quaternion.LookRotation(angleXY * _speed * Time.deltaTime);
    }


    private void RotationForward()
    {
        if (transform.localPosition.x > 0)
            _xEuler = 0;
        else if (transform.localPosition.x < 0)
            _xEuler = -180;

        _playerSkin.localRotation = Quaternion.Lerp(_playerSkin.localRotation, Quaternion.Euler(0, _xEuler, 0), _smoothRotation * Time.deltaTime);
    }
}
