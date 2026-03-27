using UnityEngine;
using System.Collections;
public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackDuration = 0.2f; 
    private Collider2D _collider;

    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false; 
    }

    public void Attack()
    {
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        _collider.enabled = true;               
        yield return new WaitForSeconds(attackDuration);
        _collider.enabled = false;              
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Sword hit: {other.gameObject.name}");
        if (other.TryGetComponent<IDamageable>(out var damageable))
            damageable.TakeDamage(damage);
    }
}
