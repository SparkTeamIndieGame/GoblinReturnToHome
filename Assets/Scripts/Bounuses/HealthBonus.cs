using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    [SerializeField] private float _addHealth;
    [SerializeField] private PlayerController _playerController;

    private void OnTriggerEnter(Collider other)
    {
        _playerController.AddHealth(_addHealth);
    }
}
