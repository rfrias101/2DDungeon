using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject minionPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private int baseEnemyCount = 3;
    [SerializeField] private int maxEnemyCount = 10;
    [SerializeField] private int survivalMaxEnemyCount = 30;
    [SerializeField] private float spawnInterval = 0.5f;

    public void SpawnEnemies(int floor, System.Action<List<GameObject>> onComplete)
    {
        StartCoroutine(SpawnRoutine(floor, onComplete));
    }

    private IEnumerator SpawnRoutine(int floor, System.Action<List<GameObject>> onComplete)
    {
        List<GameObject> spawnedEnemies = new List<GameObject>();
        bool isBossFloor = floor % 10 == 0;

        if (isBossFloor)
        {
            GameObject boss = Instantiate(bossPrefab, spawnPoints[0].position, Quaternion.identity);
            spawnedEnemies.Add(boss);
        }
        else
        {
            int enemyCount;
            if (floor > 30)
            {
                int bonusCount = (floor - 30) / 5;
                enemyCount = Mathf.Min(baseEnemyCount + floor - 1 + bonusCount, survivalMaxEnemyCount);
            }
            else
            {
                enemyCount = Mathf.Min(baseEnemyCount + floor - 1, maxEnemyCount);
            }

            for (int i = 0; i < enemyCount; i++)
            {
                Transform spawnPoint = spawnPoints[i % spawnPoints.Length];
                GameObject minion = Instantiate(minionPrefab, spawnPoint.position, Quaternion.identity);
                spawnedEnemies.Add(minion);
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        onComplete?.Invoke(spawnedEnemies);
    }
}