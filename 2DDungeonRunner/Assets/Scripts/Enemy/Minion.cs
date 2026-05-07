using UnityEngine;
public enum MinionType { Normal, Tanky, Fast }
public class Minion : Enemy
{
    private MinionType _minionType;

    public Minion(EnemyData data, MinionType type = MinionType.Normal) : base(data)
    {
        _minionType = type;
        ApplyTypeModifiers();
    }

    public override void Attack(IDamageable target)
    {
        target.TakeDamage(dmg);
    }

    private void ApplyTypeModifiers()
    {
        switch (_minionType)
        {
            case MinionType.Tanky:
                currentHealth *= 2f;
                maxHealth *= 2f;     // keep maxHealth in sync
                speed *= 0.5f;
                break;
            case MinionType.Fast:
                currentHealth *= 0.5f;
                maxHealth *= 0.5f;   // keep maxHealth in sync
                speed *= 2f;
                break;
        }
    }
}