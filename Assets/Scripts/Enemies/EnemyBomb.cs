using UnityEngine;
using System.Collections;

public class EnemyBomb : EnemyHook
{
    [SerializeField] private float _delayBomb, _distanceBomb, _damageBomb;
    [SerializeField] private ParticleSystem _bang;
    private bool _bomb;

    public override void Update()
    {
        base.Update();
        if (!_characterControler.isGrounded)
            _targetPlayerX = Vector3.zero;

        //Pursuit();

        if (_distance < base._offsetDistance)
            StartCoroutine("BombActive"); //или через bool в аниматоре 

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

    IEnumerator BombActive()
    {
        _bang.Play();
        yield return new WaitForSeconds(_delayBomb);

        if (_distance < _distanceBomb)
        {
            _playerTransform.gameObject.GetComponent<PlayerController>().Health -= _damageBomb;
            print($"{_playerTransform.gameObject.name}, получил урон в {_damageBomb} едениц взрывом, у него осталось {_playerTransform.gameObject.GetComponent<PlayerController>().Health}, ");
        }
        Destroy(gameObject);

    }
}
