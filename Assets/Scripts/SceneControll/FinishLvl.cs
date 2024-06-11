using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] private GameObject _finishScene;
    [SerializeField] private GameObject _inputSystem;
    private void OnTriggerEnter(Collider other)
    {
        _finishScene.SetActive(true);
        _inputSystem.SetActive(false);
        AudioSystem.insance._win.Play();
    }
}
