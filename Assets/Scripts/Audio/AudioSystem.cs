using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    public static AudioSystem insance = null;

    [Header("Player")]
    public AudioSource _player_walk;
    public AudioSource _player_jump;
    public AudioSource _player_damage;
    public AudioSource _player_dead;

    [Header("Enemy")]
    public AudioSource _enemy_damage;
    public AudioSource _enemy_bomb;
    public AudioSource _enemy_attack;

    [Header("Bullet")]
    public AudioSource _bullet_slaughter;
    public AudioSource _bullet_gun;
    public AudioSource _bullet_shotgun;
    public AudioSource _bullet_machine;

    [Header("Bonus")]
    public AudioSource _bullet;
    public AudioSource _HP;
    public AudioSource _gun;

    [Header("Scene")]
    public AudioSource _win;
    public AudioSource _background;
    //public AudioSource _rod;
    public AudioSource _door;


    private void Start()
    {
        if (insance == null)
            insance = this;
        else if (insance == this)
            Destroy(gameObject);
    }
}
