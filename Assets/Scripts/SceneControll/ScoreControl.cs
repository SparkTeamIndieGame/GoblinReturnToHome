using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreControl : MonoBehaviour
{

    [SerializeField] private Text _damageScore;
    [SerializeField] private Text _killScore;
    private float templeDamageScore;
    private float templeKillScore;

    private void OnEnable()
    {
        EnemyBase.OnChangeDamage += DamageTextUpdate;
        EnemyBase.OnChangeKill += KillTextUpdate;
    }
    private void OnDisable()
    {
        EnemyBase.OnChangeDamage -= DamageTextUpdate;
        EnemyBase.OnChangeKill -= KillTextUpdate;
    }
    private void DamageTextUpdate(float value)
    {
        templeDamageScore = float.Parse(_damageScore.text);

        _damageScore.text = (templeDamageScore + value).ToString();
    }
    private void KillTextUpdate()
    {
        templeKillScore = float.Parse(_killScore.text);

        _killScore.text = (templeKillScore + 1).ToString();
    }
    public float GetDamageScore()
    {
        return float.Parse(_damageScore.text);
    }
    public float GetKillScore()
    {
        return float.Parse(_killScore.text);
    }
}
