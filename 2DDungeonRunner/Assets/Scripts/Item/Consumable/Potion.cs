using UnityEngine;
public class Potion : MonoBehaviour, IPickable, IConsumable, IInteractable
{
    public virtual void Consume() { }

    public virtual void Pickup()
    {
        Consume();
    }

    public void Interact()
    {
        Pickup();
    }
}
