using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class NeedCountEnemy : MonoBehaviour
{
    public static bool ContinueGame;

    [SerializeField] private Text _needEnemyText;
    [SerializeField] private float _needEnemy;

    [SerializeField] private Text _killText;
    [SerializeField] private Text _damageText;

    private float currentKill;
    private float currentDamage;

    private void OnEnable()
    {
        ContinueGame = false;
        EnemyBase.OnChangeKill += UpdateKillText;
        EnemyBase.OnChangeDamage += UpdateDamageText;
    }

    private void OnDisable()
    {
        EnemyBase.OnChangeKill -= UpdateKillText;
        EnemyBase.OnChangeDamage -= UpdateDamageText;
    }

    private void Start()
    {
        _needEnemyText.text = _needEnemy.ToString();
    }

    void Update()
    {
        if (currentKill >= _needEnemy)
        {
            ContinueGame = true;
            SpawnObject.Spawn = false;
        }
    }

    private void UpdateKillText()
    {
        currentKill += 1;
        _killText.text = currentKill.ToString();
    }

    private void UpdateDamageText(float value)
    {
        currentDamage = float.Parse(_damageText.text);
        _damageText.text = (currentDamage + value).ToString();
    }

    public float GetKillScore()
    {
        return float.Parse(_killText.text);
    }

    public float GetDamageScore()
    {
        return float.Parse(_damageText.text);
    }
}
