using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    static public bool Spawn;
    [Header("Enemies:")]
    public bool IsEnemy;
    public float Daley;
    public float DistanceEnemy;
    [Header("Weapon:")]
    public bool IsWeapon;
    public WeaponBase Weapon;
    public float Amunicion;
    [Header("Health")]
    public bool IsHealth;
    public PlayerController PlayerController;
    public float AddHealth;
    public ParticleSystem ParticleSystem;
    [Header("Standart Static")]
    public GameObject Object;
    public Transform[] Point;

    private List<GameObject> _gameObject = new List<GameObject>();

    private void OnEnable()
    {
        Spawn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (IsEnemy)
        {
            Object.GetComponent<EnemyBase>()._radius = DistanceEnemy;
        }
        else if (IsWeapon == true)
        {
            Object.GetComponent<AmourBonus>().ConnectWeapon(Weapon, Amunicion);
        }
        else if (IsHealth == true)
        {
            Object.GetComponent<HealthBonus>().ConnectHealth(PlayerController, AddHealth, ParticleSystem);
        }

        StartCoroutine("StartSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (!Spawn)
            ClearObjects();
    }

    public void ClearObjects()
    {
        for(int i =0; i < _gameObject.Count; i++)
        {
            if (_gameObject[i] == null)
                continue;
            else 
            _gameObject[i].SetActive(false);
        }
        _gameObject.Clear();
        gameObject.SetActive(false);
    }


    IEnumerator StartSpawn()
    {
        while(Spawn)
        {
            yield return new WaitForSeconds(Daley);
            var random = UnityEngine.Random.Range(0, Point.Length);
            GameObject @object = Instantiate(Object, Point[random].position, Quaternion.identity);
            _gameObject.Add(@object);

        }

    }
}
