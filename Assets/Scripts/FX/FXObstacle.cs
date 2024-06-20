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
    // Start is called before the first frame update
    void Start()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
        StartCoroutine("DelayStart");
        ParticleSystem.trigger.AddCollider(GameObject.FindAnyObjectByType<PlayerController>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleTrigger()
    {
        Damage?.Invoke(_damage);
        print("hit");
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
