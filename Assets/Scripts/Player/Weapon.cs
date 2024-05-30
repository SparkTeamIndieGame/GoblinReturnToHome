using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public enum Weapons
    {
        Slaughter, Pistol, Shotgun, Machine
    }

    [SerializeField] private float _delay;
    [SerializeField] private float _ammunitionStore;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _pointWeapon;
    [SerializeField] private bool _standartWeapon;
    private bool _downMouse, _fire = true;
    public Weapons weapons;

    public class Slaughter
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(weapons == Weapons.Slaughter)
        {

        }

    }

    public void Fire(InputAction.CallbackContext context )
    {
        _downMouse = context.started;
        StartCoroutine("InstantiateBullet");
    }

    IEnumerator InstantiateBullet()
    {

        if(_fire && (_ammunitionStore!=0 || _standartWeapon))
        {
            Instantiate(_bullet, _pointWeapon.position, _pointWeapon.rotation);
            if (!_standartWeapon)
                _ammunitionStore--;
            StartCoroutine("Delay");
            yield return null;
        }
    }

    IEnumerator Delay()
    {
        _fire = false;
        yield return new WaitForSeconds(_delay);
        _fire = true;
    }


}
