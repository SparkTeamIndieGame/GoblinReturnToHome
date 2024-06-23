using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmourBonus : MonoBehaviour
{
    public static event Action<GameObject> OnUsedBossFigth;

    [SerializeField] private WeaponBase _weapon;
    [SerializeField] private float _amuniceAdd;
    //[SerializeField] private bool _isWeaponBonus;
    [SerializeField] private ParticleSystem _effect;
    
    public void ConnectWeapon(WeaponBase weapon, float amunicion)
    {
        _weapon = weapon;
        _amuniceAdd = amunicion;
    }
    private void OnTriggerEnter(Collider other)
    {


        //if (_weapon.gameObject.activeSelf == false)
        //{
        //    for (int i = 0; i < ActiveGuns.weaponBases.Count; i++)
        //    {
        //        ActiveGuns.weaponBases[i].gameObject.SetActive(false);
        //    }
        //    _weapon.gameObject.SetActive(true);

        //if(_weapon.GetActualScore() <= 0)
        //    _weapon.AddAmunicion(_weapon.StartAmunicionCount);
        //}
        //else
        //{
        //    _weapon.AddAmunicion(_amuniceAdd);
        //}
        //if (_weapon.gameObject.activeSelf == false)
        //{
        //    for (int i = 0; i < ActiveGuns.weaponBases.Count; i++)
        //    {
        //        ActiveGuns.weaponBases[i].gameObject.SetActive(false);
        //    }
        //    _weapon.gameObject.SetActive(true);

        //    if (_weapon.GetActualScore() <= 0)
        //        _weapon.AddAmunicion(_amuniceAdd);
        //}
        //else
        //{
        //    _weapon.AddAmunicion(_amuniceAdd);
        //}

        _weapon.AddAmunicion(_amuniceAdd);
        if (this._weapon.gameObject.activeSelf == true)
        {
            _weapon.UseActualAmourCount();
        }
        


        AudioSystem.insance._gun.Play();
        Instantiate(_effect, transform.position, Quaternion.identity);
        OnUsedBossFigth?.Invoke(this.gameObject);
        Destroy(this.gameObject);


    }

    //private void AddAmunition(float amunitAdd)
    //{
    //    switch (_weapon.gameObject.name)
    //    {
    //        case "Slaughter":
    //            {
    //                AmunitionCount.SlaughterCount += amunitAdd;
    //                break;
    //            }

    //        case "Gun":
    //            {
    //                AmunitionCount.GunCount += amunitAdd;
    //                break;
    //            }

    //        case "ShotGun":
    //            {
    //                AmunitionCount.ShotGunCount += amunitAdd;
    //                break;
    //            }

    //        case "Machine":
    //            {
    //                AmunitionCount.MachineCount += amunitAdd;
    //                break;
    //            }
    //    }
    //}
}
