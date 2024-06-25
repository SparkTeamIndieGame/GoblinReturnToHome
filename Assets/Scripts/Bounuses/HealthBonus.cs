using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    public static event Action<GameObject> OnUseBossFigth;

    [SerializeField] private float _addHealth;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ParticleSystem _effect;

    public void ConnectHealth(PlayerController playerController, float addHealth, ParticleSystem particle)
    {
        _playerController = playerController;
        _addHealth = addHealth;
        _effect = particle;
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioSystem.insance._HP.Play();

        _playerController.AddHealth(_addHealth);

        Instantiate(_effect, transform.position, Quaternion.identity);

        OnUseBossFigth?.Invoke(this.gameObject);

        Destroy(this.gameObject);
    }
}
