using UnityEngine;
using UnityEditor;
using System;

public class EnemyBase : MonoBehaviour
{
    //Counter
    public static event Action<float> OnChangeDamage;
    public static event Action OnChangeKill;
    public static event Action<GameObject> OnKillBossFigth;


    [SerializeField] public float _radius;
    [SerializeField] protected float _health;
    [SerializeField] protected float _speedEyes, _speedHand, _smoothRotation;
    [SerializeField] protected Transform _pivotEyes, _pivotHand, _skin;

    protected  Transform _playerTransform;
    protected  float _distance;
    protected float _xEuler = -90;
    private Vector3 _blockZ;

    //HealthBar
    [SerializeField] protected GameObject _healhBarFront;
    private float maxHealth;

    public virtual void Awake()
    {
        maxHealth = _health;

        _playerTransform = FindFirstObjectByType<PlayerController>().transform;
    }

    public virtual void Update()
    {
        Monitoring();

        BlockTransformZ();

        if (_health <= 0)
        {
            Dead();
        }

    }

    public void Monitoring()
    {
        _distance = Vector3.Distance(_playerTransform.position, transform.position);

        if (_distance < _radius)
        {
            RotateHand();
            RotateEyes();
            RotationForward();
        }
    }

    private void RotateEyes()
    {
        
        Vector3 toTarget = _pivotEyes.position - _playerTransform.position;
        Vector3 toTargetXY = new Vector3(toTarget.x, toTarget.y, 0);

        _pivotEyes.rotation = Quaternion.LookRotation(toTargetXY * _speedEyes * Time.deltaTime);
       
    }

    private void RotateHand()
    {
        Vector3 toTarget = _pivotHand.position - _playerTransform.position;
        Vector3 toTargetXY = new Vector3(-toTarget.x, -toTarget.y, 0);

        _pivotHand.rotation = Quaternion.LookRotation(toTargetXY * _speedHand * Time.deltaTime);
    }

    private void RotationForward()
    {
        if (_playerTransform.position.x < transform.position.x)
        {
            _xEuler = 0;
        }
        
        else if (_playerTransform.position.x > transform.position.x)
        {
            _xEuler = -180;
        }


        _skin.localRotation = Quaternion.Lerp(_skin.localRotation, Quaternion.Euler(0, _xEuler, 0), _smoothRotation * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out BulletCharacter damage))
        {
            _health -= damage._damage;

            var healthProcent = (_health / maxHealth) * 100.0f; 
            var healthBarProcent = healthProcent / 100.0f;

            _healhBarFront.transform.localScale = new Vector3(healthBarProcent,1.0f,1.0f);

            OnChangeDamage?.Invoke(damage._damage);  

            AudioSystem.insance._enemy_damage.Play();
        }
    }

    private void BlockTransformZ()
    {
        _blockZ.x = transform.position.x;
        _blockZ.y = transform.position.y;

        transform.position = _blockZ;
    }

    private void Dead()
    {
        OnChangeKill?.Invoke();
        OnKillBossFigth?.Invoke(this.gameObject); 

        Destroy(gameObject);
    }
    
#if UNITY_EDITOR

    public virtual void OnDrawGizmos()
    {
        Handles.DrawWireDisc(this.transform.position, Vector3.forward, _radius);
    }
#endif

}
