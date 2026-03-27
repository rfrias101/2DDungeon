using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] public EnemyData data;
    [SerializeField] private AIMovement _aiMovement;
    private Enemy _enemy;
    private void Awake()
    {
        if (enemyType == EnemyType.Minion)
            _enemy = new Minion(data);
        else if (enemyType == EnemyType.Boss)
            _enemy = new Boss(data);
    }

    private void Start()
    {
        _aiMovement.SetSpeed(data.speed);
    }

    public void Attack(IDamageable target)
    {
        _enemy.Attack(target);
    }

    public void TakeDamage(float damage)
    {
        _enemy.TakeDamage(damage);
        Debug.Log($"{enemyType} health: {_enemy.CurrentHealth}");

        if (_enemy.IsDead())
        {
            Debug.Log($"{enemyType} is dead!");
            Destroy(gameObject);
        }
    }

    public bool IsDead()
    {
        return _enemy.IsDead();
    }

}
public enum EnemyType { Minion, Boss }

[System.Serializable]
public class EnemyData
{
    public float speed;
    public float health;
    public float dmg;
}