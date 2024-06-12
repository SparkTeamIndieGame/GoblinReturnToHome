using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldEffectFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    float offset;
    private void Start()
    {
        offset = transform.position.x - _player.position.x;
        
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.position.x + offset, transform.position.y, transform.position.z);
    }
}
