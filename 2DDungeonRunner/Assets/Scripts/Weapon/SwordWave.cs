using UnityEngine;

public class SwordWave : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    [SerializeField] private float lifetime = 1f;
    private float _damage;

    void Awake()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(_damage);
            if (PlayerAbilities.Instance.HasFireDamage)
                other.GetComponent<BurnEffect>()?.ApplyBurn(2f, 3f);
        }
    }
}
