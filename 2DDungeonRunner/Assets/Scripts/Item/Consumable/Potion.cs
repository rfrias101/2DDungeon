using UnityEngine;
public class Potion : MonoBehaviour, IPickable, IConsumable
{
    public virtual void Consume()
    {
        Debug.Log("Potion consumed!");
    }

    public virtual void Pickup()
    {
        Consume();
        Destroy(gameObject);
    }

    public void Interact()
    {
        Pickup();
    }
}
