using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private Transform _sticks;
    [SerializeField] private float _speedSticksOn, _speedSticksOff;
    [SerializeField] private float _delayOn, _delayOff;

    private bool _active;

    private void Update()
    {
        if (_active)
        {
            AttackStick();
        }

        else if (!_active)
        {
            OnAttackStick();
        }
    }

    IEnumerator DelayOpen()
    {
        yield return new WaitForSeconds(_delayOn);
        _active = false;

    }

    IEnumerator DelayClose()
    {
        yield return new WaitForSeconds(_delayOff);
        _active = true;

    }

    private void OnAttackStick()
    {
        if(_sticks.localPosition.y >= 0.1)
        {
            _sticks.localPosition = Vector3.MoveTowards(_sticks.localPosition, Vector3.zero, _speedSticksOn * Time.deltaTime);
        }

        else
        {
            StopCoroutine("DelayOpen");
            StartCoroutine("DelayClose");
        }    


    }

    private void AttackStick()
    {
        if (_sticks.localPosition.y <= 2.4)
        {
            _sticks.localPosition = Vector3.MoveTowards(_sticks.localPosition, new Vector3(0, 2.5f, 0), _speedSticksOff * Time.deltaTime);
        }

        else
        {
            StopCoroutine("DelayClose");
            StartCoroutine("DelayOpen");
        }

    }
}
