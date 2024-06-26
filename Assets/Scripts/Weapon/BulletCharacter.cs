using UnityEngine;

public class BulletCharacter : MonoBehaviour
{
    [SerializeField] public float _damage;
    [SerializeField] protected float _lifeTime = 5.0f;
    [SerializeField] ParticleSystem _blood;


    private void Start()
    {
        
        Destroy(this.gameObject, _lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent(out EnemyBase hit))
        {
            Instantiate(_blood, transform.position, transform.rotation);
        }

        else
        {
            Destroy(gameObject);
        }

        Destroy(this.gameObject);
    }
}
