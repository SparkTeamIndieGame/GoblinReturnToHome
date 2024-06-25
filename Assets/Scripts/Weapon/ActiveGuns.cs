using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGuns : MonoBehaviour
{
    public static List<WeaponBase> weaponBases = new List<WeaponBase>();
    [SerializeField] private WeaponBase[] _weaponsLink;

    private void OnEnable()
    {
        WeaponBase.OnWeaponChange += ChangeGun;
    }

    private void OnDisable()
    {
        WeaponBase.OnWeaponChange -= ChangeGun;
    }

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

    private void ChangeGun()
    {
        for (int i = _weaponsLink.Length-1; i >= 0; i--)
        {
            switch (_weaponsLink[i].gameObject.name)
            {
                case "Slaughter":
                    {
                        if (AmunitionCount.SlaughterCount > 0)
                        {
                            _weaponsLink[i].gameObject.SetActive(true);
                            return;
                        }
                        break;
                    }

                case "Gun":
                    {
                        if (AmunitionCount.GunCount > 0)
                        {
                            _weaponsLink[i].gameObject.SetActive(true);
                            return;
                        }
                        break;
                    }

                case "ShotGun":
                    {
                        if (AmunitionCount.ShotGunCount > 0)
                        {
                            _weaponsLink[i].gameObject.SetActive(true);
                            return;
                        }
                        break;
                    }

                case "Machine":
                    {
                        if (AmunitionCount.MachineCount > 0)
                        {
                            _weaponsLink[i].gameObject.SetActive(true);
                            return;
                        }
                        break;
                    }
            }
        }
    }
}
