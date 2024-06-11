using UnityEngine;
using UnityEngine.InputSystem;

public class FiveTriggerBonus : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    [SerializeField] private GameObject _templeCamera;

    [SerializeField] private GameObject _playerInput;
    [SerializeField] private GameObject _canvasMenu;

    [SerializeField] private Coursorechanged _cursore;

    private void OnTriggerEnter(Collider other)
    {
        _mainCamera.SetActive(false);
        _templeCamera.SetActive(true);
        _playerInput.SetActive(false);
        _canvasMenu.SetActive(true);
        _cursore.UseMainCursore();
    }
}
