using UnityEngine;
using UnityEditor;
using System.Collections;
using System;

public class EnemyTurret : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _detectionRadius = 10.0f;
    [SerializeField] float _rotationSpeed = 5.0f;
    
    [SerializeField] Transform _firePoint;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] float _bulletSpeed = 10.0f;

    void Update()
    {
        if (_target == null) return;

        float distance = Vector3.Distance(transform.position, _target.position);
        if (distance < _detectionRadius)
        {
            RotateTurret();
            StartCoroutine(FireCoroutine());
        }
    }

    private void RotateTurret()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSpeed * Time.deltaTime);
    }

    private IEnumerator FireCoroutine()
    {
        var a = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            a.GetComponent<Rigidbody>().velocity = _firePoint.forward * (_bulletSpeed);

        var b = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            b.GetComponent<Rigidbody>().velocity = _firePoint.up * (_bulletSpeed);

        var c = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
            c.GetComponent<Rigidbody>().velocity = _firePoint.right * (_bulletSpeed);

        yield return new WaitForSecondsRealtime(0.1f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}