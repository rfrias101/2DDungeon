using UnityEngine;
public abstract class Enemy : WorldEntity, IDamageable, IAttacker
{
    protected float speed;
    protected float dmg;
    protected float maxHealth;
    protected float currentHealth; 
    public float CurrentHealth => currentHealth;
    public float GetSpeed() => speed;

    protected Enemy(EnemyData data)
    {
        speed = data.speed;
        dmg = data.dmg;
        maxHealth = data.health;
        currentHealth = data.health;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0f);
    }

    public bool IsDead()
    {
        return currentHealth <= 0f;
    }

    public abstract void Attack(IDamageable target);
}

