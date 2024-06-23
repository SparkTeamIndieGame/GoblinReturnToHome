using System.Collections;
using UnityEngine;

public class StoneBigSpawn : MonoBehaviour
{
    [SerializeField] private StoneBig _stonePrefab;
    [SerializeField] private float _speed, _rotationSpeed;
    [SerializeField] private float _speedUpBy, _rotationSpeedUpBy;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform _destroyPoint;




    private void Start()
    {
        StartCoroutine(StoneSpawn());
    }
    private IEnumerator StoneSpawn()
    {
        while (true)
        {
            StoneBig newStone = Instantiate(_stonePrefab, transform.position, Quaternion.identity);
            newStone.Construct(_speed, _rotationSpeed, _destroyPoint);
            _speed += _speedUpBy;
            _rotationSpeed += _rotationSpeedUpBy;
            yield return new WaitForSeconds(_spawnDelay);
        }
    }
    private void OnEnable()
    {
        StopAllCoroutines();
    }
}
