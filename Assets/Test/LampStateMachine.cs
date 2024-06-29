using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampStateMachine : MonoBehaviour
{
    [SerializeField] float _blinkInterval = 0.5f;   // интервал мерцания лампы
    float _nextBlinkTime = 0f;                      // вычисляемое значение следующего мерцания по времени
    bool _isBlinking = false;                       // вычисляемый флаг мерцания

    [SerializeField] MeshRenderer _lampRenderer;    // отрисовщик лампы для настройки цвета
    [SerializeField] EnemyTurret _connectedTurret;  // соединеная с лампой турель

   
    enum LampState                                 
    {
       
        OutOfRange,
        
        ApproachingRange,
        
        InsideRange
    }
    [SerializeField] LampState _currentState;


    void Update()
    {
        CalculateCurrentState();
        UpdateLampState();
    }

    
    void CalculateCurrentState()
    {
        if (_connectedTurret.InsideFiringRadius) _currentState = LampState.InsideRange;
        else if (_connectedTurret.InsideDetectionRadius) _currentState = LampState.ApproachingRange;
        else _currentState = LampState.OutOfRange;
    }

    
    void UpdateLampState()
    {
        switch (_currentState)
        {
        case LampState.OutOfRange:
            _lampRenderer.material.color = Color.gray;
            _isBlinking = false;
            break;
        
        case LampState.ApproachingRange:
            _lampRenderer.material.color = Color.red;
            _isBlinking = false;
            break;

        case LampState.InsideRange:
            if (!_isBlinking)
            {
                _isBlinking = true;
                _nextBlinkTime = Time.time + _blinkInterval;
            }
            BlinkLamp();
            break;
        }
    }

    void TestAction()
    {
        _lampRenderer.material.color = Color.green;
    }
    
    void BlinkLamp()
    {
        if (Time.time >= _nextBlinkTime)
        {
            _lampRenderer.material.color = _lampRenderer.material.color == Color.red ? Color.gray : Color.red;
            _nextBlinkTime = Time.time + _blinkInterval;
        }
    }
}