using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 1f;
    [SerializeField] private float initialDelay = 1.5f;
    private float _attackTimer;
    private EnemyController _enemyController;
    private AIMovement _aiMovement;
    private Transform _playerTransform;
    private IDamageable _playerDamageable;

    void Start()
    {
        _enemyController = GetComponent<EnemyController>();
        _aiMovement = GetComponent<AIMovement>();
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _playerDamageable = _playerTransform.GetComponent<IDamageable>();
        _attackTimer = initialDelay;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, _playerTransform.position);

        if (distanceToPlayer <= _aiMovement.StopDistance)
        {
            _attackTimer -= Time.deltaTime;

            if (_attackTimer <= 0f)
            {
                _enemyController.Attack(_playerDamageable);
                _attackTimer = attackCooldown;
            }
        }
        else
        {
            _attackTimer = initialDelay;
        }
    }
}
