using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTRiggerAnimPlayer : MonoBehaviour
{
    private Animator _player;

    private void Awake()
    {
        _player = GetComponent<Animator>();
    }

    public void PointEnter()
    {
        _player.SetBool("PointEnter", true);
    }

    public void PointExit()
    {
        _player.SetBool("PointEnter", false);
    }

}
