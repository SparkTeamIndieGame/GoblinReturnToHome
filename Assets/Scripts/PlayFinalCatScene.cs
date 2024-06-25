using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class PlayFinalCatScene : MonoBehaviour
{
    [SerializeField] private GameObject _audioManager;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private GameObject _playerInput;
    [SerializeField] private GameObject _catScene;


    private void OnTriggerEnter(Collider other)
    {
        _audioManager.SetActive(false);
        _canvas.SetActive(false);
        _playerInput.SetActive(false);
        _catScene.SetActive(true);
        Cursor.visible = false;
        StartCoroutine("LoadMenu");
    }

    IEnumerator LoadMenu()
    {
        yield return new WaitForSeconds(15);
        SceneManager.LoadScene(0);
    }

}
