using UnityEngine;

public class TrappedChest : Chest
{
    private bool _isLocked = true;
    [SerializeField] private GameObject _trapEnemy;

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
        GameObject spawned = Instantiate(_trapEnemy, transform.position, Quaternion.identity);

        RoomManager room = FindObjectOfType<RoomManager>();
        if (room != null)
            spawned.transform.SetParent(room.transform);

        Destroy(gameObject);
    }
}