using UnityEngine;
using UnityEditor;
using System.Collections;

public class Enemy : EnemyBase
{
    public Transform[] SpawnPoint;
    public float ShootPeriod = 1.0f;
    public GameObject BulletPrefab;
    public float BulletSpeed = 10.0f;
    public float _patrulDelay;

    private bool _patrulOn = true; 
    protected float timer;
    readonly protected float MaxPlayerSpeed = 10.0f;
    

    public override void Update()
    {
        base.Update();

        //Timer();

        if (_distance < _radius)
            RayCheck();
        else if (_distance > _radius)
        {
            Patrul();

            if (_patrulOn)
                StartCoroutine("PatrulCor");
        }
    }

    private void Shoot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, SpawnPoint[0].position, SpawnPoint[0].rotation);
        newBullet.GetComponent<Rigidbody>().velocity = SpawnPoint[0].forward * (BulletSpeed + MaxPlayerSpeed); // изменить при настройке модели врага "-"
    }

    private void RayCheck()
    {
        Timer();
        Ray ray = new Ray(SpawnPoint[0].position, SpawnPoint[0].forward);// изменить при настройке модели врага "-"
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

    private void PatrulForward()
    {
        if(_xEuler == 0)
        {
            _xEuler = -180;
        }

        else
        {
            _xEuler = 0;
        }
    }

    private void Patrul()
    {
        _skin.localRotation = Quaternion.Lerp(_skin.localRotation, Quaternion.Euler(0, _xEuler, 0), _smoothRotation * Time.deltaTime);
    }

    IEnumerator PatrulCor()
    {
        _patrulOn = false;
        yield return new WaitForSeconds(_patrulDelay) ;
        {
            PatrulForward();
            _patrulOn = true;
        }
    }
#if UNITY_EDITOR
    public override void OnDrawGizmos()
    {
        Handles.color = Color.red;
        base.OnDrawGizmos();
    }
#endif
}
