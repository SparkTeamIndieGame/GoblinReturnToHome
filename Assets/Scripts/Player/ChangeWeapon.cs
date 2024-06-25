using UnityEngine;
using UnityEngine.InputSystem;

public class ChangeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject[] weapon;
    private int num;

    void Update()
    {
        Changed();
    }

    private void Changed()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            num++;
            if (num == weapon.Length)
            {
                num = 0;
            }

            SetActive(num);
        }

    }

    private void SetActive(int num)
    {
        for (int i = 0; i < weapon.Length; i++)
        {
            if (i != num)
            {
                weapon[i].SetActive(false);
            }

            else
            {
                weapon[i].SetActive(true);
            }
        }
    }
}
