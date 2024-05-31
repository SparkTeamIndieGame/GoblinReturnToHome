using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    [SerializeField] private float _lifeTime = 5.0f;
    [SerializeField] private float _damage;

    private void Start()
    {
        
        Destroy(this.gameObject, _lifeTime);
    }
}
