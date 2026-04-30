using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float _currentHealth;
    private DamageFlash _dmgFlash;
    void Awake()
    {
        _dmgFlash = GetComponent<DamageFlash>();
        _currentHealth = maxHealth;
    }
    //Call Damage Logic Region
    #region 
    public void TakeDamage(float damage)
    {
        _dmgFlash?.Flash();
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0f);
        Debug.Log($"Player health: {_currentHealth}");

        if (IsDead())
            Debug.Log("Player is dead!");
    }
    #endregion

    //Call Debuff Effects Logic Region
    #region
    public void ApplySlow(float slowAmount, float duration)
    {
        GetComponent<Movement>().ApplySlow(slowAmount, duration);
    }
    #endregion

    public void Heal(float amount)
    {
        _currentHealth += amount;
        _currentHealth = Mathf.Min(_currentHealth, maxHealth);
        Debug.Log($"Player healed! Health: {_currentHealth}");
    }

    public bool IsDead()
    {
        return _currentHealth <= 0f;
    }

    public float GetCurrentHealth() { return _currentHealth; }
    public float GetMaxHealth() { return maxHealth; }
}
