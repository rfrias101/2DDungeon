using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private EnemyType enemyType;
    [SerializeField] private EnemyData data;  

    private Enemy _enemy;
    private void Awake()
    {
        if (enemyType == EnemyType.Minion)
            _enemy = new Minion(data);
        else if (enemyType == EnemyType.Boss)
            _enemy = new Boss(data);
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