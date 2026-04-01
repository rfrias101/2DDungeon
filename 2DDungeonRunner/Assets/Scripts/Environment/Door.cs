using UnityEngine;

public class Door : MonoBehaviour, IOpenable
{
    public virtual void Open()
    {
        Debug.Log("Door opened!");
    }

    public void Interact()
    {
        Open();
    }
}
