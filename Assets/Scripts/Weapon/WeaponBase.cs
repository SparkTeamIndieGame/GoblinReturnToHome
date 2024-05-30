using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public  Transform[] SpawnPoint;
    public float ShootPeriod = 1.0f;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10.0f;

    protected float timer;
    readonly protected float MaxPlayerSpeed = 10.0f;

    public virtual void Update()
    {
        timer += Time.deltaTime;
        if (timer > ShootPeriod)
        {
            if (Input.GetMouseButton(0))
            {
                timer = 0.0f;
                GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[0].position, SpawnPoint[0].rotation);
                newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint[0].forward * (BulletSpeed + MaxPlayerSpeed);
            }
        }
    }
}
