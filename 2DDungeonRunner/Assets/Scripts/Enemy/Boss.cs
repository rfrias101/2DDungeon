using UnityEngine;

public class Boss : Enemy
{
    public Boss(EnemyData data) : base(data)
    {
    }
    public override void Attack(IDamageable target)
    {
        target.TakeDamage(dmg);
        if (target is PlayerHealth playerHealth)
            playerHealth.ApplySlow(0.5f, 2f);
    }
}