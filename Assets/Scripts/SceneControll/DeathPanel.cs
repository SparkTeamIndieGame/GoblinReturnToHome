using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private GameObject _playerInput;
    [SerializeField] private ScoreControl _scoreControl;

    [SerializeField] private Text _damageText;
    [SerializeField] private Text _killText;
    public static bool _isDeath = false;
    private void Start()
    {
        _isDeath = false;
    }
    private void Update()
    {
        if (_isDeath)
        {
            UpdateText();
        }
    }
    private void UpdateText()
    {
        _damageText.text = _scoreControl.GetDamageScore().ToString();
        _killText.text = _scoreControl.GetKillScore().ToString();
    }
    
}
