using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] public EnemyData data;
    [SerializeField] private AIMovement _aiMovement;

    private Droppable _droppable;
    private DamageFlash _dmgflash;
    private Enemy _enemy;
    private void Awake()
    {
        _dmgflash = GetComponent<DamageFlash>();
        _droppable = GetComponent<Droppable>();

        EnemyData scaledData = EnemyScaling.ScaleData(data, PlayerProgression.Instance.GetLevel());

        if (enemyType == EnemyType.Minion)
        {
            MinionType randomType = (MinionType)Random.Range(0, 3);
            _enemy = new Minion(scaledData, randomType);
        }
        else if (enemyType == EnemyType.Boss)
            _enemy = new Boss(scaledData);
    }

    private void Start()
    {
        _aiMovement.SetSpeed(_enemy.GetSpeed());
    }

    public void Attack(IDamageable target)
    {
        _enemy.Attack(target);
    }

    public void TakeDamage(float damage)
    {
        _enemy.TakeDamage(damage);
        _dmgflash?.Flash();
        Debug.Log($"{enemyType} health: {_enemy.CurrentHealth}");

        if (_enemy.IsDead())
        {
            Debug.Log($"{enemyType} is dead!");
            RoomManager roomManager = FindObjectOfType<RoomManager>();
            if (roomManager != null)
                roomManager.OnEnemyDied(gameObject);
            _droppable?.DropItems();
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