using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmourBonus : MonoBehaviour
{
    [SerializeField] private WeaponBase _weapon;
    [SerializeField] private float _amuniceAdd;
    [SerializeField] private bool _isWeaponBonus;
    [SerializeField] private ParticleSystem _effect;

    private void OnTriggerEnter(Collider other)
    {
        //if (_isWeaponBonus)
        //{
            
            if (_weapon.gameObject.activeSelf == false)
            {
                for (int i = 0; i < ActiveGuns.weaponBases.Count; i++)
                {
                    ActiveGuns.weaponBases[i].gameObject.SetActive(false);
                }
                _weapon.gameObject.SetActive(true);

            if(_weapon.GetActualScore() <= 0)
                _weapon.AddAmunicion(_weapon.StartAmunicionCount);
            }
            else
            {
                _weapon.AddAmunicion(_amuniceAdd);
            }
        //}
        //else if (!_isWeaponBonus)
        //{
        //    //if (_weapon.gameObject.activeSelf == true)
        //    //{
        //    //    //_weapon.AddAmunicion(_amuniceAdd);
        //    //}
        //    AddAmunition(_amuniceAdd);
            
            
        //}
        AudioSystem.insance._gun.Play();
        Instantiate(_effect, transform.position, Quaternion.identity);

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
