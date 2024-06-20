using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] weapon;
    [SerializeField] private bool[] _activeWeapon;
    int num;

    [Range(0, 4)]
    [SerializeField] private int _startWeapon;

    private void Start()
    {
        for(int i =0; i<weapon.Length; i++)
        {
            if (i == _startWeapon)
                weapon[i].SetActive(true);
            else
                weapon[i].SetActive(false);
        }
        num = _startWeapon;
    }


    void Update()
    {
        //InputKey();
        Changed();
    }

    private void Changed()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            num++;
            if (num == weapon.Length)
                num = 0;
            else if (!_activeWeapon[num])
                num = 0;
            
            SetActive(num);
        }

    }
    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && _activeWeapon[0])
        {
            num = 0;
            SetActive(num);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) && _activeWeapon[1])
        {
            num = 1;
            SetActive(num);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && _activeWeapon[2])
        {
            num = 2;
            SetActive(num);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && _activeWeapon[3])
        {
            num = 3;
            SetActive(num);
        }
    }

    private void SetActive(int num)
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            if (i != num)
                weapon[i].SetActive(false);
            else
                weapon[i].SetActive(true);
        }
    }

    //public void Fire(InputAction.CallbackContext context)
    //{
        
    //}
}
