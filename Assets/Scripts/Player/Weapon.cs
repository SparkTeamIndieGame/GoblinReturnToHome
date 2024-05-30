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
    [SerializeField] private float _ammunitionStore;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform[] _pointBullet;

    private bool _standartWeapon;
    private bool _downMouse, _fire = true;

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

    private void InstantiateBullet()
    {

        if(_fire && (_ammunitionStore!=0 || _standartWeapon))
        {
            if (_typeWeapon == TypeWeapon.Slaughter)
                SlaughterUse();
            else if (_typeWeapon == TypeWeapon.Gun)
                SlaughterUse();
            else if (_typeWeapon == TypeWeapon.Shotgun)
                print("ShotGun");
            else if (_typeWeapon == TypeWeapon.Machine)
                print("Automat");

            if (!_standartWeapon)
                _ammunitionStore--;
            StartCoroutine("Delay");
        }
    }

    IEnumerator Delay()
    {
        _fire = false;
        yield return new WaitForSeconds(_delay);
        _fire = true;
    }


}
