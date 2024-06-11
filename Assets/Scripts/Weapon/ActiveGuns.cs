using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGuns : MonoBehaviour
{
    [SerializeField] private WeaponBase[] _weaponsLink;
    public static List<WeaponBase> weaponBases = new List<WeaponBase>();
    private void Start()
    {
        if (weaponBases.Count > 0)
        {
            weaponBases.Clear();
        }

        for (int i = 0; i < _weaponsLink.Length; i++)
        {
            weaponBases.Add(_weaponsLink[i]);
        }
    }
    private void OnEnable()
    {
        WeaponBase.OnWeaponChange += ChangeGun;
    }
    private void OnDisable()
    {
        WeaponBase.OnWeaponChange -= ChangeGun;
    }
    private void ChangeGun()
    {
        for (int i = _weaponsLink.Length-1; i >= 0; i--)
        {
            if (_weaponsLink[i].GetActualScore() > 0)
            {
                _weaponsLink[i].gameObject.SetActive(true);
                //_weaponsLink[i].UseActualWeaponSprite();
                //_weaponsLink[i].UseActualAmourCount();
                return;
            }
        }
    }
}
