using System;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public static event Action OnWeaponChange;
    public  Transform[] SpawnPoint;
    public float ShootPeriod = 1.0f;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10.0f;

    public float StartAmunicionCount;

    protected float currentAmunicionCount;

    private float timer;
    readonly protected float MaxPlayerSpeed = 10.0f;

    private void Start()
    {
        if (StartAmunicionCount == 0)
        {
            StartAmunicionCount = Mathf.Infinity;
        }
        currentAmunicionCount = StartAmunicionCount;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > ShootPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                timer = 0;
                Debug.Log(currentAmunicionCount);
            }
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            AddAmunicion(12);
        }
    }

    public virtual void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[0].position, SpawnPoint[0].rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint[0].forward * (BulletSpeed + MaxPlayerSpeed);
        RemoveAmunicion();
        ChekingAmunicion();
    }
    public virtual void AddAmunicion(float value)
    {
        currentAmunicionCount += value;
    }
    public virtual void RemoveAmunicion()
    {
        currentAmunicionCount -= 1;
        
    }
    public virtual void ChekingAmunicion()
    {
        if (currentAmunicionCount <= 0)
        {
            this.gameObject.SetActive(false);
            OnWeaponChange?.Invoke();
        }
    }
    public virtual float GetActualScore()
    {
        return currentAmunicionCount;
    }
    



}
