using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    [SerializeField] private float _addHealth;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private ParticleSystem _effect;

    private void OnTriggerEnter(Collider other)
    {
        AudioSystem.insance._HP.Play();
        _playerController.AddHealth(_addHealth);

        Instantiate(_effect, transform.position, Quaternion.identity);

        Destroy(this.gameObject);
    }
}
