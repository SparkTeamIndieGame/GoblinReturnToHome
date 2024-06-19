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
    // Start is called before the first frame update
    public void PointEnter()
    {
        _player.SetBool("PointEnter", true);
    }

    public void PointExit()
    {
        _player.SetBool("PointEnter", false);
    }

}
