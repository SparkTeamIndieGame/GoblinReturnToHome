using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayer : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private GameObject _deathPanel;
    [SerializeField] private SkinnedMeshRenderer _meshRender;
    [SerializeField] private ParticleSystem _walk, _jump;

    private Animator _animator;
    private PlayerController _player;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _player.DamageBullet += Damage;
        EnemyBomb.DamageBomb += Damage;
        EnemyHook.DamageHit  += Damage;
        BoxCrush.DamagePLayer += Damage;
        FXObstacle.Damage += Damage;
    }

    private void OnDisable()
    {
        _player.DamageBullet -= Damage;
        EnemyBomb.DamageBomb -= Damage;
        EnemyHook.DamageHit  -= Damage;
        BoxCrush.DamagePLayer -= Damage;
        FXObstacle.Damage -= Damage;


    }
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        Jump();
        //_walk.Play();

        if(_player.Health <= 0)
        {
            DeadAnim();
        }
    }

    private void Move(float input)
    {
        if ((input > 0 || input < 0) && _player.gameObject.GetComponent<CharacterController>().isGrounded)
        {
            _animator.SetBool("Run", true);
            AudioSystem.insance._player_walk.mute = false;
            if (_walk.isStopped)
                _walk.Play();
        }

        else
        {
            _animator.SetBool("Run", false);
            AudioSystem.insance._player_walk.mute = true;
            if (_walk.isPlaying)
                _walk.Stop();
        }

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _animator.SetTrigger("Jump");
            _jump.Play();


        }
    }

    private void Damage(float damage)
    {
        _player.Health -= damage;
        AudioSystem.insance._player_damage.Play();
        DamageAnim();
    }

    private void DamageAnim()
    {
        _animator.SetTrigger("Damage");
        StartCoroutine("HitMaterial");
    }


    private void DeadAnim()
    {
        _animator.SetBool("Dead", true);
        StartCoroutine("Dead");

    }

    public void SoundDead()
    {
        AudioSystem.insance._player_dead.Play();
        AudioSystem.insance._player_damage.mute = true;
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(_delay);
        _deathPanel.SetActive(true);
        Destroy(transform.parent.gameObject);
        DeathPanel._isDeath = true;
    }

    IEnumerator HitMaterial()
    {
        _meshRender.materials[0].color = new Color32(255, 0, 0, 255);
        yield return new WaitForSeconds(0.5f);
        _meshRender.materials[0].color = new Color32(150, 150, 150, 255);

    }



}
