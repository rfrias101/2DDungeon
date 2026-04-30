using UnityEngine;

public class Droppable : MonoBehaviour
{
    [SerializeField] private GameObject[] possibleDrops;
    [SerializeField] private float dropChance = 0.5f;

    public void DropItems()
    {
        if (Random.value <= dropChance && possibleDrops.Length > 0)
        {
            GameObject drop = possibleDrops[Random.Range(0, possibleDrops.Length)];
            GameObject spawned = Instantiate(drop, transform.position, Quaternion.identity);

            RoomManager room = FindObjectOfType<RoomManager>();
            if (room != null)
                spawned.transform.SetParent(room.transform);
        }
        
    }
}
