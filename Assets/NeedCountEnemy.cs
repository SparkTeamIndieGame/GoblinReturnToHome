using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedCountEnemy : MonoBehaviour
{
    public static bool ContinueGame;

    [SerializeField] private float _needEnemy;
    [SerializeField] private Text _needEnemyText;

    [SerializeField] private Text _currentEnemyText;


    // Start is called before the first frame update
    private void OnEnable()
    {
        ContinueGame = false;
    }

    private void Start()
    {
        _needEnemyText.text = _needEnemy.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        var currentEnemy = float.Parse(_currentEnemyText.text);
        var needEnemy = float.Parse(_needEnemyText.text);

        if (currentEnemy >= needEnemy)
        {
            ContinueGame = true;
            SpawnObject.Spawn = false;
        }
    }

}
