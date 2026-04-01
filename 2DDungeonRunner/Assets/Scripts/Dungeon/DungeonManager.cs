using UnityEditor.EditorTools;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager Instance; 

    [SerializeField] private GameObject[] roomPrefabs; 
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private Transform roomSpawnPoint;

    private int _currentFloor = 0;
    private GameObject _currentRoom;

    void Awake()
    {
        Instance = this;
    }

    public void LoadNextRoom()
    {
        _currentFloor++;
        Debug.Log($"Floor {_currentFloor}");

        if (_currentRoom != null)
            Destroy(_currentRoom);

        if (_currentFloor % 10 == 0)
            SpawnBossRoom();
        else
            SpawnNormalRoom();
    }

    private void SpawnNormalRoom()
    {
        GameObject randomRoom = roomPrefabs[Random.Range(0, roomPrefabs.Length)];
        _currentRoom = Instantiate(randomRoom, roomSpawnPoint.position, Quaternion.identity);
        _currentRoom.GetComponent<RoomManager>().Initialize(_currentFloor);
    }

    private void SpawnBossRoom()
    {
        _currentRoom = Instantiate(bossPrefab, roomSpawnPoint.position, Quaternion.identity);
        _currentRoom.GetComponent<RoomManager>().Initialize(_currentFloor);
    }

    public int GetCurrentFloor() { return _currentFloor; }
}
