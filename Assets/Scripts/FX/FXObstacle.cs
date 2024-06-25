using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using System;

public class FXObstacle : MonoBehaviour
{
    public static event Action<float> Damage;

    [SerializeField] private float _damage;
    [SerializeField] private float _delay;

    private ParticleSystem ParticleSystem;

    private void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();

        StartCoroutine("DelayStart");

        ParticleSystem.trigger.AddCollider(GameObject.FindAnyObjectByType<PlayerController>().transform);
    }

    private void OnParticleTrigger()
    {
        Damage?.Invoke(_damage);
    }

    IEnumerator DelayStart()
    {
        while(true)
        {
            yield return new WaitForSeconds(_delay);
            ParticleSystem.Play();
        }
    }
}
