using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFinalCatScene : MonoBehaviour
{
    [SerializeField] private GameObject _audioManager;
    [SerializeField] private GameObject _playerInput;
    [SerializeField] private GameObject _catScene;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        _audioManager.SetActive(false);
        _playerInput.SetActive(false);
        _catScene.SetActive(true);
    }
}
