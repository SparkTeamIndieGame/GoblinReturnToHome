using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockSystem : MonoBehaviour
{
    public static bool[] UnlockLevel = new bool[3];
    [SerializeField] private GameObject[] _lock;

    void Start()
    {
        if (UnlockLevel[0])
            _lock[0].SetActive(false);
        if (UnlockLevel[1])
            _lock[1].SetActive(false);
        if (UnlockLevel[2])
            _lock[2].SetActive(false);
    }
}
