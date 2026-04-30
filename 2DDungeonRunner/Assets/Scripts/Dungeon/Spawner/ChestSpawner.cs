using UnityEngine;
public class ChestSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] chestPrefabs;
    [SerializeField] private Transform[] chestSpawnPoints;
    [SerializeField] private float chestSpawnChance = 0.4f; 

    public void TrySpawnChest()
    {
        if (Random.value <= chestSpawnChance)
        {
            Transform spawnPoint = chestSpawnPoints[Random.Range(0, chestSpawnPoints.Length)];
            GameObject chosenChest = chestPrefabs[Random.Range(0, chestPrefabs.Length)];
            GameObject spawned = Instantiate(chosenChest, spawnPoint.position, Quaternion.identity);

            RoomManager room = FindObjectOfType<RoomManager>();
            if (room != null)
                spawned.transform.SetParent(room.transform);

            Debug.Log("Chest spawned!");
        }
    }
}