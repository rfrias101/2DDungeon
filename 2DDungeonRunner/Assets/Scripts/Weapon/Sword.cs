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
    private bool _isAttacking = false;
    void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
    }

    void OnDisable()
    {
        // force disable collider when sword is switched off
        _collider.enabled = false;
        _isAttacking = false;
        StopAllCoroutines();
    }

    public void Attack()
    {
        if (_isAttacking) return;
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        _isAttacking = true;
        _slashCount++;
        _collider.enabled = true;
        yield return new WaitForSeconds(attackDuration);
        _collider.enabled = false;
        _isAttacking = false;

        if (PlayerAbilities.Instance.HasSwordWave && _slashCount >= 3)
        {
            _slashCount = 0;
            FireSwordWave();
        }
    }

    private void FireSwordWave()
    {
        Transform player = GameObject.FindWithTag("Player").transform;
        Quaternion rotation = player.rotation * Quaternion.Euler(0, 0, 0);
        GameObject wave = Instantiate(swordWavePrefab, player.position, rotation);
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
