using System.Collections;
using UnityEngine;

public class ClosedVideo : MonoBehaviour
{
    [SerializeField] private float _timeVideo;
    [SerializeField] private GameObject _tutorial;
    private void Start()
    {
        StartCoroutine(ClosedVideoCorutine());
    }
    private IEnumerator ClosedVideoCorutine()
    {
        yield return new WaitForSeconds(_timeVideo);
        _tutorial.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
