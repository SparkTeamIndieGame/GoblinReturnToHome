using UnityEngine;
using UnityEngine.UI;

public class FinishScore : MonoBehaviour
{
    [SerializeField] private GameObject _playerInput;
    [SerializeField] private ScoreControl _scoreControl;

    [SerializeField] private Text _damageText;
    [SerializeField] private Text _killText;
    
    public void UpdateText()
    {
        _damageText.text = _scoreControl.GetDamageScore().ToString();
        _killText.text = _scoreControl.GetKillScore().ToString();
    }
}
