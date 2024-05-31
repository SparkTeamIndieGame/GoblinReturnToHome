using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    public Transform[] SpawnPoint;
    public float ShootPeriod = 1.0f;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10.0f;

    protected float timer;
    readonly protected float MaxPlayerSpeed = 10.0f;
    

    public override void Update()
    {
        base.Monitoring();

        Timer();

        if(_distance < _radius)
            RayCheck();

        
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[0].position, SpawnPoint[0].rotation);
        newBullet.GetComponent<Rigidbody>().velocity = -SpawnPoint[0].forward * (BulletSpeed + MaxPlayerSpeed); // изменить при настройке модели врага "-"
    }

    private void RayCheck()
    {
        Ray ray = new Ray(SpawnPoint[0].position, -SpawnPoint[0].forward);// изменить при настройке модели врага "-"
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
        if (timer > ShootPeriod && Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.GetComponent<CharacterController>())
            {
                Shoot();
                timer = 0;
            }
        }
    }

    private void Timer()
    {
        timer += Time.deltaTime;
    }

}
