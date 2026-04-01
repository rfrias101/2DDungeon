using UnityEngine;

public class Chest : MonoBehaviour, IOpenable
{
    public virtual void Open()
    {
        Debug.Log("Chest opened!");
    }

    public void Interact()
    {
        Open();
    }
}
