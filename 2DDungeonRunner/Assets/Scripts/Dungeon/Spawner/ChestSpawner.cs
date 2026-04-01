using UnityEngine;
public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject chestPrefab;
    [SerializeField] private Transform[] chestSpawnPoints;
    [SerializeField] private float chestSpawnChance = 0.4f; 

    public void TrySpawnChest()
    {
        if (Random.value <= chestSpawnChance)
        {
            Transform spawnPoint = chestSpawnPoints[Random.Range(0, chestSpawnPoints.Length)];
            Instantiate(chestPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Chest spawned!");
        }
    }
}