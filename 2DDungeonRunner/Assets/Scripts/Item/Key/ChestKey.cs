using UnityEngine;

public class ChestKey : Key
{
    public override void Pickup()
    {
        PlayerInventory inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        if (inventory == null) return;
        if (inventory.GetKeys() >= inventory.GetMaxKeys())
        {
            Debug.Log("Can't carry more Keys");
            return; 
        }
        inventory.AddKey();
        Debug.Log("Key picked up!");
        Destroy(gameObject);
    }
}
