using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorealJump : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    [SerializeField] private GameObject _playerInput;
    [SerializeField] private GameObject _playerWeapons;
    [SerializeField] private Coursorechanged _cursore;

    private void OnTriggerEnter(Collider other)
    {
        _playerInput.SetActive(false);
        _playerWeapons.SetActive(false);
        _cursore.LoseCursore(true);
        _tutorialCanvas.SetActive(true);
    }
}
