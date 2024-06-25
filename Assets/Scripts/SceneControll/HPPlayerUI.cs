using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPPlayerUI : MonoBehaviour
{
    [SerializeField] private Slider _playerHp;
    [SerializeField] private PlayerController _player;

    private void Start()
    {
        _playerHp.maxValue = _player.maxHealth;
        _playerHp.value = _player.Health;

    }
    private void Update() 
    {
        _playerHp.value = _player.Health;
    }
}
