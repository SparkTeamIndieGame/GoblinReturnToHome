using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class NeedCountEnemy : MonoBehaviour
{
    public static bool ContinueGame;

    [SerializeField] private float _needEnemy;
    [SerializeField] private Text _needEnemyText;

    [SerializeField] private Text _killText;
    private float currentKill;
    [SerializeField] private Text _damageText;
    private float currentDamage;

    // Start is called before the first frame update
    private void OnEnable()
    {
        ContinueGame = false;
        EnemyBase.OnChangeKill += UpdateKillText;
        EnemyBase.OnChangeDamage += UpdateDamageText;
    }

    private void Start()
    {
        _needEnemyText.text = _needEnemy.ToString();
    }
    // Update is called once per frame
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
