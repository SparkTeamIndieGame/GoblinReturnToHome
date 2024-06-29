using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] Transform _target;                             // transform игрока
    [SerializeField] float _detectionRadius = 15.0f;                // радиус обнаружения игрока (предупреждение)
    [SerializeField] float _firingRadius = 12.0f;                   // радиус для активации стрельбы по игроку
    [SerializeField] float _rotationSpeed = 5.0f;                   // скорость поворота пулемета
    
    [SerializeField] Transform _firePoint;                          // точка вылета пули
    [SerializeField] GameObject _bulletPrefab;                      // prefab пули
    [SerializeField] float _bulletSpeed = 15.0f;                    // скорость полета пули
    [SerializeField] float _fireRatePerSecond = 2.0f;               // скорострельность пулемета в секунду
    float _nextFireRate = 0f;                                       // промежуточная переменная подсчета \
                                                                    // следующего выстрела
    [SerializeField] float _rotatingTurretMuzzlesSpeed = 360.0f;    // угол поворота дул пулемета в секунду
    [SerializeField] GameObject[] _rotatableTurretMuzzles;          // объекты пулемета, подверживаемые повороту

    [SerializeField] float _maxHeat = 10f;                          // Max heat before overheating
    [SerializeField] float _heatPerShot = 1f;                       // Heat added per shot
    [SerializeField] float _cooldownRate = 2f;                      // Heat cooldown rate per second
    private float _currentHeat = 0f;                                // Current heat level
    private bool _isOverheated = false;                             // Overheated state

    [SerializeField] ParticleSystem _fireParticles;                 // Particle system for firing
    [SerializeField] ParticleSystem _overheatParticles;             // Particle system for overheating


    public bool InsideFiringRadius => Vector3.Distance(transform.position, _target.position) < _firingRadius;

    public bool InsideDetectionRadius => Vector3.Distance(transform.position, _target.position) < _detectionRadius;

    void Update()
    {
        if (_target == null) return;

        if (InsideDetectionRadius)
        {
            TargetingToPlayer();
        }
        if (InsideFiringRadius)
        {
            RotateMuzzles();
            FirePerSecond(_fireRatePerSecond);
        }

        Cooldown();
    }

    private void RotateMuzzles()
    {
        foreach (var muzzle in _rotatableTurretMuzzles)
        {
            muzzle.transform.Rotate(Vector3.right * _rotatingTurretMuzzlesSpeed * Time.deltaTime);
        }
    }

    private void TargetingToPlayer()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }

    private void FirePerSecond(float fireRate)
    {
        if (Time.time >= _nextFireRate)
        {
            Fire();
            _nextFireRate = Time.time + 1.0f / fireRate;
        }
    }

    private void Fire()
    {
        if (_currentHeat >= _maxHeat)
        {
            Overheat();
            return;
        }

        if (_isOverheated) return;

         GameObject bullet =  Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = _firePoint.right * _bulletSpeed;
        _currentHeat += _heatPerShot;

        _fireParticles?.Play();
    }

    private void Overheat()
    {
        _isOverheated = true;
        _overheatParticles?.Play();
    }

    private void Cooldown()
    {
        if (_isOverheated)
        {
            _currentHeat -= _cooldownRate * Time.deltaTime;
            if (_currentHeat <= 0f)
            {
                _currentHeat = 0f;
                _isOverheated = false;
                _overheatParticles?.Stop();
            }
        }
        else if (_currentHeat > 0f)
        {
            _currentHeat -= _cooldownRate * Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _firingRadius);
    }
}