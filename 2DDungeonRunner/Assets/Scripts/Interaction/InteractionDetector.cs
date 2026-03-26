using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private IInteractable _currentInteractable;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            //Debug.Log("DUISNFHISDNF");
            _currentInteractable = interactable;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out var interactable))
        {
            _currentInteractable = null;
        }
    }

    public void Interact()
    {
        _currentInteractable?.Interact();
    }
}
