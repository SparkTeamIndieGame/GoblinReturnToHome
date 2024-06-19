using UnityEngine;
using UnityEngine.UI;

public class FinishScore : MonoBehaviour
{
    [SerializeField] private GameObject _playerInput;
    [SerializeField] private ScoreControl _scoreControl;
    [SerializeField] private NeedCountEnemy _needCountEnemy;

    [SerializeField] private Text _damageText;
    [SerializeField] private Text _killText;
    
    public void UpdateText()
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
