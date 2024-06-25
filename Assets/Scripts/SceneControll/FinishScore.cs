using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FinishScore : MonoBehaviour
{
    [SerializeField] private GameObject _playerInput;
    [SerializeField] private ScoreControl _scoreControl;
    [SerializeField] private NeedCountEnemy _needCountEnemy;

    [SerializeField] private Text _damageText;
    [SerializeField] private Text _killText;
    [SerializeField] private Text _rank;
    [SerializeField] private List<string> _listRank;
    [SerializeField] private List<int> _listRangeEnemy;
    
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

        if (_scoreControl.GetKillScore() <= _listRangeEnemy[1])
            _rank.text = _listRank[0];

        else if (_scoreControl.GetKillScore() > _listRangeEnemy[1] && _scoreControl.GetKillScore() <= _listRangeEnemy[2])
            _rank.text = _listRank[1];

        else if (_scoreControl.GetKillScore() > _listRangeEnemy[2] && _scoreControl.GetKillScore() <= _listRangeEnemy[3])
            _rank.text = _listRank[2];

        else if (_scoreControl.GetKillScore() > _listRangeEnemy[3])
            _rank.text = _listRank[3];

    }
}
