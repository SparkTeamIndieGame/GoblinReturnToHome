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

    private void Start()
    {
        if (StartAmunicionCount == 0)
        {
            StartAmunicionCount = Mathf.Infinity;
        }
        currentAmunicionCount = StartAmunicionCount;
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
        UseActualAmourCount();
    }
    public virtual void RemoveAmunicion()
    {
        currentAmunicionCount -= 1;
        UseActualAmourCount();
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
    public virtual void OnEnable()
    {
        UseActualWeaponSprite();
        UseActualAmourCount();
    }


}
