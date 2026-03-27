using UnityEngine;

public class Minion : Enemy
{
    public Minion(EnemyData data) : base(data) { }

    public override void Attack(IDamageable target)
    {
        target.TakeDamage(dmg);
    }
}
