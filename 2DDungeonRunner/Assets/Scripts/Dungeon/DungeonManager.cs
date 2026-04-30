using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation; 
using System.Collections.Generic;

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

    private void Start()
    {
        LoadNextRoom();
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

        
        Transform navmeshChild = _currentRoom.transform.Find("Navmesh");
        Debug.Log($"Navmesh child found: {navmeshChild != null}");

        NavMeshSurface surface = navmeshChild?.GetComponent<NavMeshSurface>();
        Debug.Log($"NavMeshSurface found: {surface != null}");

        if (surface != null)
            surface.BuildNavMesh();

        _currentRoom.GetComponent<RoomManager>().Initialize(_currentFloor);
        RepositionPlayer();
    }

    private void SpawnBossRoom()
    {
        _currentRoom = Instantiate(bossPrefab, roomSpawnPoint.position, Quaternion.identity);

        NavMeshSurface surface = _currentRoom.GetComponentInChildren<NavMeshSurface>();
        if (surface != null)
            surface.BuildNavMesh();

        _currentRoom.GetComponent<RoomManager>().Initialize(_currentFloor);
        RepositionPlayer(); 
    }

    private void RepositionPlayer()
    {
        Transform spawnPoint = _currentRoom.GetComponent<RoomManager>().GetPlayerSpawnPoint();
        if (spawnPoint == null) return;

        GameObject player = GameObject.FindWithTag("Player");
        if (player == null) return;

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.position = spawnPoint.position;
        else
            player.transform.position = spawnPoint.position;
    }

    public int GetCurrentFloor() { return _currentFloor; }
}