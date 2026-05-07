using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float lifetime = 3f;
    private float _damage;
    private float _fireDamagePerSec;
    private float _fireDuration;
    private bool _hasFireDamage;
    private Rigidbody2D _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime);
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public void SetFireDamage(float damagePerSec, float duration)
    {
        _fireDamagePerSec = damagePerSec;
        _fireDuration = duration;
        _hasFireDamage = true;
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = transform.up * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
            if (_hasFireDamage)
                other.GetComponent<BurnEffect>()?.ApplyBurn(_fireDamagePerSec, _fireDuration);
            Destroy(gameObject);
        }
    }
}
