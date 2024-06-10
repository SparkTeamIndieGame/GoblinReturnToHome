using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected  float _radius;
    [SerializeField] private float _speedEyes, _speedHand, _smoothRotation;
    [SerializeField] private Transform _pivotEyes, _pivotHand, _skin;

    protected  Transform _playerTransform;
    private Vector3 _blockZ;
    protected  float _distance;
    private float _xEuler = -90;

    // Start is called before the first frame update

    public virtual void Awake()
    {
        _playerTransform = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        Monitoring();
        BlockTransformZ();

        if (_health <= 0)
            Dead();
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
            _xEuler = 0;
        else if (_playerTransform.position.x > transform.position.x)
            _xEuler = -180;

        _skin.localRotation = Quaternion.Lerp(_skin.localRotation, Quaternion.Euler(0, _xEuler, 0), _smoothRotation * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out BulletCharacter damage))
        {
            _health -= damage._damage;
            print($"{name}, получил урон в {damage._damage} едениц пулей {damage.gameObject.name}, у него осталось {_health}, ");
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
        print($"{name} умер");
        Destroy(gameObject);
    }


}
