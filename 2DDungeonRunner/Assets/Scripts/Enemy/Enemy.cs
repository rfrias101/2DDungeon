using UnityEngine;
public abstract class Enemy : WorldEntity, IDamageable, IAttacker
{
    protected float speed;
    protected float health;
    protected float dmg;

    protected Enemy(EnemyData data)
    {
        speed = data.speed;
        health = data.health;
        dmg = data.dmg;
    }
}

