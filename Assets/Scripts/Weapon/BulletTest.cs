using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletTest : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] protected float _lifeTime = 5.0f;

    //public static event Action Damage;

    private void Start()
    {
        
        Destroy(this.gameObject, _lifeTime);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //        Destroy(gameObject);
    //}
}
