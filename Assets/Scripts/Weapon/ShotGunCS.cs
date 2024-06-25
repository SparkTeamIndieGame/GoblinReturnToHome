using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunCS : WeaponBase
{
    public override void AddAmunicion(float value)
    {
        AmunitionCount.ShotGunCount += value;
    }

    public override void RemoveAmunicion()
    {
        AmunitionCount.ShotGunCount -= 1;
        UseActualAmourCount();
    }

    public override void ChekingAmunicion()
    {
        if (AmunitionCount.ShotGunCount <= 0)
        {
            base.Event();
        }
    }

    public override float GetActualScore()
    {
        return AmunitionCount.ShotGunCount;
    }

    public override void Shoot()
    {
        
        for (int i = 0; i < SpawnPoint.Length; i++)
        {
            GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[i].position, SpawnPoint[0].rotation);
            newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint[i].forward * (BulletSpeed + MaxPlayerSpeed);
            _effect[i].Play();
            _soundShoot.Play();
            RemoveAmunicion();
            
        }
        ChekingAmunicion();
    }




}
