using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmourBonus : MonoBehaviour
{
    [SerializeField] private WeaponBase _weapon;
    [SerializeField] private float _amuniceAdd;
    [SerializeField] private bool _isWeaponBonus;

    private void OnTriggerEnter(Collider other)
    {
        if (_isWeaponBonus)
        {
            
            if (_weapon.gameObject.activeSelf == false)
            {
                for (int i = 0; i < ActiveGuns.weaponBases.Count; i++)
                {
                    ActiveGuns.weaponBases[i].gameObject.SetActive(false);
                }
                _weapon.gameObject.SetActive(true);
            }
            else
            {
                _weapon.AddAmunicion(_amuniceAdd);
            }
        }
        else if (!_isWeaponBonus)
        {
            if (_weapon.gameObject.activeSelf == true)
            {
                _weapon.AddAmunicion(_amuniceAdd);
            }
            
            
        }
        Destroy(this.gameObject);
        
    }
}
