using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpownBee : MonoBehaviour
{
    [SerializeField] private GameObject _bee;
    [SerializeField] private GameObject _healhBarFront;
    [SerializeField] private Transform _player, _spawnPoint;
    [SerializeField] private float _health, _maxHealth;
    [SerializeField] private float _delaySpawn;
    [SerializeField] private float _radius;
    private float _distance;
    private bool _startCorutine;
    private BeeMove _beeMove;


    private float GetDistance
    {
        get
        {
            return Vector3.Distance(_player.position, transform.position);
        }
    }

    private bool InRadiusOfAttack
    {
        get
        {
            return GetDistance < _radius;
        }
    }

    private void Start()
    {
        _maxHealth = _health;
    }

    private void Update()
    {

        Updating();

        CheckHealt();

    }

    private void Updating()
    {
        if (InRadiusOfAttack && !_startCorutine)
        {
            StartCoroutine(StartSpown());
        }

        else if (!InRadiusOfAttack)
        {
            StopAllCoroutines();
            _startCorutine = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BulletCharacter damage))
        {
            _health -= damage._damage;

            var healthProcent = (_health / _maxHealth) * 100.0f;
            var healthBarProcent = healthProcent / 100.0f;

            _healhBarFront.transform.localScale = new Vector3(healthBarProcent, 1.0f, 1.0f);

            AudioSystem.insance._enemy_damage.Play();
        }
    }

    private void CheckHealt()
    {
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator StartSpown()
    {
        _startCorutine = true;

        while(_distance < _radius)
        {
            yield return new WaitForSeconds(_delaySpawn);
            GameObject bee = Instantiate(_bee, _spawnPoint.position, Quaternion.identity);
            bee.GetComponent<BeeMove>().enabled = true;
        }

        _startCorutine = false;

    }

#if UNITY_EDITOR

    public virtual void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(this.transform.position, Vector3.forward, _radius);
    }
#endif

}
