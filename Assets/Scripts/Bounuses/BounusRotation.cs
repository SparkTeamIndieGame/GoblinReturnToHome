using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounusRotation : MonoBehaviour
{
    [SerializeField] private GameObject _insideObject;
    [SerializeField] private float _rotationSpeed;

    private void Update()
    {
        _insideObject.transform.Rotate(new Vector3(0.0f, _rotationSpeed * Time.deltaTime, 0.0f));
    }
}
