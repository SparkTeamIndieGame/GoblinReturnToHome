using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    static public bool Spawn;
    [Header("Enemies:")]
    public bool IsEnemy;
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
    public float Daley;
    public int MaxItemInSceneOnTime;
    

    private List<GameObject> _gameObject = new List<GameObject>();

    private void OnEnable()
    {
        Spawn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (MaxItemInSceneOnTime == 0)
        {
            MaxItemInSceneOnTime = Point.Length;

        }
        if (IsEnemy)
        {
            EnemyBase.OnKillBossFigth += RemoveFromList;
            Object.GetComponent<EnemyBase>()._radius = DistanceEnemy;
        }
        else if (IsWeapon == true)
        {
            AmourBonus.OnUsedBossFigth += RemoveFromList;
            Object.GetComponent<AmourBonus>().ConnectWeapon(Weapon, Amunicion);
        }
        else if (IsHealth == true)
        {
            HealthBonus.OnUseBossFigth += RemoveFromList;
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
        while (Spawn)
        {
            yield return new WaitForSeconds(Daley);

            if (_gameObject.Count < MaxItemInSceneOnTime)
            {
                var random = UnityEngine.Random.Range(0, Point.Length);
                GameObject @object = Instantiate(Object, Point[random].position, Quaternion.identity);
                _gameObject.Add(@object);

            }
            else
            {
                yield return new WaitForSeconds(1.0f);

            }

        }


    }
    private void RemoveFromList(GameObject gameObject)
    {
        _gameObject.Remove(gameObject);
    }
}
