using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class EnemyHook : EnemyBase
{
    [SerializeField] protected float _offsetDistance;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _damage;
    protected Vector3 _targetPlayerX;
    protected CharacterController _characterControler;
    protected Animator Animator;

    public override void Awake()
    {
        base.Awake();

        _characterControler = GetComponent<CharacterController>();
        Animator = GetComponent<Animator>();
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
        if(_distance < _offsetDistance)
        {
            _targetPlayerX = Vector3.zero;
            Animator.SetBool("Attack", true);
            Animator.SetBool("Run", false);

        }
       else if (_distance > _radius)
        {
            _targetPlayerX = Vector3.zero;
            Animator.SetBool("Attack", false);
            Animator.SetBool("Run", false);
        }

        else if (_distance < _radius)
        {
            _targetPlayerX = new Vector3(_playerTransform.position.x - transform.position.x, 0, 0);
            Animator.SetBool("Run", true);
            Animator.SetBool("Attack", false);

        }
    }

    public void Hit()
    {
        if(_distance < _offsetDistance)
        {
            _playerTransform.gameObject.GetComponent<PlayerController>().Health -= _damage;
            print($"{name} ударил игрока, урон составил {_damage} и у игрорка осталось {_playerTransform.gameObject.GetComponent<PlayerController>().Health}");

        }

    }

}
