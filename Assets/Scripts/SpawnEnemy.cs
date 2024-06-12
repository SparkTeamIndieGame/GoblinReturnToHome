using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    static public bool Spawn = true;
    public GameObject Enemy;
    public Transform[] Point;
    public float Daley;
    public float DistanceEnemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.GetComponent<EnemyBase>()._radius = DistanceEnemy;

        StartCoroutine("StartSpawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawn()
    {
        while(Spawn)
        {
            yield return new WaitForSeconds(Daley);
            var random = Random.Range(0, Point.Length);
            Instantiate(Enemy, Point[random].position, Quaternion.identity);

        }

    }
}
