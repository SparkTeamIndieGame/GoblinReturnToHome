using UnityEngine;
using UnityEngine.UI;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private NeedCountEnemy _needCountEnemy;
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
        if (_isDeath == true)
        {
            UpdateText();
        }
    }
    private void UpdateText()
    {
        if (_scoreControl != null)
        {
            _damageText.text = _scoreControl.GetDamageScore().ToString();
            _killText.text = _scoreControl.GetKillScore().ToString();

        }
        else
        {
            _damageText.text = _needCountEnemy.GetDamageScore().ToString();
            _killText.text = _needCountEnemy.GetKillScore().ToString();

        }
    }
    
}
