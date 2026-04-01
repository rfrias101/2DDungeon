using UnityEngine;

public class ChestKey : Key
{
    public override void Pickup()
    {
        Debug.Log("Chest Key picked up!");
        // hasKey maging true for chest opening
        Destroy(gameObject);
    }
}
