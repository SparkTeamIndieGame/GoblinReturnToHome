using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    static public bool Spawn;
    public bool IsEnemy;
    public GameObject Object;
    public Transform[] Point;
    public float Daley;
    public float DistanceEnemy;

    private List<GameObject> _gameObject = new List<GameObject>();

    private void OnEnable()
    {
        Spawn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        if(IsEnemy)
            Object.GetComponent<EnemyBase>()._radius = DistanceEnemy;

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
            var random = Random.Range(0, Point.Length);
            GameObject @object = Instantiate(Object, Point[random].position, Quaternion.identity);
            _gameObject.Add(@object);

        }

    }
}
