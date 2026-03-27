using UnityEngine;

public class Health
{
    private float _maxHealth;
    private float _currentHealth;

    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0f);
    }

    public bool IsDead() => _currentHealth <= 0f;
    public float GetCurrentHealth() => _currentHealth;
    public float GetMaxHealth() => _maxHealth;
}
