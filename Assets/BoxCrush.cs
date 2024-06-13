using UnityEngine;
using System;

public class BoxCrush : MonoBehaviour
{
    public static event Action<float> DamagePLayer;
    [SerializeField] private float _damage;

    private void OnTriggerEnter(Collider other)
    {
        DamagePLayer?.Invoke(_damage);
    }
}
