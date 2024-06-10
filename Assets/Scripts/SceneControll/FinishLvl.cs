using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] private GameObject _finishScene;
    private void OnTriggerEnter(Collider other)
    {
        _finishScene.SetActive(true);
    }
}
