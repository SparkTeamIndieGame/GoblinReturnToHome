using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemyRange : MonoBehaviour
{
    [SerializeField] private float _radius;


    [Inject]
    private GameObject payer;
    private float currentDis;
    private void Update()
    {
        currentDis = Vector3.Distance(payer.transform.position, transform.position);
        if (currentDis <= _radius)
        {
            Debug.Log("Близко");
        }
        else if (currentDis > _radius) 
        {
            Debug.Log("Далеко");
        }
    }
}
