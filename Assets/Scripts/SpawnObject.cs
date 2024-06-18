using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    static public bool Spawn;
    static public bool PressStart;
    [Header("Enemies:")]
    public bool IsEnemy;
    //public float DistanceEnemy;
    [Header("Weapon:")]
    public bool IsWeapon;
    public WeaponBase Weapon;
    public float Amunicion;
    [Header("Health")]
    //public bool IsHealth;
    //public PlayerController PlayerController;
    //public float AddHealth;
    //public ParticleSystem ParticleSystem;
    [Header("Standart Static")]
    public GameObject Object;
    public List<Transform> Point;
    public float Daley;
    public int MaxItemInSceneOnTime;

    //[Header("CoolDownPanel")]
    //[SerializeField] private GameObject _coolDownPanel;
    

    private List<GameObject> _gameObject = new List<GameObject>();

    
    // Start is called before the first frame update
    void Start()
    {
        Spawn = true;
        PressStart = false;

        CreateArray();

        if (MaxItemInSceneOnTime == 0)
        {
            MaxItemInSceneOnTime = Point.Count;

        }
        if (IsEnemy)
        {
            EnemyBase.OnKillBossFigth += RemoveFromList;
            //Object.GetComponent<EnemyBase>()._radius = DistanceEnemy;
        }
        else if (IsWeapon == true)
        {
            AmourBonus.OnUsedBossFigth += RemoveFromList;
            Object.GetComponent<AmourBonus>().ConnectWeapon(Weapon, Amunicion);
        }
        //else if (IsHealth == true)
        //{
        //    HealthBonus.OnUseBossFigth += RemoveFromList;
        //    Object.GetComponent<HealthBonus>().ConnectHealth(PlayerController, AddHealth, ParticleSystem);
        //}

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

    private void CreateArray()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Point.Add(transform.GetChild(i));
        }
    }

    private void CheckNullArray()
    {
        for(int i = 0; i<_gameObject.Count; i++)
        {
            if (_gameObject[i] == null)
                _gameObject.Remove(_gameObject[i]);

        }


    }


    IEnumerator StartSpawn()
    {

        while(!PressStart)
        yield return new WaitForSeconds(1);
        List<int> randomValue = new List<int>();
        int random;
        while (Spawn)
        {
            yield return new WaitForSeconds(Daley);

            if (_gameObject.Count < MaxItemInSceneOnTime)
            {
               
                random = UnityEngine.Random.Range(0, Point.Count);
                if (randomValue.Count > 0)
                {
                    for (int i = 0; i < randomValue.Count; i++)
                    {
                        if (randomValue[i] == random)
                        {
                            random = UnityEngine.Random.Range(0, Point.Count);
                        }
                    }
                }
                GameObject @object = Instantiate(Object, Point[random].transform.position, Quaternion.identity);
                _gameObject.Add(@object);
                randomValue.Add(random);
            }
            else
            {
                CheckNullArray();
                yield return new WaitForSeconds(1.0f);

            }
        }
     
        

    }
    private void RemoveFromList(GameObject gameObject)
    {
        _gameObject.Remove(gameObject);
    }
}
