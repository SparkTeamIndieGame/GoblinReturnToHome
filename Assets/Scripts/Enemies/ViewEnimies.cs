using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnimies : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemies;
    [SerializeField] private GameObject _player;

    [Space (10)]
    [SerializeField] private float _distancionActivation;
    [SerializeField] private float _distancionDeactivation;

    private float currentDistance;

    private void Update()
    {
        ActiveAndDectivate();
    }

    private void ActiveAndDectivate()
    {
        for (int i = 0; i < _enemies.Length; i++)
        {
            currentDistance = Vector3.Distance(_player.transform.position, _enemies[i].transform.position);
            if (currentDistance <= _distancionActivation && _enemies[i].activeSelf == false)
            {
                _enemies[i].gameObject.SetActive(true);
            }
            else if (currentDistance > _distancionDeactivation && _enemies[i].activeSelf == true)
            {
                _enemies[i].gameObject.SetActive(false);
            }
          
        }
    }
}
