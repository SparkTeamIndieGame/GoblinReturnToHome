using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Weapon : MonoBehaviour
{

    private enum TypeWeapon
    {
        Slaughter, Gun, Shotgun, Machine
    }


    [SerializeField] private TypeWeapon _typeWeapon;
    [SerializeField] private float _delay;
    [SerializeField] private float _maxBulletMachine, _delayMachine;
    [SerializeField] private float _ammunitionStore;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Bullet _bulletTest;
    [SerializeField] private Transform[] _pointBullet;

    private bool _standartWeapon;
    private bool _downMouse, _fire = true;
    private int _currentBulletMachine;


    private void Awake()
    {
        if (_typeWeapon == TypeWeapon.Slaughter)
            _standartWeapon = true;
    }

    public void Fire(InputAction.CallbackContext context )
    {
        if(gameObject.activeInHierarchy)
        {
            _downMouse = context.started;
            InstantiateBullet();
        }
    }

    private void SlaughterUse()
    {
        Instantiate(_bullet, _pointBullet[0].position, _pointBullet[0].rotation);
    }

    private void GunUse()
    {
        Instantiate(_bullet, _pointBullet[0].position, _pointBullet[0].rotation);
        _ammunitionStore--;
        
    }

    private void ShotgunUse()
    {
        for(int i =0; i<_pointBullet.Length; i++)
        Instantiate(_bullet, _pointBullet[i].position, _pointBullet[i].rotation);

        _ammunitionStore -= 3;

    }

    private void MachineUse()
    {
        StartCoroutine("DelayBulletMachine");
    }

    private void InstantiateBullet()
    {

        if(_fire && (_ammunitionStore!=0 || _standartWeapon))
        {
            if (_typeWeapon == TypeWeapon.Slaughter)
                SlaughterUse();
            else if (_typeWeapon == TypeWeapon.Gun)
                GunUse();
            else if (_typeWeapon == TypeWeapon.Shotgun)
                ShotgunUse();
            else if (_typeWeapon == TypeWeapon.Machine)
                MachineUse();

            //if (!_standartWeapon)
            //    _ammunitionStore--;
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        _fire = false;
        yield return new WaitForSeconds(_delay);
        _fire = true;
    }

    IEnumerator DelayBulletMachine()
    {
        while(_currentBulletMachine < _maxBulletMachine)
        {
            Instantiate(_bullet, _pointBullet[0].position, _pointBullet[0].rotation);
            _ammunitionStore--;
            _currentBulletMachine++;
            yield return new WaitForSeconds(_delayMachine);
        }

        _currentBulletMachine = 0;
    }



}
