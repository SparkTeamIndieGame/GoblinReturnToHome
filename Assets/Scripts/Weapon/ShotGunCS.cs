using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunCS : WeaponBase
{

    public override void Shoot()
    {
        
        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[i].position, SpawnPoint[0].rotation);
            newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint[i].forward * (BulletSpeed + MaxPlayerSpeed);
            _effect[i].Play();
            RemoveAmunicion();
            
        }
        ChekingAmunicion();
    }
              
    
    
     
}
