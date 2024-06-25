using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLvl : MonoBehaviour
{
    [SerializeField] private GameObject _finishScene;
    [SerializeField] private GameObject _inputSystem;

    [SerializeField] private float _time;
    [SerializeField] private GameObject _cutScene;
    [SerializeField] private List<GameObject> _offGameObject;
    [SerializeField] private bool _bossFight;

    private void OnTriggerEnter(Collider other)
    {
        if(_bossFight)
        {
            _cutScene.SetActive(true);
            Cursor.visible = false;
            foreach (var off in _offGameObject)
                off.SetActive(false);

            StartCoroutine("NextLevel");
        }
        else
        {
            _finishScene.SetActive(true);
            _inputSystem.SetActive(false);
            AudioSystem.insance._win.Play();
        }


    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(_time);
        {
            var NumberScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(NumberScene + 1);

        }
    }

}
