using UnityEngine;

public class DoorController : MonoBehaviour, IOpenable
{
    private bool _isLocked = true;

    public void Lock()
    {
        _isLocked = true;
        Debug.Log("Door locked!");
    }

    public void Unlock()
    {
        _isLocked = false;
        Debug.Log("Door unlocked! Proceed to next floor.");
    }

    public void Open()
    {
        if (_isLocked)
        {
            Debug.Log("Door is locked! Clear all enemies first.");
            return;
        }
        DungeonManager.Instance.LoadNextRoom();
    }

    public void Interact()
    {
        Open();
    }
}