using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
    [SerializeField] private float _currentHealth;

    void Awake()
    {
        _currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _currentHealth = Mathf.Max(_currentHealth, 0f);
        Debug.Log($"Player health: {_currentHealth}");

        if (IsDead())
            Debug.Log("Player is dead!");
    }

    public bool IsDead()
    {
        return _currentHealth <= 0f;
    }

    public float GetCurrentHealth() { return _currentHealth; }
    public float GetMaxHealth() { return maxHealth; }
}
