using UnityEngine;
using System.Collections.Generic;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int baseEnemyCount = 3;
    [SerializeField] private int maxEnemyCount = 10;

    public List<GameObject> SpawnEnemies(int floor)
    {
        List<GameObject> spawnedEnemies = new List<GameObject>();

        int enemyCount = Mathf.Min(baseEnemyCount + floor - 1, maxEnemyCount);
        bool isBossFloor = floor % 10 == 0;

        if (isBossFloor)
        {
            Transform spawnPoint = spawnPoints[0];
            GameObject boss = Instantiate(bossPrefab, spawnPoint.position, Quaternion.identity);
            spawnedEnemies.Add(boss);
        }
        else
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
                GameObject minion = Instantiate(minionPrefab, spawnPoint.position, Quaternion.identity);
                spawnedEnemies.Add(minion);
            }
        }

        return spawnedEnemies;
    }
}