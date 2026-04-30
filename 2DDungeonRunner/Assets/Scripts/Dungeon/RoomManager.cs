using UnityEngine;
using System.Collections.Generic;
public class RoomManager : MonoBehaviour
{
    [SerializeField] private DoorController exitDoor;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private ChestSpawner chestSpawner;
    [SerializeField] private Transform playerSpawnPoint;
    private List<GameObject> _enemies = new List<GameObject>();

    public Transform GetPlayerSpawnPoint() => playerSpawnPoint;
    public void Initialize(int floor)
    {
        exitDoor.Lock();
        _enemies.Clear();
        enemySpawner.SpawnEnemies(floor, (enemies) =>
        {
            enemies.RemoveAll(e => e == null);
            _enemies = enemies;

            if (_enemies.Count == 0)
            {
                Debug.Log("Room cleared!");
                exitDoor.Unlock();
            }
        });
        chestSpawner.TrySpawnChest();
    }

    public void OnEnemyDied(GameObject enemy)
    {
        if (!_enemies.Contains(enemy)) return; // ignore kills during spawning
        _enemies.Remove(enemy);
        Debug.Log($"Enemies remaining: {_enemies.Count}");
        if (_enemies.Count == 0)
        {
            Debug.Log("Room cleared!");
            exitDoor.Unlock();
        }
    }
}