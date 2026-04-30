using UnityEngine;
public class Key : MonoBehaviour, IPickable, IInteractable
{
    public virtual void Pickup()
    {
        Debug.Log("Key picked up!");
        Destroy(gameObject);
    }

    public void Interact()
    {
        Pickup();
    }
}