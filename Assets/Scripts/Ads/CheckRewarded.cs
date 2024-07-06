using UnityEngine;
using YG;

public class CheckRewarded : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private GameObject _deadPanel;

    public void Check()
    {
        if (_characterController.enabled == true)
            _deadPanel.SetActive(false);

        else _deadPanel.SetActive(true);
    }
}
