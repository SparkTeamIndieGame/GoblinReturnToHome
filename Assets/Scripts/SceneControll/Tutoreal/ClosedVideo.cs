using System.Collections;
using UnityEngine;

public class ClosedVideo : MonoBehaviour
{
    [SerializeField] private float _timeVideo;
    [SerializeField] private GameObject[] _onCanvas;
    [SerializeField] private Animator animatorPortal;
    [SerializeField] private Texture2D _weapon;

    private void Awake()
    {
        foreach (var on in _onCanvas)
        {
            on.SetActive(false);
        }
    }
    private void Start()
    {
        StartCoroutine(ClosedVideoCorutine());
    }
    private IEnumerator ClosedVideoCorutine()
    {
        yield return new WaitForSeconds(_timeVideo);
        animatorPortal.SetTrigger("Play");
        Cursor.SetCursor(_weapon, new Vector2(31, 32), CursorMode.Auto);
        foreach (var on in _onCanvas)
        {
            on.SetActive(true);
        }
        
        this.gameObject.SetActive(false);
    }
}
