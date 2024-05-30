using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform _folovingTarget;
    [SerializeField, Range(0f, 1f)] private float _paralaxSt = 0.1f;
    [SerializeField] private bool _disableVerticalparalax;
    private Vector3 targetPreviouPos;

    private void Start()
    {
        if (!_folovingTarget)
        {
            _folovingTarget = Camera.main.transform;
        }
        targetPreviouPos = _folovingTarget.position;
    }
    private void Update()
    {
        var delta = _folovingTarget.position - targetPreviouPos;
        if (_disableVerticalparalax)
        {
            delta.y = 0.0f;
        }
        targetPreviouPos = _folovingTarget.position;

        transform.position += delta * _paralaxSt;
    }
}
