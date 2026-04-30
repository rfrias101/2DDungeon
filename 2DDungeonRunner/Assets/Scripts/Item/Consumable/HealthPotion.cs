using UnityEngine;
public class HealthPotion : Potion
{
    public override void Pickup()
    {
        PlayerInventory inventory = GameObject.FindWithTag("Player").GetComponent<PlayerInventory>();
        if (inventory == null) return;
        if (inventory.GetPotions() >= inventory.GetMaxPotions())
        {
            Debug.Log("Can't carry more potions!");
            return;
        }
        inventory.AddPotion();
        Debug.Log("Health potion picked up!");
        Destroy(gameObject);
    }
}
