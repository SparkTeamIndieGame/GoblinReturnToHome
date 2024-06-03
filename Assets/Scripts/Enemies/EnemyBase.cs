using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected  float _radius;
    [SerializeField] private float _speedHead, _speedHand;
    [SerializeField] private Transform _pivotHead, _pivotHand;

    protected  Transform _playerTransform;
    private Vector3 _blockZ;
    protected  float _distance;
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
            RotateHead();
        }
    }

    private void RotateHead()
    {
        Vector3 toTarget = _pivotHead.position - _playerTransform.position;
        Vector3 toTargetXY = new Vector3(toTarget.x, toTarget.y, 0);
        _pivotHead.rotation = Quaternion.LookRotation(toTargetXY * _speedHead * Time.deltaTime);
    }

    private void RotateHand()
    {
        Vector3 toTarget = _pivotHand.position - _playerTransform.position;
        Vector3 toTargetXY = new Vector3(toTarget.x, toTarget.y, 0);
        _pivotHand.rotation = Quaternion.LookRotation(toTargetXY * _speedHand * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out BulletTest damage))
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
