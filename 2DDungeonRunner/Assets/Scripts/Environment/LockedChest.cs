using UnityEngine;

public class LockedChest : Chest
{
    private bool _isLocked = true;
    [SerializeField] private GameObject potionPrefab;

    public override void Interact()
    {
        Unlock();
    }

    public void Unlock()
    {
        PlayerInventory inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        if (inventory == null || !inventory.HasKey())
        {
            Debug.Log("No key!");
            return;
        }
        inventory.UseKey();
        SpawnPotion();
        _isLocked = false;
        Debug.Log("Chest unlocked!");
        Destroy(gameObject);
        Open();
    }

    public void SpawnPotion()
    {
        GameObject spawned = Instantiate(potionPrefab, transform.position, Quaternion.identity);
        RoomManager room = FindObjectOfType<RoomManager>();
        if (room != null)
            spawned.transform.SetParent(room.transform);
    }
}
