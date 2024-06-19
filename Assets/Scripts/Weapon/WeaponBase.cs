using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponBase : MonoBehaviour
{
    public static event Action OnWeaponChange;

    public Sprite WeaponSprite;
    public Image WeaponImage;
    public Text ActualAmunitionScore;
    public  Transform[] SpawnPoint;
    public float ShootPeriod = 1.0f;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10.0f;

    public float StartAmunicionCount;

    protected float currentAmunicionCount;

    private float timer;
    readonly protected float MaxPlayerSpeed = 10.0f;

    [SerializeField] protected ParticleSystem[] _effect;
    [SerializeField] protected AudioSource _soundShoot;

    private void Start()
    {
        StartCountAmun();
        UseActualAmourCount();
    }
    private void Update()
    {

        //Debug.Log(currentAmunicionCount);
        timer += Time.deltaTime;
        if (timer > ShootPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                timer = 0;
                
            }
        }
        
    }

    public virtual void StartCountAmun()
    {
        switch (gameObject.name)
        {
            case "Slaughter":
                {
                    AmunitionCount.SlaughterCount = Mathf.Infinity;
                    break;
                }

            case "Gun":
                {
                    AmunitionCount.GunCount = Mathf.Infinity;
                    break;
                }

            case "ShotGun":
                {
                    AmunitionCount.ShotGunCount = Mathf.Infinity;
                    break;
                }

            case "Machine":
                {
                    AmunitionCount.MachineCount = Mathf.Infinity;
                    break;
                }
        }
    }


    public virtual void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[0].position, SpawnPoint[0].rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint[0].forward * (BulletSpeed + MaxPlayerSpeed);
        _effect[0].Play();
        _soundShoot.Play();
        RemoveAmunicion();
        ChekingAmunicion();
    }
    public virtual void AddAmunicion(float value)
    {
        //currentAmunicionCount += value;
        //UseActualAmourCount();
    }
    public virtual void RemoveAmunicion()
    {
        //currentAmunicionCount -= 1;
        //UseActualAmourCount();
    }
    public virtual void ChekingAmunicion()
    {
        //if (currentAmunicionCount <= 0)
        //{
        //    this.gameObject.SetActive(false);
        //    OnWeaponChange?.Invoke();
        //}
    }
    public virtual float GetActualScore()
    {
         return currentAmunicionCount;
        
    }
    public virtual void UseActualWeaponSprite()
    {
        WeaponImage.sprite = WeaponSprite;
    }
    public virtual void UseActualAmourCount()
    {
        if (GetActualScore() > int.MaxValue)
        {
            ActualAmunitionScore.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -70.0f);
            ActualAmunitionScore.text = "8";
        }
        else
        {
            ActualAmunitionScore.transform.rotation = Quaternion.identity;
            ActualAmunitionScore.text = GetActualScore().ToString();
        }
    }

    public void Event()
    {
        OnWeaponChange?.Invoke();
    }

    public virtual void OnEnable()
    {
        UseActualWeaponSprite();
        UseActualAmourCount();
    }


}
