using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyHook : EnemyBase
{
    [SerializeField] protected float _offsetDistance;
    [SerializeField] protected float _speed;
    protected private Vector3 _targetPlayerX;
    protected private CharacterController _characterControler;

    public override void Awake()
    {
        base.Awake();

        _characterControler = GetComponent<CharacterController>();
    }
    public override void Update()
    {
        base.Update();

        if (!_characterControler.isGrounded)
            _targetPlayerX = Vector3.zero;

        Pursuit();
        

    }

    private void FixedUpdate()
    {
        _characterControler.SimpleMove(_targetPlayerX * _speed);
    }

    public virtual void Pursuit()
    {

        if (_distance < _radius)
            _targetPlayerX = new Vector3(_playerTransform.position.x - transform.position.x, 0, 0);

        else if (_distance > _radius || _distance < _offsetDistance)
            _targetPlayerX = Vector3.zero;

    }

}
