using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunCS : WeaponBase
{
    
    override public void Update()
    {
        timer += Time.deltaTime;
        if (timer > ShootPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 0.0f;
                for (int i = 0; i < SpawnPoint.Length; i++)
                {
                    GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[i].position, SpawnPoint[0].rotation);
                    newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint[i].forward * (BulletSpeed + MaxPlayerSpeed);
                }
                
            }
        }
    }
}
