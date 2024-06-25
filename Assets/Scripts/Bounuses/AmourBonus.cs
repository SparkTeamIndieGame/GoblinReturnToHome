using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmourBonus : MonoBehaviour
{
    public static event Action<GameObject> OnUsedBossFigth;

    [SerializeField] private WeaponBase _weapon;
    [SerializeField] private float _amuniceAdd;
    [SerializeField] private ParticleSystem _effect;
    
    public void ConnectWeapon(WeaponBase weapon, float amunicion)
    {
        _weapon = weapon;
        _amuniceAdd = amunicion;
    }
    private void OnTriggerEnter(Collider other)
    {

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

}
