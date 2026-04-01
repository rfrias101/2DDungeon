using UnityEngine;

public class TrappedChest : Chest
{
    private bool _isLocked = true;

    public override void Open()
    {
        if (_isLocked)
            Debug.Log("Chest is locked! Need a key.");
        else
            Debug.Log("Locked chest opened!");
    }

    public void Unlock()
    {
        _isLocked = false;
        Debug.Log("Chest unlocked! IT'S A TRAP!");
        Destroy(gameObject);
    }
}
