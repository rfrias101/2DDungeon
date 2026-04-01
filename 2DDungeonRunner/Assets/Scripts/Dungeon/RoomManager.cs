using UnityEngine;
using System.Collections.Generic;
public class RoomManager : MonoBehaviour
{
    [SerializeField] private DoorController exitDoor;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ChestSpawner chestSpawner;

    private List<GameObject> _enemies = new List<GameObject>();

    public void Initialize(int floor)
    {
        exitDoor.Lock();
        _enemies = enemySpawner.SpawnEnemies(floor);
        chestSpawner.TrySpawnChest();
    }

    public void OnEnemyDied(GameObject enemy)
    {
        _enemies.Remove(enemy);
        Debug.Log($"Enemies remaining: {_enemies.Count}");

        if (_enemies.Count == 0)
        {
            Debug.Log("Room cleared!");
            exitDoor.Unlock();
        }
    }
}