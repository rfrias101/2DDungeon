using UnityEngine;
using System.Collections;
public class Sword : MonoBehaviour, IWeapon
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float attackDuration = 0.2f;
    [SerializeField] private GameObject swordWavePrefab;
    [SerializeField] private float fireDamagePerSec = 2f;
    [SerializeField] private float fireDuration = 3f;
    private Collider2D _collider;
    private int _slashCount = 0;

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
        _slashCount++;
        _collider.enabled = true;
        yield return new WaitForSeconds(attackDuration);
        _collider.enabled = false;

        if (PlayerAbilities.Instance.HasSwordWave && _slashCount >= 3)
        {
            _slashCount = 0;
            FireSwordWave();
        }
    }

    private void FireSwordWave()
    {
        GameObject wave = Instantiate(swordWavePrefab, transform.position, transform.rotation);
        wave.GetComponent<SwordWave>().SetDamage(damage / 2f);
        Debug.Log("Sword wave fired!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageable>(out var damageable))
        {
            damageable.TakeDamage(damage);
            if (PlayerAbilities.Instance.HasFireDamage)
                other.GetComponent<BurnEffect>()?.ApplyBurn(fireDamagePerSec, fireDuration);
        }
    }
}
