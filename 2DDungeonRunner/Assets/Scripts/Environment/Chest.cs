using UnityEngine;

public class Chest : MonoBehaviour, IOpenable, IInteractable
{
    public virtual void Open()
    {
        Debug.Log("Chest opened!");
    }
    public virtual void Interact()
    {
        Open();
    }
}
