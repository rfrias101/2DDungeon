using UnityEngine;

public class Boss : Enemy
{
    public Boss(EnemyData data) : base(data)
    {
    }
    public override void Attack(IDamageable target)
    {
        target.TakeDamage(dmg);
    }
}