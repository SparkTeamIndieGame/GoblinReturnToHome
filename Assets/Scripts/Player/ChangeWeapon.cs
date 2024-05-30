using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] weapon;
    [SerializeField] private PlayerInput PlayerInput;
    int num;
    // Update is called once per frame
    void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            num = 0;
            SetActive(num);
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            num = 1;
            SetActive(num);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            num = 2;
            SetActive(num);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
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
