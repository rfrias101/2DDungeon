using UnityEngine;
public class HealthPotion : Potion
{
    [SerializeField] private float healAmount = 50f;

    public override void Consume()
    {
        Debug.Log($"Health restored by {healAmount}!");
    }
}