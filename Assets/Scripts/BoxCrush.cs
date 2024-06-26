using UnityEngine;
using System;
using System.Collections;

public class BoxCrush : MonoBehaviour
{
    public static event Action<float> DamagePLayer;
    [SerializeField] private float _damage, _delayDamage;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("TakeDamage");
    }

    private void OnTriggerExit(Collider other)
    {
        StopAllCoroutines();
    }

    IEnumerator TakeDamage()
    {
        while(true)
        {
            DamagePLayer?.Invoke(_damage);
            yield return new WaitForSeconds(_delayDamage);
        }


    }
}
