using UnityEngine;
using System.Collections;
using System;
using UnityEditor;

public class EnemyBomb : EnemyHook
{
    public static event Action<float> DamageBomb;

    [SerializeField] private float _delayBomb, _distanceBomb, _damageBomb;
    [SerializeField] private ParticleSystem _bang;
    private bool _bomb;

    public override void Update()
    {
        base.Update();
        if (!_characterControler.isGrounded)
            _targetPlayerX = Vector3.zero;

        //Pursuit();
        Animation();
        

    }
    //public override void Pursuit()
    //{
    //    if (_distance < _radius && !_bomb)
    //        _targetPlayerX = new Vector3(_playerTransform.position.x - transform.position.x, 0, 0);

    //    else if(_distance > _radius)
    //        _targetPlayerX = Vector3.zero;

    //    if (_distance < _offsetDistance)
    //    {
    //        _targetPlayerX = Vector3.zero;
    //        _bomb = true;
    //    }

    //}
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
    

    IEnumerator BombActive()
    {
        
       
        yield return new WaitForSeconds(_delayBomb);
        _skin.gameObject.SetActive(false);
        _healhBarFront.SetActive(false);
        _speed = 0;
        _bang.Play();
        yield return new WaitForSeconds(Time.fixedDeltaTime);
        if (_distance < _distanceBomb)
        {
            DamageBomb?.Invoke(_damageBomb);
            print($"{_playerTransform.gameObject.name}, получил урон в {_damageBomb} едениц взрывом, у него осталось {_playerTransform.gameObject.GetComponent<PlayerController>().Health}, ");
        }

        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);



    }
}
