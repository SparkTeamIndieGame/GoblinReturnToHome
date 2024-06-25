using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

public class EnemyBomb : EnemyHook
{
    public static event Action<float> DamageBomb;

    [SerializeField] private float _delayBomb, _distanceBomb, _damageBomb;
    [SerializeField] private ParticleSystem _bang;

    private bool _bomb = true;

    public override void Update()
    {
        base.Update();

        if (!_characterControler.isGrounded)
        {
            _targetPlayerX = Vector3.zero;
        }

        Animation();
    }

    public override void Animation()
    {
        if (_distance < _offsetDistance)
        {
            Animator.SetTrigger("Bomb");
            StartCoroutine("BombActive");
        }

        if (_distance < _radius)
        {
            Animator.SetBool("Run", true);
        }

        else if (_distance > _radius)
        {
            Animator.SetBool("Run", false);
        }

    }
    public void PlaySoundBomb()
    {
        AudioSystem.insance._enemy_bomb.Play();
    }

    IEnumerator BombActive()
    {
        
       
        yield return new WaitForSeconds(_delayBomb);

        _skin.gameObject.SetActive(false);
        _healhBarFront.SetActive(false);

        _speed = 0;
        _bang.Play();

        if (_distance < _distanceBomb)
        {
            if(_bomb)
            {
                DamageBomb?.Invoke(_damageBomb);
                _bomb = false;
            }
        }

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);

    }
}
